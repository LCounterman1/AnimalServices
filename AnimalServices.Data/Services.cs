using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class Services
    {
        public int ID { get; set; }
        public Service Service { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public int ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }

    }
}
