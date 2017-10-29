using System;
using System.Collections.Generic;
using System.Linq;

namespace NatiMath.Geometry
{
    /// <summary>
    /// Class for storing and operating with Euclidean vectors.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Individual dimensions of the vector.
        /// </summary>
        public Fraction[] Dimensions;

        /// <summary>
        /// Number of dimensions the vector has.
        /// </summary>
        public int NDimensions { get => GetNumberOfDimensions(); }

        /// <summary>
        /// Magnitude of the vector.
        /// </summary>
        public double Magnitude { get => GetMagnitude(); }

        /// <summary>
        /// Constructs a Vector object from a set of dimensions in an array.
        /// </summary>
        /// <param name="dimensions">Dimension values.</param>
        public Vector(params Fraction[] dimensions)
        {
            Dimensions = dimensions;
        }

        /// <summary>
        /// Constructs a Vector object from a set of dimensions in an enumerable.
        /// </summary>
        /// <param name="dimensions">Dimension values.</param>
        public Vector(IEnumerable<Fraction> dimensions) : this(dimensions.ToArray())
        {
        }

        /// <summary>
        /// Provides an easier access to the individual dimension values.
        /// </summary>
        /// <param name="i">Index of the accessed dimension.</param>
        /// <returns>Returns the value of the specified dimension of the vector.</returns>
        public Fraction this[int i]
        {
            get { return Dimensions[i]; }
            set { Dimensions[i] = value; }
        }

        /// <summary>
        /// Negation (unary subtraction) operator overload.
        /// </summary>
        /// <param name="a">Input vector.</param>
        /// <returns>Returns an inverted vector to the input vector.</returns>
        public static Vector operator -(Vector a)
        {
            // Negates the value of each dimension of the vector
            return new Vector(a.Dimensions.Select(x => -x));
        }

        /// <summary>
        /// Addition operator overload.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <returns>Returns the added value of the two input vectors.</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            // Get the number of dimensions of the first vector
            int nDimensions = a.NDimensions;

            // In order to be added, the input vectors must have a matching number of dimensions
            if (b.NDimensions != nDimensions)
            {
                throw new ArgumentException("Added vectors must have the same number of dimensions!");
            }

            // Adds the respective dimensions
            Fraction[] addedDimensions = new Fraction[nDimensions];

            for (int i = 0; i < nDimensions; i++)
            {
                addedDimensions[i] = a[i] + b[i];
            }

            // Return the added vector
            return new Vector(addedDimensions);
        }

        /// <summary>
        /// Subtraction operator overload.
        /// </summary>
        /// <param name="a">First input vector.</param>
        /// <param name="b">Second input vector.</param>
        /// <returns>Returns the difference between the two input vectors.</returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return a + -b;
        }

        /// <summary>
        /// Multiplication operator overload.
        /// Scales the input vector by a specified scale.
        /// Each dimension of the vector is multiplied by the scale.
        /// </summary>
        /// <param name="value">Input vector.</param>
        /// <param name="scale">Input scale.</param>
        /// <returns>Returns a vector with the value of the input vector scaled by the input scale.</returns>
        public static Vector operator *(Vector value, Fraction scale) => new Vector(value.Dimensions.Select(x => x * scale));

        /// <summary>
        /// Division operator overload.
        /// Scales the input vector by a specified scale.
        /// Each dimension of the vector is divided by the scale.
        /// </summary>
        /// <param name="value">Input vector.</param>
        /// <param name="scale">Input scale.</param>
        /// <returns>Returns the value of the input vector scaled by the input scale.</returns>
        public static Vector operator /(Vector value, Fraction scale) => value * ~scale;

        /// <summary>
        /// Converts the vector to a point.
        /// Equivalent to adding the vector to the origin of the coordinate system.
        /// </summary>
        /// <returns>Returns a point representation of the vector.</returns>
        public Point ToPoint() => new Point(Dimensions);

        /// <summary>
        /// Converts the vector to a point.
        /// Equivalent to adding the vector to the origin of the coordinate system.
        /// </summary>
        /// <returns>Returns a point representation of the vector.</returns>
        public static explicit operator Point(Vector value) => value.ToPoint();

        /// <summary>
        /// Determines the number of dimensions by reading the length of the array of dimensions.
        /// </summary>
        /// <returns>Returns the number of dimensions of the vector.</returns>
        public int GetNumberOfDimensions() => Dimensions.Length;

        /// <summary>
        /// Calculates the magnitude of the vector.
        /// Magnitude = sqrt(x^2 + y^2 + z^2 + ...)
        /// </summary>
        /// <returns>Returns a double precision floating point representation of the magnitude of the vector.</returns>
        public double GetMagnitude() => Math.Sqrt(Dimensions.Select(x => Math.Pow((double)x, 2)).Sum());
    }
}