using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            var AllSkill = SetSkill();

            var Djeeta = new Char.CharBase("ジータ", "ヒューマン", "女", 500, 20, 2);
            var DjeetaUseSkill = new List<string>
            {
                "001",
                "002",
                "003"
            };
            Djeeta.SetUseSkilInfo(DjeetaUseSkill);
            Djeeta.SetUseSkill(AllSkill);
            var Enemy = new Char.CharBase("コキュートス", "エネミー", "-", 1000, 40, 5);

            var Random = new Random();
            int BehaviorSelection = 0;



            Boolean Game = false;
            do
            {
                LineView();
                Console.WriteLine("あなたのターンです。");
                Console.WriteLine(Djeeta.Info());
                Djeeta.TurnReset();
                Console.WriteLine("行動を入力してください / 1:攻撃 / 2:防御 / 3:回復");
                BehaviorSelection = InputLine();
                ActionBranch(Djeeta, Enemy, BehaviorSelection);

                LineView();

                Console.WriteLine("敵のターンです。");
                Console.WriteLine(Enemy.Info());
                Enemy.TurnReset();
                ActionBranch(Enemy, Djeeta, Random.Next(1, 3));

                Game = Djeeta.IsState();
                Game = Enemy.IsState();
            }
            while (!Game);

        }

        private static void ActionBranch(Char.CharBase @char, Char.CharBase Enemy, int Selection)
        {
            switch (Selection)
            {
                case 1:
                    @char.Attack(Enemy);
                    break;
                case 2:
                    @char.Guard();
                    break;
                case 3:
                    @char.Heal();
                    break;
            }
        }

        private static int InputLine ()
        {
            Boolean Loop = false;
            string InputKey = string.Empty;
            int Num = 0;
            while (!Loop) 
            {
                InputKey = Console.ReadLine();
                Loop = int.TryParse(InputKey, out Num);
                if (Loop == false)
                {
                    Console.WriteLine("数値を入力してください / 1:攻撃 / 2:防御 / 3:回復");
                    continue;
                }
                else if (Num > 3)
                {
                    Console.WriteLine("(1～3)で入力してください / 1:攻撃 / 2:防御 / 3:回復");
                    Loop = false;
                    continue;
                }
            }
            return Num;
        }

        private static Dictionary<string, Char.Skill.SkillBase> SetSkill()
        {

            var SkillList = new List<Char.Skill.SkillBase>
            {
                new Char.Skill.SkillBase("001", "テンペスト・ブレード", CreateList("Attack"), "1.2", 0, 1, 2),
                new Char.Skill.SkillBase("002", "レイジI", CreateList("Buff"), "1.2", 0, 2, 3),
                new Char.Skill.SkillBase("003", "ファランクスI", CreateList("Defence"), "50", 0, 3, 4),
                new Char.Skill.SkillBase("004", "ヒールI", CreateList("Heal"), "0", 200, 3, 4)
            };

            Dictionary<string,Char.Skill.SkillBase> SkillDate = new Dictionary<string,Char.Skill.SkillBase>();
            foreach(var skill in SkillList)
            {
                SkillDate.Add(key: skill.SkillID, value: skill);
            }
            return SkillDate;
           
        }

        private static List<string> CreateList(string TypeOne)
        {
            var TypeList = new List<string> { TypeOne};
            return TypeList;
                
        }

        private static void LineView()
        {
            Console.WriteLine("--------------------------------------------------------");
        }

        private static Boolean IsEND(Char.CharBase @char)
        {
            return @char.IsState();
        }
    }
}
