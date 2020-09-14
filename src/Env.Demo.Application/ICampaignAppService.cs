using System;
using System.Threading.Tasks;

namespace Env.Demo
{
    public interface ICampaignAppService
    {
        Task<bool> SetCampaignItemStatus(bool isSent, Guid id);
    }
}