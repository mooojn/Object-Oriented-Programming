using chlg3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3
{
    internal class UtilCrud
    {
        public static bool BlockTransactions(bool transactions_blocked)
        {
            UtilUi.Process();

            string status = transactions_blocked ? "Un" : "";  // ternary operator to check if we need to add Un or not

            UtilUi.Success($"Your transactions have been successfully {status}blocked");

            return !transactions_blocked;  // reversing the value   :}
        }
    }
}
