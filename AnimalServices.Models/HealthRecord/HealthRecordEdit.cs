using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.HealthRecord
{
    public class HealthRecordEdit
    {
        public int HealthRecordId { get; set; }
        public int AnimalId { get; set; }
        public  string AnimalName { get; set; }
        public string Comments { get; set; }
    }
}
