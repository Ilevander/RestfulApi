using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Results.ClinicResult
{
    public class GetClinicByIdQueryResult
    {
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
