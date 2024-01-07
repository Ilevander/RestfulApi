using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Results.BookingResult
{
    public class GetBookingQueryResult
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? PatientId { get; set; }
        public int? ClinicId { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
