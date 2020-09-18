using System;
using System.Collections.Generic;
using System.Text;

namespace Env.Demo.Dtos
{
    public class CampaignDto
    {
        public string Subject { get; set; }
        public int ItemCount { get; set; }
        public int SentItemCount { get; set; }
        public double PercentSent  =>  (SentItemCount == 0 || ItemCount == 0) ? 100d : SentItemCount / ItemCount;
    }
}
