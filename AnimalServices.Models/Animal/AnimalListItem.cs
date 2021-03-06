using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Animal
{
    public class AnimalListItem
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
