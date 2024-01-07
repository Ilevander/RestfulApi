using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
