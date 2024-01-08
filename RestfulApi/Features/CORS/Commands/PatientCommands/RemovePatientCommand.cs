namespace RestfulApi.Features.CORS.Commands.PatientCommands
{
    public class RemovePatientCommand
    {
        public int Id { get; set; }

        public RemovePatientCommand(int id)
        {
            Id = id;
        }
    }
}
