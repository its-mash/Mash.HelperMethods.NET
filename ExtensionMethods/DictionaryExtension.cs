using System;
using System.Collections.Generic;
using System.Text;

namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class DictionaryExtension
    {
        public static void IncrementValueBy1<K>(this Dictionary<K, int> dictionary, K key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
            else
            {
                dictionary.Add(key, 1);
            }

        }
        public static void InitializeValueToZeroIfKeyDoesNotExist<K>(this Dictionary<K, int> dictionary, K key)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 0);
            }
        }
    }
}
