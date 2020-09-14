using Env.Demo;
using Env.Demo.Campaigns;
using Env.Demo.Email;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;

namespace MyProject
{
    public class EmailSendingJob : BackgroundJob<EmailSendingArgs>, ITransientDependency
    {
        private readonly IEmailSender emailSender;
        IRepository<CampaignItem> campaignItemRepo;
        public EmailSendingJob(IEmailSender _emailSender, IRepository<CampaignItem> _campaignItemRepo)
        {
            emailSender = _emailSender;
            campaignItemRepo = _campaignItemRepo;
        }

        public override async void Execute(EmailSendingArgs args)
        {
            await emailSender.SendAsync(
                args.EmailAddress,
                args.Subject,
                args.Body
            );

            var item = (await campaignItemRepo.FindAsync(c => c.Id == args.ItemId));

            if (item != null)
            {
                item.IsSent = true;
                await campaignItemRepo.UpdateAsync(item);

            }


        }
    }
}