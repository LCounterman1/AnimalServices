using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class Registry
    {
        [Key]
        public int RegistryId { get; set; }
        [Required]
        public DateTime AptDate { get; set; }
        [Required]
        public DateTime AptTime { get; set; }
        [ForeignKey(nameof(Animal))]
        public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
