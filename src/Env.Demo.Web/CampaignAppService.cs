using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Env.Demo.Campaigns;
using Env.Demo.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Env.Demo
{
    /* Inherit your application services from this class.
     */
    public abstract class CampaignAppService : IScopedDependency
    {

        private IRepository<CampaignItem> campaignItemRepo;
        private IRepository<Campaign> campaignRepo;


        public CampaignAppService(IRepository<CampaignItem> _campaignItemRepo, IRepository<Campaign> _campaignRepo)
        {
            campaignItemRepo = _campaignItemRepo;
            campaignRepo = _campaignRepo;
        }

        public async Task<bool> SetCampaignItemStatus(bool isSent, Guid id)
        {

            var item = (await campaignItemRepo.FindAsync(c => c.Id == id));

            if (item != null)
            {
                item.IsSent = isSent;
            }

            await campaignItemRepo.UpdateAsync(item);

            return true;

        }


        public async Task<List<Campaign>> GetCampaigns(int page=1, int pageSize=20, Expression<Func<Campaign, Guid>> orderBy=null)
        {

            var result = (from p in campaignRepo
                                      orderby orderBy
                                     select p)
                .Skip(Convert.ToInt32((page - 1) * pageSize)).Take(Convert.ToInt32(pageSize)).ToList();

         
            return result;

        }

    }
}
