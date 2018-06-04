using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningGameCsharp.Char.Skill
{
    public class Attack : SkillBase
    {
        public Attack(string ID, string name, IEnumerable<string> TypeList, string ration, int costAP, int twiceAP) : base(ID,name,TypeList,ration,costAP,twiceAP) 
        {
        }

        public override string Action()
        {
            
            var temp = SkillRation;
            return "攻撃";
        }
    }
}