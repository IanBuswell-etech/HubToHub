using System;

namespace Central.Data.Entities
{
    public class HubRegistration
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public bool IsActive { get; set; }
    }
}