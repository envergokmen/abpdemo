using System;
using System.Collections.Generic;
using System.Text;
using Env.Demo.Localization;
using Volo.Abp.Application.Services;

namespace Env.Demo
{
    /* Inherit your application services from this class.
     */
    public abstract class DemoAppService : ApplicationService
    {
        protected DemoAppService()
        {
            LocalizationResource = typeof(DemoResource);
        }
    }
}
