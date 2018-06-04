using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Char.Skill
{
    public class Buff : SkillBase
    {
        public Buff(string ID, string name, IEnumerable<string> TypeList, string ration, int costAP, int twiceAP) : base(ID, name, TypeList, ration, costAP, twiceAP)
        {
        }
    }
}
