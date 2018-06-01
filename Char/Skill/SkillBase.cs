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
        private Type SkillType;
        private Double SkillRation;
        private int HealRation;
        private int SkillCostAP;
        private int SkillTwoiceCostAP;
        private int SkillCostM;

        public SkillBase(string ID, string name, IEnumerable<string> TypeList, string ration, int healRA, int costAP, int twiceAP)
        {
            SkillID = ID;
            SkillName = name;
            SetType(TypeJudgment(TypeList));
            SkillRation = Double.Parse(ration);
            SkillCostAP = costAP;
            SkillTwoiceCostAP = twiceAP;
        }

        [Flags]
        public enum Type
        {
            //その他
            Other    = 1 << 0,
            //攻撃
            Attack   = 1 << 1,
            //防御
            Defense  = 1 << 2,
            //回復
            Heal     = 1 << 3,
            //バフ
            Buff     = 1 << 4,
            //全体バフ
            AllBuff  = 1 << 5,
            //デバフ
            Debuff   = 1 << 6,
            //全体デバフ
            AllDebuff = 1 << 7,
        }

        private void SetType(Type type) => SkillType |= type;

        private Type TypeJudgment(IEnumerable<string> tyep)
        {
            Type SetType = new Type();
            foreach (string skill in tyep)
            {
                 switch(skill)
                {
                    case "Attack":
                        SetType |= Type.Attack;
                        break;
                    case "Defense":
                        SetType |= Type.Defense;
                        break;
                    case "Buff":
                        SetType |= Type.Buff;
                        break;
                    case "AllBuff":
                        SetType |= Type.AllBuff;
                        break;
                    case "Debuff":
                        SetType |= Type.Debuff;
                        break;
                    case "AllDebuff":
                        SetType |= Type.AllDebuff;
                        break;
                    default:
                        SetType |= Type.Other;
                        break;
                }
            }

            return SetType;
        }

        
        public string GetID()
        {
            return SkillID;
        }

        public Dictionary<string, Char.Skill.SkillBase> SetSkill()
        {



            return null;
        }

    }
}