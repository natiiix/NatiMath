using System;
using System.Numerics;

namespace NatiMath.Expression
{
    public class SimpleExpression : Expression
    {
        public readonly IComparable Value;

        public SimpleExpression(IComparable value)
        {
            Value = value;
        }

        protected override double __ToDouble()
        {
            // double
            if (Value is double)
            {
                return (double)(Value as double?);
            }
            // float
            else if (Value is float)
            {
                return (double)(Value as float?);
            }
            // int
            else if (Value is int)
            {
                return (double)(Value as int?);
            }
            // long
            else if (Value is long)
            {
                return (double)(Value as long?);
            }
            // short
            else if (Value is short)
            {
                return (double)(Value as short?);
            }
            // byte
            else if (Value is byte)
            {
                return (double)(Value as byte?);
            }
            // BigInteger
            else if (Value is BigInteger)
            {
                return (double)(Value as BigInteger?);
            }
            // Invalid
            else
            {
                throw new InvalidCastException("Unable to convert T to double");
            }
        }

        protected override string __ToString()
        {
            return Value.ToString();
        }
    }
}