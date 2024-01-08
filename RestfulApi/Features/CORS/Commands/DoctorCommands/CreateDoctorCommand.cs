using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.DoctorCommands
{
    public class CreateDoctorCommand
    {
        public string? DoctorName { get; set; }
        public string? Specialization { get; set; }
        public int? ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
