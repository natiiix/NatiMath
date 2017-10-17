using System;

namespace NatiMath.Expression
{
    public class ExponentExpression : IExpression
    {
        public readonly IExpression BaseValue;
        public readonly IExpression Exponent;

        public ExponentExpression(IExpression baseValue, IExpression exponent)
        {
            BaseValue = baseValue;
            Exponent = exponent;
        }

        public double ToDouble()
        {
            return Math.Pow(BaseValue.ToDouble(), Exponent.ToDouble());
        }

        public override string ToString()
        {
            return $"{BaseValue}^{Exponent}";
        }
    }
}