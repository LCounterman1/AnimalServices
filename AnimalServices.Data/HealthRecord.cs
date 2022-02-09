using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum RecordType { vaccine, shot, booster }
    public class HealthRecord
    {
        [Key]
        public int HealthRecordId { get; set; }
        [Required]
        public RecordType RecordType { get; set; }
        [Required]
        public DateTime DateGiven { get; set; }
        [Required]
        public string FrequencyNeeded { get; set; }
        public string Comments { get; set; }
        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
