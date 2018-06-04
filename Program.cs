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
            var AllSkill = CreateSkill();

            var Djeeta = new Char.CharBase("ジータ", "ヒューマン", "女", 500, 20, 2);
            Djeeta.UseSkillList = new List<string>
            {
                "001",
                "002",
                "003"
            };
            Djeeta.SetUseSkill(AllSkill);
            var Enemy = new Char.CharBase("コキュートス", "エネミー", "-", 1000, 40, 5);
            //Enemy.UseSkillList = new List<string>
            //{
            //    "004",
            //    "005",
            //};
            //Enemy.SetUseSkill(AllSkill);

            var Random = new Random();

            Boolean Game = false;
            do
            {
                LineView();
                Console.WriteLine("あなたのターンです。");
                Console.WriteLine(Djeeta.Info());
                Djeeta.TurnReset();
                PlayerAction(Djeeta, Enemy);

                LineView();

                Console.WriteLine("敵のターンです。");
                Console.WriteLine(Enemy.Info());
                Enemy.TurnReset();
                ActionBrancher(Enemy, Djeeta, Random.Next(1, 3));

                Game = Djeeta.IsState();
                Game = Enemy.IsState();
            }
            while (!Game);

        }

        private static void PlayerAction(Char.CharBase Player, Char.CharBase Enemy)
        {
            string info = "行動を入力してください";
            string Actionchoche = " / 1:攻撃 / 2:スキル / 3:防御 / 4:回復";
            Boolean TurnAction = true;
            do
            {
                Console.WriteLine($"{info},{Actionchoche}");
                TurnAction = ActionBrancher(Player, Enemy,InputLine(Actionchoche,1,4));
            } while (TurnAction);
        }

        private static Boolean ActionBrancher(Char.CharBase Player, Char.CharBase Enemy, int Selection)
        {
            Boolean TurnSet = true;
            switch (Selection)
            {
                case 1:
                    Player.Attack(Enemy);
                    break;
                case 2:
                    var Choice = SkillAction(Player, Enemy);
                    if (0 < Choice)
                    {
                        TurnSet = false;
                    }
                    break;
                case 3:
                    Player.Guard();
                    break;
                case 4:
                    Player.Heal();
                    break;
            }
            return TurnSet;
        }

        private static int SkillAction(Char.CharBase Player, Char.CharBase Enemy)
        {
            int Count = 1;
            LineView();
            Console.WriteLine($"スキルを選択してください。");
            Console.WriteLine($"0 / 戻る");
            foreach (Char.Skill.SkillBase Skill in Player.MySkill)
            {
                Console.WriteLine($"{Count} / {Skill.SkillName} 種類 {Skill.SkillTypeShowTrans} 効果 {Skill.SkillRation}倍");
                Count += 1;
            }
            return InputLine("", 0, Count);
        }

        public static int InputLine(string ActionChoche, int FirstNo, int LastNo)
        {
            Boolean Loop = false;
            string InputKey = string.Empty;
            string ErrorInfo = "を入力してください";
            string ErrorNum = "数値";
            int Num = 0;
            while (!Loop)
            {
                InputKey = Console.ReadLine();
                Loop = int.TryParse(InputKey, out Num);
                if (Loop == false)
                {
                    Console.WriteLine($"{ErrorNum}{ErrorInfo}{ActionChoche}");
                    continue;
                }
                else if (Num < FirstNo & Num > LastNo)
                {
                    Console.WriteLine($"({FirstNo}～{LastNo}{ErrorInfo}{ActionChoche}");
                    Loop = false;
                    continue;
                }
            }
            return Num;
        }

        private static Dictionary<string, Char.Skill.SkillBase> CreateSkill()
        {

            var SkillList = new List<Char.Skill.SkillBase>
            {
                new Char.Skill.Attack("001", "テンペストブレード", CreateList("Attack"), "1.2", 2, 3),
                new Char.Skill.Buff("002", "レイジI", CreateList("Buff"), "1.2", 2, 3),
                //new Char.Skill.SkillBase("003", "ファランクスI", CreateList("Defence"), "50", 0, 3, 4),
                new Char.Skill.Heal("003", "ヒールI", CreateList("Heal"), "1.5", 3, 4),
                //new Char.Skill.SkillBase("005", "ジュデッカ", CreateList("Attack"), "1.5", 0, 0, 0),
                //new Char.Skill.SkillBase("006", "アンティノラ", CreateList("Attack"), "1.2", 0, 0, 40)
            };

            Dictionary<string,Char.Skill.SkillBase> SkillDate = new Dictionary<string,Char.Skill.SkillBase>();
            foreach(var skill in SkillList)
            {
                SkillDate.Add(key: skill.GetID(), value: skill);
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
