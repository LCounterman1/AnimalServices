using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Registry
{
    public class RegistryEdit
    {
        public int RegistryId { get; set; }
        public DateTime AptDate { get; set; }
        public DateTime AptTime { get; set; }
    }
}
