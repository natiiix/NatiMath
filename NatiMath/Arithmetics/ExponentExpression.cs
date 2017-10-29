using System;

namespace NatiMath.Arithmetics
{
    public class ExponentExpression : Expression
    {
        public readonly Expression BaseValue;
        public readonly Expression Exponent;

        public ExponentExpression(Expression baseValue, Expression exponent)
        {
            BaseValue = baseValue;
            Exponent = exponent;
        }

        protected override double __ToDouble()
        {
            return Math.Pow(BaseValue.ToDouble(), Exponent.ToDouble());
        }

        protected override string __ToString()
        {
            return $"({BaseValue})^({Exponent})";
        }
    }
}