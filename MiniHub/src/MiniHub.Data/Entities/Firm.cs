using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Data.Entities
{
    public class Firm : EntityBase
    {
        public bool IsExternal { get; set; }

        public string Reference { get; set; }

        // Compound of that minihub's id + a firm ref?
        public string ExternalHubId { get; set; }
    }
}