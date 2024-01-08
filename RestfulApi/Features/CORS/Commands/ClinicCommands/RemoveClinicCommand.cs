namespace RestfulApi.Features.CORS.Commands.ClinicCommands
{
    public class RemoveClinicCommand
    {
        public int Id { get; set; }

        public RemoveClinicCommand(int id)
        {
            Id = id;
        }
    }
}
