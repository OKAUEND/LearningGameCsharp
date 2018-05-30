using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Status
{
    class BitFlag
    {
        private char mFlag;

        public void Reset()
        {
            mFlag = '0';
        }

        public void off(char flag)
        {
            //mFlag = mFlag & ~flag;
        }
    }
}
