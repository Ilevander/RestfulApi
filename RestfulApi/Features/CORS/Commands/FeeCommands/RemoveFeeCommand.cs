namespace RestfulApi.Features.CORS.Commands.FeeCommands
{
    public class RemoveFeeCommand
    {
        public int Id { get; set; }

        public RemoveFeeCommand(int id)
        {
            Id = id;
        }
    }
}
