using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Commands.ClinicCommands
{
    public class UpdateClinicCommand
    {
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
