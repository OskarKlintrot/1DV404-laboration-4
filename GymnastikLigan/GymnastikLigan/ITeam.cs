using System.Collections.Generic;

namespace GymnastikLigan
{
    public interface ITeam
    {
        List<IGymnast> Gymnasts { get; }
        string Name { get; }

        void AddGymnast(IGymnast gymnast);
    }
}