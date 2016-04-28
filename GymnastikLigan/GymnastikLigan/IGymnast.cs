using System.Collections.Generic;

namespace GymnastikLigan
{
    public interface IGymnast
    {
        string Name { get; }
        Dictionary<Sport, double> Sports { get; }
    }
}