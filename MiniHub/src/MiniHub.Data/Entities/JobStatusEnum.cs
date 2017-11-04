namespace MiniHub.Data.Entities
{
    public enum JobStatusEnum
    {
        New = 1000,
        Allocated = 2000,
        Assigned = 2500,
        Booked = 3000,
        Completed = 4000,
        Cancelled = 9999
    }
}