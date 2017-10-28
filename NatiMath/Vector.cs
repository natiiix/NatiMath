using System;
using System.Collections.Generic;
using System.Linq;

namespace NatiMath
{
    /// <summary>
    /// Class for storing and operating with Euclidean vectors.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Values of the vector magnitudes in each dimensions.
        /// </summary>
        public Fraction[] Magnitudes;

        /// <summary>
        /// Number of dimensions the vector has.
        /// </summary>
        public int NDimensions { get => Magnitudes.Length; }

        /// <summary>
        /// Constructs a Vector object from a set of magnitudes.
        /// </summary>
        /// <param name="magnitudes">Magnitude values.</param>
        public Vector(params Fraction[] magnitudes)
        {
            Magnitudes = magnitudes;
        }

        /// <summary>
        /// Constructs a Vector object from a set of magnitudes.
        /// </summary>
        /// <param name="magnitudes">Magnitude values.</param>
        public Vector(IEnumerable<Fraction> magnitudes) : this(magnitudes.ToArray())
        {
        }

        /// <summary>
        /// Provides an easier access to magnitude values.
        /// </summary>
        /// <param name="i">Index of the accessed dimension.</param>
        /// <returns>Returns the value of a magnitude in the specified dimension.</returns>
        public Fraction this[int i]
        {
            get { return Magnitudes[i]; }
            set { Magnitudes[i] = value; }
        }

        /// <summary>
        /// Negation (unary subtraction) operator overload.
        /// </summary>
        /// <param name="a">Input vector.</param>
        /// <returns>Returns an inverted vector to the input vector.</returns>
        public static Vector operator -(Vector a)
        {
            // The magnitude of the vector in each dimension is negated
            return new Vector(a.Magnitudes.Select(x => -x));
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
                throw new InvalidOperationException();
            }

            // Add the magnitudes in each dimension
            Fraction[] addedDirection = new Fraction[nDimensions];

            for (int i = 0; i < nDimensions; i++)
            {
                addedDirection[i] = a[i] + b[i];
            }

            // Return the added vector
            return new Vector(addedDirection);
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
        /// Each magnitude of the vector is multiplied by the scale.
        /// </summary>
        /// <param name="value">Input vector.</param>
        /// <param name="scale">Input scale.</param>
        /// <returns>Returns a vector with the value of the input vector scaled by the input scale.</returns>
        public static Vector operator *(Vector value, Fraction scale) => new Vector(value.Magnitudes.Select(x => x * scale));

        /// <summary>
        /// Division operator overload.
        /// Scales the input vector by a specified scale.
        /// Each magnitude of the vector is divided by the scale.
        /// </summary>
        /// <param name="value">Input vector.</param>
        /// <param name="scale">Input scale.</param>
        /// <returns>Returns the value of the input vector scaled by the input scale.</returns>
        public static Vector operator /(Vector value, Fraction scale) => value * ~scale;
    }
}