using System;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;

namespace Env.TextTemplateModule
{
    [DependsOn(
     //...other dependencies
     typeof(AbpTextTemplatingModule) //Add the new module dependency
     )]
    public class EvnTextTemplateModule : AbpModule
    {

    }
}
