namespace RestfulApi.Features.CORS.Queries.DoctorQueries
{
    public class GetDoctorByIdQuery
    {
        public int Id { get; set; }

        public GetDoctorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
