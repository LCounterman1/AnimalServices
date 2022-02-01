using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Data
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Animal Animal { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Weight { get; set; }
        public string State { get; set; }
        public bool IsFood { get; set; }
        public bool IsBred { get; set; }
    }
}
