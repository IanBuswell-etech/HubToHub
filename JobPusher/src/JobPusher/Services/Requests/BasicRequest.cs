using JobPusher.Data;

namespace JobPusher.Services.Requests
{
    public class BasicRequest : PusherRequest
    {
        public Job Job { get; set; }
    }
}