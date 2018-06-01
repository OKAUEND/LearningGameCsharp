using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.State
{
    class State
    {
        private Kind Debuff;

        public State()
        {
            Debuff = 0x00;
        }

        [Flags]
        public enum Kind
        {
            //麻痺
            Palsy   = 1 << 0,
            //毒
            Poison  = 1 << 1,
            //睡眠
            Sleep   = 1 << 2,
            //石化
            Stone   = 1 << 3,
            //呪い
            Curse   = 1 << 4,

            All     = 0xFF,
        }

        public void Reset()
        {
            Off(Kind.All);
        }

        public void On(Kind Flag) => Debuff |= Flag;

        public void Off(Kind Flag) => Debuff &= ~Flag;

        public Boolean IsKind(Kind Flag)
        {
            return (Debuff == Flag);
        }

        public Boolean IsEither(Kind Flag)
        {
            return (Debuff & Flag) != 0;
        }

        public Boolean IsTurnInactivity()
        {
            return (Debuff & Kind.Palsy | Kind.Sleep | Kind.Stone) != 0;
        }

    }
}
