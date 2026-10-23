using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Global_Classes
{
    public class clsFormat
    {
        public static string DateToShort(DateTime datetime)
        {
            return datetime.ToString("dd/MMM/yyyy");
        }

        public static string DateToLong(DateTime datetime)
        {
            return datetime.ToString("f");
        }
    }
}
