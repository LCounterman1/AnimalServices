using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum ServiceType { vaccines, grooming, surgical, dental}
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; }
        public int Price { get; set; }
        public int Length { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

    }
}
