using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class Registry
    {
        public int ID { get; set; }
        public DateTime AptDate { get; set; }
        public DateTime AptTime { get; set; }
        public varchar Place { get; set; }
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
        public int ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
