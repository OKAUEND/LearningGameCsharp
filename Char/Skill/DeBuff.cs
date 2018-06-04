using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Char.Skill
{
    public class DeBuff :SkillBase
    {
        public DeBuff(string ID, string name, IEnumerable<string> TypeList, string ration, int costAP, int twiceAP) : base(ID, name, TypeList, ration, costAP, twiceAP)
        {
        }
    }
}
