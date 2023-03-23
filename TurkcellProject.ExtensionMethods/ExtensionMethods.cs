using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty(this string text)
        {
            return (string.IsNullOrEmpty(text));
        }


        public static bool DoesContainNumber(this string text)
        {
            return (text.Any(Char.IsDigit));
        }

        public static bool DoesContainLetter(this string text)
        {
            return (text.Any(Char.IsLetter));
        }
    }
}
