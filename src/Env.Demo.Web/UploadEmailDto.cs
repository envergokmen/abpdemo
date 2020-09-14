using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Env.Demo.Web
{
    public class UploadEmailDto
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        [TextArea(Rows = 4)]
        public string ContentBody { get; set; }

        [Required]
        public IFormFile EmailFile { get; set; }


    }
}
