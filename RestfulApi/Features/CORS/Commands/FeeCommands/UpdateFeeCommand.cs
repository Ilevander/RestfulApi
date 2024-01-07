using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.FeeCommands
{
    public class UpdateFeeCommand
    {
        public int FeeId { get; set; }
        public decimal? Amount { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
