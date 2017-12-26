using System;
using System.Collections.Generic;
using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;
using MiniHub.Data.LiteDb;
using System.Linq;
using MiniHub.MessagePusher;

namespace MiniHub.Services
{
    public class JobService : IJobService
    {
        private readonly DatabaseContext _databaseContext;

        public JobService(DatabaseContext db, IMessagePusher pusher)
        {
            _databaseContext = db;
        }
        
        public Job GetJobViaId(Guid id)
        {
            var foundItem = _databaseContext.Find<Job>(x => x.Id ==  id);

            return foundItem.FirstOrDefault();
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

        public List<Job> GetAllJobs()
        {
            var jobList = new List<Job>();

            try
            {
                var jobs = _databaseContext.GetList<Job>();

                jobList = jobs.ToList();
            }
            catch (Exception e)
            {
                // DO NOTHING
            }

            return jobList;
        }

        public bool DeleteJob(string jobRef)
        {
            var job = GetJobViaReference(jobRef);

            if (job == null)
            {
                return false;
            }

            try
            {
                _databaseContext.DeleteFromDb<Job>(x => x.Reference == jobRef);
            }
            catch (Exception e)
            {
                // OH NOES
            }

            return true;
        }

        public bool AllocateJob(Guid jobId, Guid? firmId)
        {
            var job = GetJobViaId(jobId);

            if (job == null)
            {
                return false;
            }

            // Get random firm if none supplied
            if (firmId == null)
            {
                var firms = _databaseContext.GetList<Firm>();

                if (firms.Count() == 0)
                {
                    firmId = Guid.NewGuid();
                }
                else
                {
                    var count = firms.OrderBy(x => x.Id);
                    var firm = count.First();
                    firmId = firm.Id;
                }
            }

            job.AllocatedFirmId = firmId;

            var result =_databaseContext.UdpdateSomethingInDb(job);

            return result;
        }
    }
}
