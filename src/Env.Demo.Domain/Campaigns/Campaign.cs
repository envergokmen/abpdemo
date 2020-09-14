using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Env.Demo.Campaigns
{
    public class Campaign : AuditedAggregateRoot<Guid>
    {
        public string Subject { get; set; }
        public int ItemCount { get; set; }

    }
}
