using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Env.Demo.Localization;
using Env.Demo.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Env.Demo.Web.Menus
{
    public class DemoMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<DemoResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(DemoMenus.Home, l["Menu:Home"], "~/"));

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "Campaigns",
                    l["Menu:Campaigns"],
                    icon: "fa fa-book"
                ).AddItem(
                    new ApplicationMenuItem(
                        "Campaigns.List",
                        l["Menu:CampaignList"],
                        url: "/"
                    )
                ).AddItem(
                    new ApplicationMenuItem(
                        "Campaigns.Create",
                        l["Menu:CampaignCreate"],
                        url: "/EmailManager"
                    )
                )
            );
        }
    }
}
