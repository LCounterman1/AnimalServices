using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Registry
{
    public class RegistryCreate
    {
        public DateTime AptDate { get; set; }
        public DateTime AptTime { get; set; }
        public int AnimalID { get; set; }
        public int ClinicID { get; set; }
    }
}
