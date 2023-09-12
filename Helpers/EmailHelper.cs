using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp3.Helpers
{
    public static class EmailHelper
    {
        public static string ParseEmailFormFileName(string name)
        {
            string[] recipientsList = name.Split(" ");
            return recipientsList[0];
        }
    }
}
