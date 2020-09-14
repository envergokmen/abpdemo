﻿using Env.Demo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Env.Demo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DemoController : AbpController
    {
        protected DemoController()
        {
            LocalizationResource = typeof(DemoResource);
        }
    }
}