using System;
using System.Collections.Generic;

namespace JuggedArray
{
    public class SortByMin : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            int minFirst = x[0];
            int minSecond = y[0];
            foreach (int a in x)
            {
                if (a < minFirst)
                {
                    minFirst = a;
                }
            }

            foreach (int a in y)
            {
                if (a < minSecond)
                {
                    minSecond = a;
                }
            }

            if (minFirst == minSecond)
            {
                return 0;
            }

            return (minFirst < minSecond) ? -1 : 1;
        }
    }
}
