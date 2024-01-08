namespace RestfulApi.Features.CORS.Commands.DoctorCommands
{
    public class RemoveDoctorCommand
    {
        public int Id { get; set; }

        public RemoveDoctorCommand(int id)
        {
            Id = id;
        }
    }
}
