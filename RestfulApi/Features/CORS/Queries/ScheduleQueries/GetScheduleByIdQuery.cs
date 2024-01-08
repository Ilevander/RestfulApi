namespace RestfulApi.Features.CORS.Queries.ScheduleQueries
{
    public class GetScheduleByIdQuery
    {
        public int Id { get; set; }

        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
