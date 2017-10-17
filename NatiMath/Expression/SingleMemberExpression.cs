using System.Numerics;

namespace NatiMath
{
    public class SingleMemberExpression : Fraction, IExpression
    {
        public SingleMemberExpression(BigInteger number) : base(number)
        {
        }

        public SingleMemberExpression(double value) : base(value)
        {
        }

        public SingleMemberExpression(BigInteger numerator, BigInteger denominator) : base(numerator, denominator)
        {
        }

        public SingleMemberExpression(int numerator, int denominator = 1) : base(numerator, denominator)
        {
        }

        public override string ToString()
        {
            return $"({base.ToString()})";
        }
    }
}