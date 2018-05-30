using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningGameCsharp.Char.Skill
{
    class SkillBase
    {
        private string SkillID;
        private string SkillName;
        private string SkillType;
        private string Type;
        private decimal SkillRation;
        private int SkillCostAP;
        private int SkillTwoiceCostAP;
        private int SkillCostMP;

        public SkillBase(string ID, string name,string type ,string ration,int costAP,int twiceAP)
        {
            SkillID = ID;
            SkillName = name;
            SkillRation = decimal.Parse(ration);
            SkillCostAP = costAP;
        }
    }
}