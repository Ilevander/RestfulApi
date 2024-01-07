using System;
using System.Collections.Generic;

namespace RestfulApi.Models
{
    public partial class Fee
    {
        public int FeeId { get; set; }
        public decimal? Amount { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
