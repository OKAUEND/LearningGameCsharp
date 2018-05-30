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
            Palsy   = 1,
            Poison  = 1 << 1,
            Sleep   = 1 << 2,
            All     = 0xFF,
        }

        public void reset()
        {
            Debuff = 0;
        }

        public void On(Kind Flag)
        {
            Debuff |= Flag;
        }

    }
}
