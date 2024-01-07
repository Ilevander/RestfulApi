using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Fees = new HashSet<Fee>();
            Schedules = new HashSet<Schedule>();
        }

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Specialization { get; set; }
        public int? ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
