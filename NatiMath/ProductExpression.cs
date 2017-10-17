using System.Linq;

namespace NatiMath
{
    public class ProductExpression : IExpression
    {
        public readonly IExpression[] Members;

        public ProductExpression(params IExpression[] members)
        {
            Members = members;
        }

        public double ToDouble()
        {
            double product = 1;

            foreach (IExpression x in Members)
            {
                product *= x.ToDouble();
            }

            return product;
        }

        public override string ToString()
        {
            return string.Join(" * ", Members.Select(x => $"({x})"));
        }
    }
}