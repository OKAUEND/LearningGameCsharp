using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Char
{
    class CharBase
    {
        //protected string CharName { get; set; }
        protected BaseInfo.Playeable CharDate;
        protected Numeric.ExNumber HP;
        protected Numeric.ExNumber MP;
        protected int ATK;
        protected int DEF;
        protected float DEFBUFF;
        public List<string> UseSkillList { get; set; }
        public List<Skill.SkillBase> MySkill { get; set; } = new List<Skill.SkillBase>();

        public CharBase(string SetName, string SetRace, string SetSex, int SetHP, int SetATK, int SetDEF)
        {
            CharDate = new BaseInfo.Playeable(SetName, SetRace, SetSex);
            HP = new Numeric.ExNumber(SetHP, 0, SetHP);
            MP = new Numeric.ExNumber(0, 0, 0);
            ATK = SetATK;
            DEF = SetDEF;
        }

        public void OnTurn(CharBase Enemy)
        {

        }

        public void Attack(CharBase Enemy)
        {
            DamegeShow(DamageCalculation(Enemy, 0), Enemy.CharDate.GetName(),"通常攻撃");
        }

        public void SkillAttack(CharBase Enemy,int choice)
        {
            var skill = MySkill[choice];
            DamegeShow(DamageCalculation(Enemy, 0), Enemy.CharDate.GetName(), "通常攻撃");
        }

        private Double DamageCalculation(CharBase Enemy,Double AttackPoint)
        {
            var Player = ATK * AttackPoint;
            var EnemyDefence = (Enemy.DEF * Enemy.DEFBUFF);
            var Damage = (Player - EnemyDefence);
            Enemy.HP.Set(Enemy.HP.Get() - Damage);
            return Damage;
        }

        private void DamegeShow(Double Damege, string EnemyName ,string Attack)
        {
            Console.WriteLine($"{CharDate.GetName()} + の{Attack}！");
            Console.WriteLine(EnemyName + "に" + Damege.ToString() + "のダメージ！");
        }

        public void Guard()
        {
            Console.WriteLine(CharDate.GetName() + "は身を守った！");
            DEFBUFF = 2;
        }

        public void Heal()
        {
            Console.WriteLine(CharDate.GetName() + "は回復をした！");
            HP.Set(HP.Get() + 200);
            Console.WriteLine(Info());
        }

        public string Info()
        {
            return (CharDate.GetName() + "のHP：" + HP.Get().ToString());
        }

        public void TurnReset()
        {
            DEFBUFF = 0;
        }

        public Boolean IsState()
        {
            return HP.IsEmpty();
        }

        public void SetUseSkill(Dictionary<string, Skill.SkillBase> skilldic)
        {
            foreach (string SkillID in UseSkillList)
            {
                MySkill.Add(skilldic[SkillID]);
            }
        }
    }
}
