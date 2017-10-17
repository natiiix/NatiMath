using System.Collections.Generic;
using System.Linq;

namespace NatiMath
{
    public class SumExpression : IExpression
    {
        public readonly IExpression[] Members;

        public SumExpression(params IExpression[] members)
        {
            Members = members;
        }

        public double ToDouble()
        {
            return Members.Sum(x => x.ToDouble());
        }

        public override string ToString()
        {
            return string.Join(" + ", Members as IEnumerable<IExpression>);
        }
    }
}