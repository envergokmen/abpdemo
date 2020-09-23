using System;
using System.Collections.Generic;
using System.Text;

namespace Env.Demo.Dtos
{
    public class CampaignDto
    {
        public int TotalCampaignCount { get; set; }
        public string Subject { get; set; }
        public int ItemCount { get; set; }
        public int SentItemCount { get; set; }
        public double PercentSent  =>  Math.Round(((ItemCount == 0) ? 100d : (double)SentItemCount / (double)ItemCount) *100,2);
    }

    public class PagedCampaignDto 
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public long TotalPage => PageSize == 0 || TotalItem == 0 ? 0 : TotalItem % PageSize > 0 ? TotalItem / PageSize + 1 : TotalItem / PageSize;

        public string Order = "Id desc";

        public long TotalItem { get; set; }

        public List<CampaignDto> Campaigns { get; set; }
    }
}
