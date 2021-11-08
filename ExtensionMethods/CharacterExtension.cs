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
        public static bool IsValidWordContinuingCharacter(this char ch)
        {
            if (ch > 'z') return false;
            if (ch >= 'A')
            {
                return ch <= 'Z' || ch >= 'a';
            }
            return (ch >= '0' && ch <= '9') || ch == '-' || ch == '\'' || ch == '&' || ch == '.';

        }
        public static bool IsNoneRepeatableSpecialCharacter(this char ch)
        {
            return ch == '-' || ch == '\'' || ch == '&' || ch == '.';

        }
        public static bool IsValidStopWordContinuingCharacter(this char ch)
        {
            if (ch > 'z') return false;
            if (ch >= 'A')
            {
                return ch <= 'Z' || ch >= 'a';
            }
            return ((ch >= '0' && ch <= '9') || ch == '\'');

        }
        public static bool IsValidMetaWordContinuingCharacter(this char ch)
        {
            if (ch > 'z') return false;
            if (ch >= 'A')
            {
                return ch <= 'Z' || ch >= 'a';
            }
            return ((ch >= '0' && ch <= '9') || ch == '\'' || ch == '.' || ch == '-');

        }

        public static bool IsValidWordCharacter(this char ch)
        {
            if (ch > 'z') return false;
            if (ch >= 'A')
            {
                return ch <= 'Z' || ch >= 'a';
            }
            return (ch >= '0' && ch <= '9') || ch == '-' || ch == '\'' || ch == '&' || ch == '.';

        }
        public static bool IsValidWordCharacter(this char ch, out bool isNoneRepeatableCharacter)
        {
            isNoneRepeatableCharacter = false;
            if (ch > 'z') return false;
            if (ch >= 'A')
            {
                return ch <= 'Z' || ch >= 'a';
            }

            if (ch >= '0' && ch <= '9')
            {
                return true;
            }

            if (ch == '-' || ch == '\'' || ch == '&' || ch == '.')
            {
                isNoneRepeatableCharacter = true;
                return true;

            }

            return false;
        }
        public static bool IsThisLowerCaseCharacterIsValidWordCharacter(this char ch, out bool isNoneRepeatableCharacter)
        {
            isNoneRepeatableCharacter = false;
            if (ch > 'z') return false;
            if (ch >= 'a')
            {
                return true;
            }

            if (ch >= '0' && ch <= '9')
            {
                return true;
            }

            if (ch == '-' || ch == '\'' || ch == '&' || ch == '.')
            {
                isNoneRepeatableCharacter = true;
                return true;

            }

            return false;
        }
    }
}
