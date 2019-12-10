using System;
using System.Collections.Generic;

namespace JuggedArray
{
    public class SortByMax : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            int maxFirst = x[0];
            int maxSecond = y[0];
            foreach(int a in x)
            {
                if(a > maxFirst)
                {
                    maxFirst = a;
                }
            }

            foreach (int a in y)
            {
                if (a > maxSecond)
                {
                    maxSecond = a;
                }
            }

            if(maxFirst == maxSecond)
            {
                return 0;
            }

            return (maxFirst > maxSecond) ? 1 : -1;
        }
    }
}
