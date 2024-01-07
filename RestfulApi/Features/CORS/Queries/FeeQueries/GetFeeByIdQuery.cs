namespace RestfulApi.Features.CORS.Queries.FeeQueries
{
    public class GetFeeByIdQuery
    {
        public int Id { get; set; }

        public GetFeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
