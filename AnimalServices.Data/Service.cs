using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum ServiceType { vaccines, grooming, surgical, dental}
    public class Service
    {
        public int ID { get; set; }
        public ServiceType ServiceType { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public int ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }

    }
}
