using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Animal
{
    public class AnimalDetail
    {
        public string Name { get; set; }
        public Species Species { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Weight { get; set; }
        public string State { get; set; }
        public bool IsFood { get; set; }
        public bool IsBred { get; set; }
    }
}
