using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Env.Demo.Campaigns;
using Env.Demo.Dtos;
using Env.Demo.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Env.Demo.Web.Pages.Campaigns
{
    public class IndexModel : PageModel
    {


        public List<CampaignDto> campaigns;

        private MyCampaignCreationService campaignService;

        private IStringLocalizer<DemoResource> L;


        public IndexModel( MyCampaignCreationService _campaignService, IStringLocalizer<DemoResource> _L)
        {
            L = _L;
            campaignService = _campaignService;
        }



        public void OnGet()
        {
             campaigns = campaignService.GetCampaigns(1, 20, (c => c.Id));
        }
    }
}
