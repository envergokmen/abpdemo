using Env.Demo.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace Env.Demo
{
    public class EmailQueueRegistrationService : ApplicationService, ISingletonDependency
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public EmailQueueRegistrationService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }

        public async Task<bool> AddToEmailQueue(Guid campaignId, Guid itemId, string emailAddress, string subject, string contentbody)
        {
              await _backgroundJobManager.EnqueueAsync(
               new EmailSendingArgs
               {
                   EmailAddress = emailAddress,
                   Subject = subject,
                   Body = contentbody,
                   ItemId=itemId,
                   campaignId=campaignId
               }
           );

            return true;
            
           
        }
    }
}
