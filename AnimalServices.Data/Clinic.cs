using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum ClinicType { smallAnimal, largeAnimal}
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public ClinicType ClinicType { get; set; }
        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        [ForeignKey(nameof(HealthRecord))]
        public int HealthRecordId { get; set; }
        public virtual HealthRecord HealthRecord { get; set; }
    }
}
