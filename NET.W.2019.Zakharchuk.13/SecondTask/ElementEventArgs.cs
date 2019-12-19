using System;

namespace SecondTask
{
    /// <summary>
    /// Class providing additional <see cref=""/> information.
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        public ElementEventArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
        }

        public int I { get; private set; }

        public int J { get; private set; }
    }
}
