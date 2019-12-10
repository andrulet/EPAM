using System;
using System.Collections.Generic;

namespace JuggedArray
{
    public class SortBySum: IComparer <int[]>
    {
        public int Compare(int[] x, int [] y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }

            if (SumElement(x) == SumElement(y))
             {
                return 0;
             }

            return SumElement(x) > SumElement(y) ? 1 : -1;
        }

        private static int SumElement(int[] x)
        {
            int sum = 0;
            for(int i = 0; i < x.Length; i++)
            {
                sum += x[i];
            }
            return sum;
        }        
    }
}
