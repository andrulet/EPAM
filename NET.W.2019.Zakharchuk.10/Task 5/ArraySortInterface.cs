using System;
using System.Collections.Generic;

namespace JuggedArray
{
    public static class ArraySortInterface
    {
        public static void SortInterface(int[][] array, IComparer<int[]> comp, bool invert)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            SortDelegate(array, comp.Compare, invert);
        }

        private static void SortDelegate(int[][] array, Comparison<int[]> comparison, bool invert)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((comparison(array[j], array[j + 1]) > 0) ^ invert)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}

