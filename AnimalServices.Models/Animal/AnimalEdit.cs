using AnimalServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalServices.Models.Animal
{
    public class AnimalEdit
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string State { get; set; }
        public bool IsBred { get; set; }
    }
}
