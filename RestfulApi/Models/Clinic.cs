using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
