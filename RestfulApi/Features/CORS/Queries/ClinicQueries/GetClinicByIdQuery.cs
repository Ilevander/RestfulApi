namespace RestfulApi.Features.CORS.Queries.ClinicQueries
{
    public class GetClinicByIdQuery
    {
        public int Id { get; set; }

        public GetClinicByIdQuery(int id)
        {
            Id = id;
        }
    }
}
