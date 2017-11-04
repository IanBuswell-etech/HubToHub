using System;
using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;
using MiniHub.Data.LiteDb;
using System.Linq;

namespace MiniHub.Services
{
    public class JobService : IJobService
    {
        private readonly DatabaseContext _databaseContext;

        public JobService(DatabaseContext db)
        {
            _databaseContext = db;
        }
        
        public Job GetJobViaId(Guid id)
        {
            return new Job
            {
                Id = id,
                Reference = "I'mma fake job"
            };
        }

        public Job GetJobViaReference(string reference)
        {
            var foundItem = _databaseContext.Find<Job>(x => x.Reference == reference);

            return foundItem.FirstOrDefault();
        }

        public Job CreateNewJob(CreateJobDto dto)
        {
            var newJob = new Job
            {
                Id = Guid.NewGuid(),
                Reference = dto.Reference,
                Address = dto.Address,
                Product = dto.Product,
                Status = JobStatusEnum.New
            };

            _databaseContext.PushSomethingIntoDb(newJob);
            
            return newJob;
        }
    }
}
