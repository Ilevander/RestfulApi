namespace RestfulApi.Features.CORS.Commands.AppointmentCommands
{
    public class RemoveAppointmentCommand
    {
        public int Id { get; set; }

        public RemoveAppointmentCommand(int id)
        {
            Id = id;
        }
    }
}
