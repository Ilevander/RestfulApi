namespace RestfulApi.Features.CORS.Queries.UserQueries
{
    public class GetUserByIdQuery
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
