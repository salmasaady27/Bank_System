using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Global_Classes
{
    public static class clsGlobalEvents
    {
        public static event EventHandler TransactionCompleted;

        public static void RaiseTransactionCompleted()
        {
            TransactionCompleted?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler ActionCompleted;

        public static void RaiseActionCompleted()
        {
            ActionCompleted?.Invoke(null, EventArgs.Empty);
        }

    }
}
