using System;
using JobPusher.Services.Dtos;

namespace JobPusher.Services
{
    public interface IPusherService
    {
        bool PushJob(CreateDto dto);

        bool UpdateJob(UpdateDto dto);

        bool CancelJob(Guid id);

        bool TestConnection();
    }
}