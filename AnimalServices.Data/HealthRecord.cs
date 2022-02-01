using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class HealthRecord
    {
        public int ID { get; set; }
        public HealthRecord HealthRecord { get; set; }
        public DateTime DateGiven { get; set; }
        public varchar FrequencyNeeded { get; set; }
        public varchar Comments { get; set; }
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
