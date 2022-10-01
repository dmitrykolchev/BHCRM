using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace DykBits.Crm.UI
{
    public sealed class WaitCursor: IDisposable
    {
        private static int refCount;
        public WaitCursor()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Interlocked.Increment(ref refCount);
        }

        public void Dispose()
        {
            if(refCount > 0)
            {
                Interlocked.Decrement(ref refCount);
            }
            if (refCount == 0)
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
