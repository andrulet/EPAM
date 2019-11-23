using System;

namespace DoubleToBinary
{
    public static class DoubleExtension
    {
        /// <summary>
        /// This method retuns binary code of the double number.
        /// </summary>
        /// <param name="number">Time for which the method is executed</param>        
        /// <return> String of binary code</returns>
        public static unsafe string GetBinary(this double number)
        {
            long* x = (long*)&number;
            string s = "";
            for (int i = 0; i < 63; i++)
            {
                if ((*x & 1) == 1)
                {
                    s = "1" + s;
                    *x = *x >> 1;
                }
                else
                {
                    s = "0" + s;
                    *x = *x >> 1;
                }
            }
            s = ((number >= 0) ? '0' : '1') + s;
            return s;
        }
    }
}
