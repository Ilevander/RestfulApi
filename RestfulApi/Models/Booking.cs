using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? PatientId { get; set; }
        public int? ClinicId { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
