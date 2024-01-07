namespace RestfulApi.Features.CORS.Queries.AppointmentQueries
{
    public class GetAppointmentByIdQuery
    {
        public GetAppointmentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
