using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastikLigan
{
    public class Team : ITeam
    {
        public string Name { get; private set; }
        public List<IGymnast> Gymnasts { get; private set; }

        public Team(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException();
            Name = name;
            Gymnasts = new List<IGymnast>();
        }

        public void AddGymnast(IGymnast gymnast)
        {
            Gymnasts.Add(gymnast);
        }
    }
}