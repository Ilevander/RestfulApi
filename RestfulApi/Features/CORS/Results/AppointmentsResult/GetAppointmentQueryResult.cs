using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Results.AppointmentsResult
{
    public class GetAppointmentQueryResult
    {
        public int Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Description { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
