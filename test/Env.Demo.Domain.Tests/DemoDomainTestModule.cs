using Env.Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Env.Demo
{
    [DependsOn(
        typeof(DemoEntityFrameworkCoreTestModule)
        )]
    public class DemoDomainTestModule : AbpModule
    {

    }
}