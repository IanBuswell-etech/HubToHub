using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniHub.Api.Models
{
    public class CreateRequest
    {
        public string PusherId { get; set; }

        public CreateJobModel Job { get; set; }
    }
}
