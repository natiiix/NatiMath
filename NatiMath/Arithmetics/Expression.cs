namespace NatiMath.Arithmetics
{
    public abstract class Expression
    {
        private bool Negative;

        // Returns a floating point value representation of the expression
        public double ToDouble()
        {
            if (Negative)
            {
                return -(__ToDouble());
            }
            else
            {
                return __ToDouble();
            }
        }

        protected abstract double __ToDouble();

        // Returns a string representation of the expression
        public override string ToString()
        {
            if (Negative)
            {
                return $"-({__ToString()})";
            }
            else
            {
                return __ToString();
            }
        }

        protected abstract string __ToString();

        // Expression negation
        public static Expression operator -(Expression a)
        {
            Expression negative = a.MemberwiseClone() as Expression;
            negative.Negative = !negative.Negative;
            return negative;
        }
    }
}