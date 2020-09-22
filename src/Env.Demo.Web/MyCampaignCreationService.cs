using CsvHelper;
using Env.Demo.Campaigns;
using Env.Demo.Dtos;
using Env.Demo.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace Env.Demo.Web
{


    public class MyCampaignCreationService :    IValidationEnabled, ISingletonDependency
    {

        private IWebHostEnvironment environment;
        private IStringLocalizer<DemoResource> L;
        private EmailQueueRegistrationService emailQueueRegisterationService;
        private IRepository<Campaign> campaignRepo;
        private IRepository<CampaignItem> campaignItemRepo;


        public MyCampaignCreationService(IRepository<Campaign> _campaignRepo, IRepository<CampaignItem> _campaignItemRepo, IWebHostEnvironment _environment, IStringLocalizer<DemoResource> _L, EmailQueueRegistrationService _emailQueueRegisterationService)
        {
            environment = _environment;
            L = _L;
            emailQueueRegisterationService = _emailQueueRegisterationService;
            campaignItemRepo = _campaignItemRepo;
            campaignRepo = _campaignRepo;
        }

        public virtual async Task<List<UsernameMailDto>> Upload(UploadEmailDto UploadDto)
        {
            string file = await UploadFile(UploadDto);
            var records = ParseEmails(file);
            return records;
        }

        private async Task<string> UploadFile(UploadEmailDto UploadDto)
        {
            var file = Path.Combine(environment.ContentRootPath, @"wwwroot\uploads", UploadDto.EmailFile.FileName);
            if (Path.GetExtension(UploadDto.EmailFile.FileName) != ".csv")
            {
                throw new UserFriendlyException(L.GetString("FileFormatIsInvalid"));
            }
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await UploadDto.EmailFile.CopyToAsync(fileStream);

            }

            return file;
        }

         
        public async Task<bool> AddToQueue(List<UsernameMailDto> records, UploadEmailDto UploadDto)
        {
            var campaign = await campaignRepo.InsertAsync(new Campaign { Subject = UploadDto.Subject, ItemCount=records.Count });

            List<CampaignItem> createdCampaignItems = new List<CampaignItem>();
            foreach (var item in records)
            {

                var campaignItem = await campaignItemRepo.InsertAsync(new CampaignItem { CampaignId = campaign.Id, Email = item.emailaddress, Name = item.name });
                var res = await emailQueueRegisterationService.AddToEmailQueue( campaign.Id, campaignItem.Id, campaignItem.Email, UploadDto.Subject, UploadDto.ContentBody);

                createdCampaignItems.Add(campaignItem);

            }

            return true;


        }

        private List<UsernameMailDto> ParseEmails(string file)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<UsernameMailDto>().ToList();

                if (records.Any(x => !IsValidEmail(x.emailaddress)))
                {
                    throw new Exception(L.GetString("There are invalid email addresses"));
                }
                return records;

            }
        }

  
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public List<CampaignDto> GetCampaigns(int page = 1, int pageSize = 20, string ord = null)
        {
            var result = (from p in campaignRepo select p);

            result= (from p in campaignRepo.OrderBy(ord) select p);

            var result2 = (from p in result.Skip(Convert.ToInt32((page - 1) * pageSize)).Take(Convert.ToInt32(pageSize))
                      select new CampaignDto { Subject = p.Subject, ItemCount = p.ItemCount, SentItemCount = campaignItemRepo.Count(x => x.CampaignId == p.Id && x.IsSent == true) });


            return result2.ToList();

        }

    }
}
