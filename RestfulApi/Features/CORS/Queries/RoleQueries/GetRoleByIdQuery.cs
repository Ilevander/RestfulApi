namespace RestfulApi.Features.CORS.Queries.RoleQueries
{
    public class GetRoleByIdQuery
    {
        public int Id { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
