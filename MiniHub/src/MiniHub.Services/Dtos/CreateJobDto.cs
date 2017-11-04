using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Services.Dtos
{
    public class CreateJobDto
    {
        public string Reference { get; set; }

        public string Address { get; set; }

        public string Product { get; set; }
    }
}
