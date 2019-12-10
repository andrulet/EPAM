using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuggedArray
{
    public class Temp : IComparer<int[]>
    {
        private Comparison<int[]> delegateForm;

        public Temp(Comparison<int[]> delegateForm)
        {
            this.delegateForm = delegateForm;
        }

        public int Compare(int[] x, int[] y)
        {
            return delegateForm(x, y);
        }
    }
}
