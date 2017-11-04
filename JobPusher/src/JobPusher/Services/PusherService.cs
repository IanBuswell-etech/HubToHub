using JobPusher.Data;
using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using JobPusher.Services.Dtos;

namespace JobPusher.Services
{
    public class PusherService : IPusherService
    {
        private HttpClient _httpClient;
        private readonly ApplicationSettings _settings;

        public PusherService(HttpClient httpClient, IOptions<ApplicationSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public bool PushJob(CreateDto dto)
        {
            var job = MapCreateDtoToJob(dto);

            var endPoint = _settings.IntegrationPointUrl;

            // new CreateRequest!

            return false;
        }

        public bool UpdateJob(UpdateDto dto)
        {
            // new Update Request!

            throw new NotImplementedException();
        }

        public bool CancelJob(Guid id)
        {
            // new Cancellation Request!
            throw new NotImplementedException();
        }

        private Job MapCreateDtoToJob(CreateDto model)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Ref = model.Ref,
                Address = model.Address,
                Product = model.Product
            };

            return job;
        }
    }
}
