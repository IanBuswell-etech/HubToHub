using JobPusher.Data;
using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using JobPusher.Services.Dtos;
using JobPusher.Services.Requests;
using Newtonsoft.Json;

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

            var pusherId = _settings.PusherIdentifier;

            var endPoint = _settings.IntegrationPointUrl;

            var jobCreationRequest = new BasicRequest
            {
                PusherId = pusherId,
                Job = job
            };

            var payload = JsonConvert.SerializeObject(jobCreationRequest);

            HttpContent content = new StringContent(payload);
            var postTask = _httpClient.PostAsync(endPoint, content);

            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

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
