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
        public static string GetBinary(this double number)
        {
            long numberInBinary = BitConverter.ToInt64(BitConverter.GetBytes(number), 0);
            char sign = (number >= 0) ? '0' : '1';
            return Convert.ToString(numberInBinary, 2).PadLeft(64, sign);
        }
    }
}
