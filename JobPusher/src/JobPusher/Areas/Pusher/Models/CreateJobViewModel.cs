using JobPusher.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace JobPusher.Areas.Pusher.Models
{
    public class CreateJobViewModel
    {
        [Required]
        public string Ref { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Product { get; set; }

        public CreateDto ConvertToDto()
        {
            return new CreateDto
            {
                Ref = Ref,
                Address = Address,
                Product = Product
            };
        }
    }
}
