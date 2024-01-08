using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.PatientCommands
{
    public class UpdatePatientCommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
