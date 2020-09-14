using System;
using System.Collections.Generic;
using System.Text;

namespace Env.Demo.Email
{
    public class EmailSendingArgs
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid ItemId { get; set; }
        public Guid campaignId { get; set; }

    }
}
