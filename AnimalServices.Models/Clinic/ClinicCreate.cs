using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Clinic
{
    public class ClinicCreate
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ClinicType ClinicType { get; set; }
    }
}
