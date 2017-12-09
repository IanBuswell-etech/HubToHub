using Central.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Central.Api.Services
{
    public class JobService
    {
        private readonly IDataService _dataService;

        public JobService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool ReceiveUpdate(JobMessage message)
        {
            return _dataService.AddItem(message);
        }

        public List<JobMessage> GetJobMessagesToProcess(int jobId)
        {
            return new List<JobMessage>();
        }
    }
}
