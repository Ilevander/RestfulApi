using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Results.FeeResult
{
    public class GetFeeByIdQueryResult
    {
        public int FeeId { get; set; }
        public decimal? Amount { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
