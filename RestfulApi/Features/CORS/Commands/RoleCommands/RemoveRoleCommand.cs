namespace RestfulApi.Features.CORS.Commands.RoleCommands
{
    public class RemoveRoleCommand
    {
        public int Id { get; set; }

        public RemoveRoleCommand(int id)
        {
            Id = id;
        }
    }
}
