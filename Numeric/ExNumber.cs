using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Numeric
{
    class ExNumber
    {
        private float ExMax ; //最大値
        private float ExMin ; //最小値
        private float ExPre ; //現在地

        public ExNumber(float max = 0,float min = 0 , float pre = 0)
        {
            ExMax = max;
            ExMin = min;
            ExPre = pre;
        }

        public float GetMax() { return ExMax; }
        public float GetMin() { return ExMin; }
        public float Get() { return ExPre; }

        public void SetMax(float value)
        {
            ExMax = Math.Max(ExMin, value);
            if (ExMax<Get())
            {
                Set(ExMax);
            }
        }
        public void SetMin(float value)
        {
            ExMin = Math.Min(value, ExMin);
            if (Get() <ExMin)
            {
                Set(ExMin);
            }
        }

        public void Set(float value)
        {
            value = Math.Min(value, ExMax);
            value = Math.Max(value, ExMin);
            ExPre = value;
        }

        public float Add(float value)
        {
            Set(Get() + value);
            return Get();
        }

        public float AddMax(float value)
        {
            SetMax(GetMax() + value);
            return GetMax();
        }
        public float AddMin(float value)
        {
            SetMin(GetMin() + value);
            return GetMin();
        }

        public Boolean IsEmpty() => (Get() <= GetMin());

        public Boolean ISFull() => (GetMax() <= Get());

        public float Rate() => (Get() / GetMax());

    }
}
