﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Env.Demo.Dtos;
using Env.Demo.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using TextTemplateDemo.Demos.Hello;
using Volo.Abp;
using Volo.Abp.TextTemplating;

namespace Env.Demo.Web.Pages.EmailManager
{
    public class IndexModel : PageModel
    {

        private MyCampaignCreationService uploadService;

        private IStringLocalizer<DemoResource> L;
        private IWebHostEnvironment environment;


        public IndexModel(IWebHostEnvironment _environment, MyCampaignCreationService _uploadService, IStringLocalizer<DemoResource> _L)
        {
            L = _L;
            uploadService = _uploadService;
            environment = _environment;
        }

        public async Task OnGet()
        {

            
        }

        [BindProperty]
        public UploadEmailDto UploadDto { get; set; }
        public async Task OnPost()
        {
            var emails = await uploadService.Upload(UploadDto);
            await uploadService.AddToQueue(emails, UploadDto);

            Redirect("/");

        }

 




    }
}
