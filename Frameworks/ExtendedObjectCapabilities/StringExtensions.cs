using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    public static class StringExtensions
    {
        public static bool ContainsCaseInsensitive(this string mainstring, string stringtocompare) 
        {
            return mainstring?.IndexOf(stringtocompare, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool ContainsCaseSensitive(this string mainstring, string stringtocompare) 
        {
            return mainstring?.IndexOf(stringtocompare) >= 0;
        }
    }
}
