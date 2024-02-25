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
        public static string admin_pass = "admin";
        public static bool Validate(string pass)
        {
            if (pass == admin_pass)
            {
                UtilUi.Success("You are signed in as admin...");
                return true;
            }
            UtilUi.Error("Incorrect Password");
            return false;
        }
    }
}
