using System;
using System.Collections.Generic;

namespace JuggedArray
{
    public static class ArraySortDelegate
    {
        public static void SortDelegate(int[][] array, Comparison<int[]> comparison, bool invert)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            Temp tempClass = new Temp(comparison);
            SortInterface(array, tempClass, invert);
        }

        public static void SortInterface(int[][] array, IComparer<int[]> comp, bool invert)
        {            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((comp.Compare(array[j], array[j + 1]) > 0) ^ invert)
                    {
                        SwapRows(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void SwapRows(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}
