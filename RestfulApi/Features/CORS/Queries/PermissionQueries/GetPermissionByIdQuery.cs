namespace RestfulApi.Features.CORS.Queries.PermissionQueries
{
    public class GetPermissionByIdQuery
    {
        public int Id { get; set; }

        public GetPermissionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
