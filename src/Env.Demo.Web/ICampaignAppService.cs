using Env.Demo.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Env.Demo
{
    public interface ICampaignAppService : IScopedDependency
    {
        Task<bool> SetCampaignItemStatus(bool isSent, Guid id);
        Task<List<Campaign>> GetCampaigns(int page = 1, int pageSize = 20, Expression<Func<Campaign, Guid>> orderBy = null);
    }
}