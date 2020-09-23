using Env.Demo.Dtos;
using Env.Demo.Localization;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

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

        public void OnGet(int page=1, int pageSize=5, string order="Id desc")
        {
            pageCampaigns = campaignService.GetCampaigns(page, pageSize, order);
        }
    }
}