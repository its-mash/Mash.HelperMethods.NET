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

        public static void SetBit(this ref int mask, int bitNo, bool value)
        {
            if (value)
            {
                mask |= 1 << bitNo;
            }
            else
            {
                mask &= ~(1 << bitNo);
            }

        }

        public static bool GetBit(this int mask, int bitNo)
        {
            return (mask & (1 << bitNo)) != 0;
        }

    }
}
