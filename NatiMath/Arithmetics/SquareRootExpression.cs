namespace NatiMath.Arithmetics
{
    public class SquareRootExpression : Expression
    {
        public readonly ExponentExpression ExponentialForm;

        public SquareRootExpression(Expression baseValue)
        {
            ExponentialForm = new ExponentExpression(baseValue, new FractionExpression(1, 2));
        }

        protected override double __ToDouble()
        {
            return ExponentialForm.ToDouble();
        }

        protected override string __ToString()
        {
            return $"sqrt({ExponentialForm.BaseValue})";
        }
    }
}