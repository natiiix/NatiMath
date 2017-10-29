using System;
using System.Collections.Generic;
using System.Linq;

namespace NatiMath.Geometry
{
    /// <summary>
    /// Class for storing and operating with points in N-dimensional space.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// N-dimensional coordinates of the point
        /// </summary>
        public Fraction[] Coordinates;

        /// <summary>
        /// Number of dimensions of the space in which the point exists.
        /// </summary>
        public int NDimensions { get => Coordinates.Length; }

        /// <summary>
        /// Constructs a point from a set of coordinates in an array.
        /// </summary>
        /// <param name="coordinates">Array containing the coordinates.</param>
        public Point(params Fraction[] coordinates)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        /// Constructs a point from a set of coordinates in an enumerable.
        /// </summary>
        /// <param name="coordinates">Enumerable containing the coordinates.</param>
        public Point(IEnumerable<Fraction> coordinates) : this(coordinates.ToArray())
        {
        }

        /// <summary>
        /// Allows an easier access to the coordinates.
        /// </summary>
        /// <param name="i">Dimension index of the accessed coordinate.</param>
        /// <returns>Returns the value of the coordinate in the specified dimension.</returns>
        public Fraction this[int i]
        {
            get { return Coordinates[i]; }
            set { Coordinates[i] = value; }
        }

        /// <summary>
        /// Addition operator overload.
        /// Adds an offset in the form of a vector to a point.
        /// </summary>
        /// <param name="value">Input point.</param>
        /// <param name="offset">Vector offset to be added to the point.</param>
        /// <returns>Returns a point with the value of the offset vector added to the input point.</returns>
        public static Point operator +(Point value, Vector offset)
        {
            // Get the number of dimensions the point has
            int nDimensions = value.NDimensions;

            // Throw an exception of the vector has a different number of dimensions than the point
            if (offset.NDimensions != nDimensions)
            {
                throw new ArgumentException("Added point and vector must have the same number of dimensions!");
            }

            // Add the offset to the input point coordinates
            Fraction[] newCoordinates = new Fraction[nDimensions];

            for (int i = 0; i < nDimensions; i++)
            {
                newCoordinates[i] = value[i] + offset[i];
            }

            // Returns the new point
            return new Point(newCoordinates);
        }

        /// <summary>
        /// Subtraction operator overload.
        /// Calculates the difference between two points and returns it as a vector.
        /// </summary>
        /// <param name="a">First input point.</param>
        /// <param name="b">Second input point.</param>
        /// <returns>Returns a vector representing the difference between the input points.</returns>
        public static Vector operator -(Point a, Point b)
        {
            // Get the number of dimensions of the first point
            int nDimensions = a.NDimensions;

            // Throw an error if the second point has a different number of dimensions than the first point
            if (b.NDimensions != nDimensions)
            {
                throw new ArgumentException("The input points must have the same number of dimensions for the difference to be possible to calculate!");
            }

            // Calculate the difference between the input points
            Fraction[] difference = new Fraction[nDimensions];

            for (int i = 0; i < nDimensions; i++)
            {
                difference[i] = a[i] - b[i];
            }

            // Return a vector representing the difference between the two points
            return new Vector(difference);
        }

        /// <summary>
        /// Converts the point to a vector.
        /// Equivalent to calculating the difference between the input point and the origin of the coordinate system.
        /// </summary>
        /// <returns>Returns a vector representation of the point.</returns>
        public Vector ToVector() => new Vector(Coordinates);

        /// <summary>
        /// Converts the point to a vector.
        /// Equivalent to calculating the difference between the input point and the origin of the coordinate system.
        /// </summary>
        /// <returns>Returns a vector representation of the point.</returns>
        public static explicit operator Vector(Point value) => value.ToVector();
    }
}