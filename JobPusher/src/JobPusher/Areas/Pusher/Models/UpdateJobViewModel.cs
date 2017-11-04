using JobPusher.Services.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobPusher.Areas.Pusher.Models
{
    public class UpdateJobViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Ref { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Product { get; set; }

        public UpdateDto ConvertToDto()
        {
            return new UpdateDto
            {
                Id = Id,
                Ref = Ref,
                Address = Address,
                Product = Product
            };
        }
    }
}
