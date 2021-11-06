using System;
using System.Collections.Generic;
using System.Text;

namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class IntegerExtension
    {
        public static void Fill(this int[] array, int value)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }

        }
    }
}
