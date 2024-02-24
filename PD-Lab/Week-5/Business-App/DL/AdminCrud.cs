using buscompe_conv.UI;
using chlg3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3
{
    internal class AdminCrud
    {
        public static bool Validate(string pass, string admin_pass)
        {
            if (pass == admin_pass)
            {
                UtilUi.success("You are signed in as admin...");
                return true;
            }
            UtilUi.error("Incorrect Password");
            return false;
        }
    }
}
