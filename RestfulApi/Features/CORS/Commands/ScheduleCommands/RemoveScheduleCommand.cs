namespace RestfulApi.Features.CORS.Commands.ScheduleCommands
{
    public class RemoveScheduleCommand
    {
        public int Id { get; set; }

        public RemoveScheduleCommand(int id)
        {
            Id = id;
        }
    }
}
