using JobPusher.Services.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobPusher.Areas.Pusher.Models
{
    public class CancelJobViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public Guid Id { get; set; }
    }
}
