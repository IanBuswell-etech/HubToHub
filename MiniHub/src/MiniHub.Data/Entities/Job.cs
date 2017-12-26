using System;

namespace MiniHub.Data.Entities
{
    public class Job : EntityBase
    {
        public string Reference { get; set; }

        public string Address { get; set; }

        public string Product { get; set; }

        public JobStatusEnum Status {get; set; }

        public Guid? AllocatedFirmId { get; set; }

        public Guid OwningHubId { get; set; }
    }
}