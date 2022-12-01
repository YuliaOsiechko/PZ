using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Stuff
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
