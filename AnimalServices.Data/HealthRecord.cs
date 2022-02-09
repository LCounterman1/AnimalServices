using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum RecordType { vaccine, shot, booster }
    public class HealthRecord
    {
  
        public int HealthRecordId { get; set; }
        public RecordType RecordType { get; set; }
        public DateTime DateGiven { get; set; }
        public string FrequencyNeeded { get; set; }
        public string Comments { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
