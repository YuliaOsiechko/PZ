using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Stuffs = new HashSet<Stuff>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Stuff> Stuffs { get; set; }
    }
}
