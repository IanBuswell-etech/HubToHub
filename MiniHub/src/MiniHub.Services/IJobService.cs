using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;
using System;
using System.Collections.Generic;

namespace MiniHub.Services
{
    public interface IJobService
    {
        Job GetJobViaId(Guid id);

        Job CreateNewJob(CreateJobDto dto);

        Job GetJobViaReference(string reference);

        List<Job> GetAllJobs();

        bool DeleteJob(string jobRef);
    }
}