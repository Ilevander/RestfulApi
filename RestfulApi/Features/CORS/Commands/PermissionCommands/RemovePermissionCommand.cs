namespace RestfulApi.Features.CORS.Commands.PermissionCommands
{
    public class RemovePermissionCommand
    {
        public int Id { get; set; }

        public RemovePermissionCommand(int id)
        {
            Id = id;
        }
    }
}
