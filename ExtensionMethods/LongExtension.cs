namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class LongExtension
    {

        public static void SetBit(this ref long mask, int bitNo, bool value)
        {
            if (value)
            {
                mask |= 1L << bitNo;
            }
            else
            {
                mask &= ~(1L << bitNo);
            }

        }

        public static bool GetBit(this long mask, int bitNo)
        {
            return (mask & (1L << bitNo)) != 0;
        }
    }
}