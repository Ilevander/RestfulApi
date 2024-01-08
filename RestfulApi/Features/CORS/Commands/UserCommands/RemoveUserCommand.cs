namespace RestfulApi.Features.CORS.Commands.UserCommands
{
    public class RemoveUserCommand
    {
        public int Id { get; set; }

        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}
