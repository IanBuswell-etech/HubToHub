using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;
using System;

namespace MiniHub.Services
{
    public interface IJobService
    {
        Job GetJobViaId(Guid id);

        Job CreateNewJob(CreateJobDto dto);

        Job GetJobViaReference(string reference);
    }
}