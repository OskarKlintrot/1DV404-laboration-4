using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Gymnast
    {
        public string Name { get; private set; }
        public Dictionary<Sport, double> Sports { get; private set; }

        public Gymnast(string name)
        {
            Sports = new Dictionary<Sport, double>();
            Name = name;

            foreach (Sport sport in Enum.GetValues(typeof(Sport)))
            {
                Sports.Add(sport, 0);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
