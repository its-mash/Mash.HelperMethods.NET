using System;
using System.Collections.Generic;
using System.Text;

namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class CharacterExtension
    {
        public static int ToLowerValueIfUpperCase(this char ch)
        {
            return (ch >= 'A' && ch <= 'Z') ? ch + 32 : ch;
        }
    }
}
