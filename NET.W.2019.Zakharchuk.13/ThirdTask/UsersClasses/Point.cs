using System;
using System.Collections.Generic;

namespace Third_Task.UsersClasses
{
    /// <summary>
    /// Class describing Point model.
    /// </summary>
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Initializes new instance of <see cref="Point<T>"/> with specified <paramref name="x"/> and <paramref name="x"/>.
        /// </summary>
        /// <param name="x">X coordinate of point.</param>
        /// <param name="y">Y coordinate of point.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Property X.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Property Y.
        /// </summary>
        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y ? true : false;
        }
    }
}
