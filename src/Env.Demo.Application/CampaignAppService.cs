using System;
using System.Collections.Generic;
using System.Linq;
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
    public abstract class CampaignAppService : ApplicationService,  ICampaignAppService
    {

        private IRepository<CampaignItem> campaignItemRepo;

        public CampaignAppService(IRepository<CampaignItem> _campaignItemRepo)
        {
            campaignItemRepo = _campaignItemRepo;
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

    }
}
