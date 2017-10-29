using System.Linq;

namespace NatiMath.Arithmetics
{
    public class SumExpression : Expression
    {
        public readonly Expression[] Members;

        public SumExpression(params Expression[] members)
        {
            Members = members;
        }

        protected override double __ToDouble()
        {
            return Members.Sum(x => x.ToDouble());
        }

        protected override string __ToString()
        {
            return string.Join(" + ", Members.Select(x => $"({x})"));
        }
    }
}