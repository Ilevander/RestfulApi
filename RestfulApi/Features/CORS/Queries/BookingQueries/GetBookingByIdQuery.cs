namespace RestfulApi.Features.CORS.Queries.BookingQueries
{
    public class GetBookingByIdQuery
    {
        public int Id { get; set; }

        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
