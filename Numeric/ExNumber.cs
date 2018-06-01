using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningGameCsharp.Numeric
{
    class ExNumber
    {
        private Double ExMax ; //最大値
        private Double ExMin ; //最小値
        private Double ExPre ; //現在地

        public ExNumber(Double max = 0,Double min = 0 , Double pre = 0)
        {
            ExMax = max;
            ExMin = min;
            ExPre = pre;
        }

        public Double GetMax() { return ExMax; }
        public Double GetMin() { return ExMin; }
        public Double Get() { return ExPre; }

        public void SetMax(Double value)
        {
            ExMax = Math.Max(ExMin, value);
            if (ExMax<Get())
            {
                Set(ExMax);
            }
        }
        public void SetMin(Double value)
        {
            ExMin = Math.Min(value, ExMin);
            if (Get() <ExMin)
            {
                Set(ExMin);
            }
        }

        public void Set(Double value)
        {
            value = Math.Min(value, ExMax);
            value = Math.Max(value, ExMin);
            ExPre = value;
        }

        public Double Add(Double value)
        {
            Set(Get() + value);
            return Get();
        }

        public Double AddMax(Double value)
        {
            SetMax(GetMax() + value);
            return GetMax();
        }
        public Double AddMin(Double value)
        {
            SetMin(GetMin() + value);
            return GetMin();
        }

        public Boolean IsEmpty() => (Get() <= GetMin());

        public Boolean ISFull() => (GetMax() <= Get());

        public Double Rate() => (Get() / GetMax());

    }
}
