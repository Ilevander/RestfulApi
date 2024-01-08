using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.ClinicCommands
{
    public class CreateClinicCommand
    {
        public string? ClinicName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
