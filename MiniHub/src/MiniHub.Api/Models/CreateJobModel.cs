using MiniHub.Services.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniHub.Api.Models
{
    public class CreateJobModel
    {
        [Required]
        public string Reference { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Product { get; set; }

        internal CreateJobDto ConvertToDto()
        {
            return new CreateJobDto
            {
                Reference = Reference,
                Address = Address,
                Product = Product
            };
        }
    }
}