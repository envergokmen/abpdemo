using Env.Demo.Dtos;
using Env.Demo.Localization;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Env.Demo.Web.Pages
{
    public class IndexModel : DemoPageModel
    {
      
        public PagedCampaignDto pageCampaigns;
        private MyCampaignCreationService campaignService;
        private IStringLocalizer<DemoResource> L;

        public IndexModel(MyCampaignCreationService _campaignService, IStringLocalizer<DemoResource> _L)
        {
            L = _L;
            campaignService = _campaignService;
        }

        public async Task OnGet()
        {

            pageCampaigns = campaignService.GetCampaigns(1, 20, "Id desc");

        }

    }
}