using JobPusher.Data;
using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using JobPusher.Services.Dtos;
using JobPusher.Services.Requests;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

            var endPoint = _settings.IntegrationPointUrl + "/job/createjob";

            var jobCreationRequest = new BasicRequest
            {
                PusherId = pusherId,
                Job = job
            };

            var payload = JsonConvert.SerializeObject(jobCreationRequest);

            HttpContent content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            
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

        public bool TestConnection()
        {
            var endPoint = _settings.IntegrationPointUrl + "/Test";

            var postTask = _httpClient.GetAsync(endPoint);

            postTask.Wait();

            var repsonse = postTask.Result;

            if (!repsonse.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        private Job MapCreateDtoToJob(CreateDto model)
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                Reference = model.Ref,
                Address = model.Address,
                Product = model.Product
            };

            return job;
        }
    }
}
