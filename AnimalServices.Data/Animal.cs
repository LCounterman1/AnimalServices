using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public enum Species { cat, dog, chicken, horse, goat, rabbit }
    public class Animal
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Species Species { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public bool IsFood { get; set; }
        [Required]
        public bool IsBred { get; set; }
    }
}
