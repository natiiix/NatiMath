using System.Linq;

namespace NatiMath.Expression
{
    public class ProductExpression : Expression
    {
        public readonly Expression[] Members;

        public ProductExpression(params Expression[] members)
        {
            Members = members;
        }

        protected override double __ToDouble()
        {
            double product = 1;

            foreach (Expression x in Members)
            {
                product *= x.ToDouble();
            }

            return product;
        }

        protected override string __ToString()
        {
            return string.Join(" * ", Members.Select(x => $"({x})"));
        }
    }
}