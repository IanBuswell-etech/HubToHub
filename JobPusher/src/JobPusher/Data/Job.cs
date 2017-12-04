using System;

namespace JobPusher.Data
{
    public class Job
    {
        public Guid Id { get; set; }

        public string Reference { get; set; }

        public string Address { get; set; }

        public string Product { get; set; }
    }
}