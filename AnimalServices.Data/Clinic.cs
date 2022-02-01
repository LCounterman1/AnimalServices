using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class Clinic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public varchar Address { get; set; }
        public Clinic Clinic { get; set; }
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
        public int HealthRecordID { get; set; }
        public virtual HealthRecord HealthRecord { get; set; }
    }
}
