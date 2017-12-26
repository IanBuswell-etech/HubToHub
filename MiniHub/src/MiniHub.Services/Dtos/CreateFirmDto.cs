namespace MiniHub.Services.Dtos
{
    public class CreateFirmDto
    {
        public string Reference { get; set; }
        
        public bool IsExternal { get; set; }

        public string ExternalHubId { get; set; }
    }
}