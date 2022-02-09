using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.HealthRecord
{
    public class HealthRecordDetail
    {
        public int HealthRecordId { get; set; }
        public int AnimalId { get; set; }
        public RecordType RecordType { get; set; }
        public DateTime DateGiven { get; set; }
        public string FrequencyNeeded { get; set; }
        public string Comments { get; set; }
    }
}
