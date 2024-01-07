using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.BookingCommands
{
    public class CreateBookingCommand
    {
        public DateTime? BookingDate { get; set; }
        public int? PatientId { get; set; }
        public int? ClinicId { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
