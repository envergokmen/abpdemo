using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Env.Demo.Dtos
{

    public class UsernameMailDto
    {
        [Required]
        public string name { get; set; }

        [EmailAddress]
        [Required]
        public string emailaddress { get; set; }
    } 
}
