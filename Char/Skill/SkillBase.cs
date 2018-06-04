using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningGameCsharp.Char.Skill
{
    public abstract class SkillBase
    {
        public string SkillID { get; set; }
        public string SkillName { get; set; }
        public Type SkillType { get; set; }
        public string SkillTypeShowTrans { get; set; }
        public Double SkillRation { get; set; }
        public int SkillCostAP { get; set; }
        public int SkillTwoiceCostAP { get; set; }
        public int SkillCostM { get; set; }

        public SkillBase(string ID, string name, IEnumerable<string> TypeList, string ration, int costAP, int twiceAP)
        {
            SkillID = ID;
            SkillName = name;
            SetType(TypeList);
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

        private void SetType(IEnumerable<string> tyep)
        {
            Type SetType = new Type();
            string typeTrans = string.Empty;
            foreach (string skill in tyep)
            {
                 switch(skill)
                {
                    case "Attack":
                        SetType |= Type.Attack;
                        typeTrans = "攻撃";
                        break;
                    case "Defense":
                        SetType |= Type.Defense;
                        typeTrans = "防御";
                        break;
                    case "Buff":
                        SetType |= Type.Buff;
                        typeTrans = "バフ";
                        break;
                    case "AllBuff":
                        SetType |= Type.AllBuff;
                        typeTrans = "全体バフ";
                        break;
                    case "Debuff":
                        SetType |= Type.Debuff;
                        typeTrans = "デバフ";
                        break;
                    case "AllDebuff":
                        SetType |= Type.AllDebuff;
                        typeTrans = "全体デバフ";
                        break;
                    default:
                        SetType |= Type.Other;
                        typeTrans = "その他";
                        break;
                }
            }
            SkillType |= SetType;
            SkillTypeShowTrans = typeTrans;
        }

        
        public string GetID()
        {
            return SkillID;
        }

        public virtual string Action()
        {
            return "何もしない";
        }
    }
}