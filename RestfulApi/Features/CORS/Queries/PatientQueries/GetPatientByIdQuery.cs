namespace RestfulApi.Features.CORS.Queries.PatientQueries
{
    public class GetPatientByIdQuery
    {
        public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
