using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Env.Demo.Campaigns
{
    public class CampaignItem : AuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsSent { get; set; }

        public Guid CampaignId { get; set; }
    }
}
