﻿using System;
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
        protected Numeric.ExNumber HP ;
        protected Numeric.ExNumber MP ;
        protected Numeric.ExNumber ATK;
        protected Numeric.ExNumber DEF;
        protected float DEFBUFF;

        public CharBase(string SetName, string SetRace, string SetSex,int SetHP ,int SetATK,int SetDEF)
        {
            CharDate = new BaseInfo.Playeable(SetName, SetRace, SetSex);
            HP = new Numeric.ExNumber(SetHP,0, SetHP);
            MP = new Numeric.ExNumber(0, 0, 0);
            ATK = new Numeric.ExNumber(SetATK,0,SetATK);
            DEF = new Numeric.ExNumber(SetDEF, 0, SetDEF);
            DEFBUFF = 0;

        }

        public void Attack(CharBase @char)
        {
            var Damage = (ATK.Get() - (@char.DEF.Get() * @char.DEFBUFF));
            DamegeShow(Damage,@char.CharDate.GetName());
            @char.HP.Set(@char.HP.Get() - Damage);
        }

        private void DamegeShow(float Damege,string EnemyName)
        {
            Console.WriteLine(CharDate.GetName() + "の攻撃！");
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
            return  (CharDate.GetName() + "のHP：" + HP.Get().ToString());
        }

        public void TurnReset()
        {
            DEFBUFF = 0;
        }

        public Boolean IsState()
        {
            return HP.IsEmpty();
        }
    }
}
