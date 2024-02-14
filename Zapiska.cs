using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paraAdaptivnayaverstka
{
    internal class Zapiska
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateVipol {  get; set; }

        public Zapiska(string name, string description, DateTime dateVipol)
        {
            Name = name;
            Description = description;
            DateVipol = dateVipol;
        }
    }
}
