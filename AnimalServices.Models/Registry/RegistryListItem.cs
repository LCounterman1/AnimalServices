using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Registry
{
    public class RegistryListItem
    {
        public int RegistryId { get; set; }
        public DateTime AptDate { get; set; }
        public DateTime AptTime { get; set; }
        public int ServiceId { get; set; }
        public ServiceType TypeOfService { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
    }
}
