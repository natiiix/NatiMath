using System.Numerics;

namespace NatiMath.Expression
{
    public class FractionExpression : Expression
    {
        public readonly Expression Numerator;
        public readonly Expression Denominator;

        public FractionExpression(Expression numerator, Expression denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public FractionExpression(int numerator, int denominator)
        {
            Numerator = new SimpleExpression(numerator);
            Denominator = new SimpleExpression(denominator);
        }

        public FractionExpression(BigInteger numerator, BigInteger denominator)
        {
            Numerator = new SimpleExpression(numerator);
            Denominator = new SimpleExpression(denominator);
        }

        public FractionExpression(Fraction fraction) : this(fraction.Numerator, fraction.Denominator)
        {
        }

        protected override double __ToDouble()
        {
            return Numerator.ToDouble() / Denominator.ToDouble();
        }

        protected override string __ToString()
        {
            return $"({Numerator})/({Denominator})";
        }
    }
}