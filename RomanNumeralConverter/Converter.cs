using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralConverter
{
    public static class Converter
    {
        private static char One = 'I';
        private static char Five = 'V';
        private static char Ten = 'X';
        private static char Fifty = 'L';
        private static char Hundred = 'C';
        private static char FiveHundred = 'D';
        private static char Thousand = 'M';
        private static Dictionary<int, char> RomanCharacters = new Dictionary<int, char>()
        {
            { 1, One },
            { 5, Five },
            { 10, Ten },
            { 50, Fifty },
            { 100, Hundred },
            { 500, FiveHundred },
            { 1000, Thousand }
        };
        private static List<int> RomanCharacterList = new List<int> { 1, 5, 10, 50, 100, 500, 1000 };

        public static string Convert(int integer, int index = 6, StringBuilder romanNumeralBuilder = null)
        {
            //RomanOptions = new Dictionary<int, string> { { 1, "" } };
            if (romanNumeralBuilder == null)
                romanNumeralBuilder = new StringBuilder();

            //if (integer > 1000) { }
            //if (integer > 500) { }
            //if (integer > 100) { }
            //if (integer > 50) { }
            //if (integer > 10) { }
            var nextWritableRomanNumeral = RomanCharacterList[index] - (index == 0 ? 0 : RomanCharacterList[index - 1]);
            var romanCharactersContainsNextNumeral = RomanCharacters.Any(x => x.Key == nextWritableRomanNumeral);
            if (integer >= (nextWritableRomanNumeral) && !romanCharactersContainsNextNumeral)
                AddBaseCharacter(ref integer, RomanCharacters[RomanCharacterList[index]], ref romanNumeralBuilder);

            if (index > 0)
                AddAdditionalCharacter(ref integer, RomanCharacters[RomanCharacterList[index - 1]], ref romanNumeralBuilder);

            if (integer > 0)
                Convert(integer, index - 1, romanNumeralBuilder);

            if (integer < 0)
                throw new OverflowException($"{nameof(integer)} should be 0 after the conversion, current value is {integer}");

            return romanNumeralBuilder.ToString();
        }

        private static void AddBaseCharacter(ref int integer, char character, ref StringBuilder romanNumeralBuilder)
        {
            romanNumeralBuilder.Append(character);
            var value = RomanCharacters.FirstOrDefault(x => x.Value == character).Key;
            integer = integer - value;
        }

        private static void AddAdditionalCharacter(ref int integer, char character, ref StringBuilder romanNumeralBuilder)
        {
            //if (string.IsNullOrWhiteSpace(romanNumeralBuilder.ToString()) || integer == 0)
            //    return;

            var value = RomanCharacters.FirstOrDefault(x => x.Value == character).Key;

            while (integer > 0 && (integer == value || integer == (value * 2) || integer == (value * 3)))
            {
                romanNumeralBuilder.Append(character);
                integer = integer - value;
            }

            if (integer == -value)
            {
                romanNumeralBuilder.Insert(0, character);
                integer = integer + value;
            }
        }
    }
}
