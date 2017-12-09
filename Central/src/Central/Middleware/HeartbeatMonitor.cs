using Refit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Central.Api.Middleware
{
    public class HeartbeatMonitor
    {
        public async Task PollAsync(CancellationToken cancellationToken)
        {
            var hubIdBase = "192.168.99.100";

            var hubs = new string[] { "9080" };

            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var hub in hubs)
                {
                    var huburl = string.Concat(hubIdBase, ":", hub);

                    var hubApi = RestService.For<IHubApi>(huburl);

                    var response = await hubApi.IsHubAlive();
                }

                await Task.Delay(1000);
            }
        }
    }

    public interface IHubApi
    {
        [Post("/job")]
        Task<HttpResponseMessage> IsHubAlive();
    }
}