using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.FeeCommands
{
    public class CreateFeeCommand
    {
        public decimal? Amount { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
