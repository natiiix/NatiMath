namespace NatiMath
{
    public interface IExpression
    {
        // Returns a floating point value representation of the expression
        double ToDouble();

        // Returns a string representation of the expression
        string ToString();
    }
}