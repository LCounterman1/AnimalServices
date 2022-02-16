using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Services
{
    public class ServiceCreate
    {
        public ServiceType ServiceType { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        public int ClinicId { get; set; }
    }
}
