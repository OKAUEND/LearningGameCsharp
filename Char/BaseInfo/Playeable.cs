using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Char.BaseInfo
{
    public class Playeable
    {
        private string Name { get; set; }
        private string Race { get; set; }
        private string Sex { get; set; }

        public Playeable(string SetName ,string SetRace ,string SetSex)
        {
            Name = SetName;
            Race = SetRace;
            Sex = SetSex;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
