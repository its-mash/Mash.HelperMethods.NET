using System;
using System.Collections.Generic;
using System.Text;

namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string s)
        {
            // Using 0u >= (uint)value.Length rather than
            // value.Length == 0 as it will elide the bounds check to
            // the first char: value[0] if that is performed following the test
            // for the same test cost.
            // Ternary operator returning true/false prevents redundant asm generation:
            // https://github.com/dotnet/coreclr/issues/914
            return (s == null || 0u >= (uint)s.Length);
        }

        public static bool ContainsEnglishAlphabetsOnly(this string s)
        {
            if (s == null) return false;
            foreach (char ch in s.ToCharArray())
            {
                if (ch < 'A' || ch > 'z' || (ch > 'Z' && ch < 'a')) return false;

            }
            return true;
        }

        public static bool IsAlphabetOrHyphen(char ch)
        {
            return !(ch < 'A' || ch > 'z' || (ch > 'Z' && ch < 'a')) || ch == '-';
        }
        public static bool IsValidEnglishWord(this string s)
        {
            if (s.IsNullOrEmpty()) return false;
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '-')
                {
                    if (i != s.Length - 1)
                    {
                        continue;
                    }

                    return false;
                }
                if (ch < 'A' || ch > 'z' || (ch > 'Z' && ch < 'a')) return false;

            }
            return true;
        }
    }
}
