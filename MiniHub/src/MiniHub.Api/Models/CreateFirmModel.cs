using MiniHub.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MiniHub.Api.Models
{
    public class CreateFirmModel
    {
        [Required]
        public string Reference { get; set; }

        public bool IsExternal { get; set; }

        public string ExternalHubId { get; set; }

        internal CreateFirmDto ConvertToDto()
        {
            return new CreateFirmDto
            {
                Reference = Reference,
                IsExternal = IsExternal,
                ExternalHubId = ExternalHubId
            };
        }
    }
}