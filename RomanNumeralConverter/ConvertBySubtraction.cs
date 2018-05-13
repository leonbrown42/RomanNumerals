using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralConverter
{
    public static class ConvertBySubtraction
    {
        private static Dictionary<int, char> RomanCharacters = new Dictionary<int, char>()
        {
            { 1, 'I' },
            { 5, 'V' },
            { 10, 'X' },
            { 50, 'L' },
            { 100, 'C' },
            { 500, 'D' },
            { 1000, 'M' }
        };

        public static string Convert(int number)
        {
            if (number >=4000)
                throw new ArgumentException("Roman numerals have a maximum calculation value of 3999");

            return Convert(ref number, RomanCharacters.Count - 1);
        }

        private static string Convert(ref int number, int index = 6, StringBuilder romanNumeralBuilder = null)
        {
            if (romanNumeralBuilder == null)
                romanNumeralBuilder = new StringBuilder();

            var characterValue = GetRomanCharacterValue(index);
            var nextCharacter = GetNextCharacterValue(index);

            if (CanCharacterBeAddedToRomanString(number, characterValue))
                AddCharacterAndSubtractNumberValue(ref number, index, romanNumeralBuilder);

            if (CanNextIndexedCharacterBeAddedToRomanString(number, characterValue, nextCharacter.Value))
            {
                if (IsNextIndexedCharacterAvailable(nextCharacter.Value))
                    AddCharaterAndAddNumberValue(ref number, nextCharacter.Key, romanNumeralBuilder);

                AddCharacterAndSubtractNumberValue(ref number, index, romanNumeralBuilder);
            }

            if (number != 0 && index > 0)
                Convert(ref number, index - 1, romanNumeralBuilder);

            return romanNumeralBuilder.ToString();
        }

        private static int GetRomanCharacterValue(int index)
        {
            return RomanCharacters.Keys.ElementAt(index);
        }

        private static char GetRomanCharacter(int index)
        {
            return RomanCharacters[GetRomanCharacterValue(index)];
        }

        private static KeyValuePair<Int16, int> GetNextCharacterValue(int index)
        {
            if (index < 1)
                return new KeyValuePair<Int16, int>(); ;

            var character = GetRomanCharacter(index - 1);
            //Todo: ignorelist
            if (character == 'V' || character == 'L' || character == 'D')
                return new KeyValuePair<Int16, int>((Int16)(index - 2), GetRomanCharacterValue(index - 2));

            return new KeyValuePair<Int16, int>((Int16)(index - 1), GetRomanCharacterValue(index - 1));
        }

        private static bool CanCharacterBeAddedToRomanString(int number, int characterValue)
        {
            return number >= characterValue;
        }

        private static void AddCharacterAndSubtractNumberValue(ref int number, int index, StringBuilder romanNumeralBuilder)
        {
            romanNumeralBuilder.Append(GetRomanCharacter(index));
            number -= GetRomanCharacterValue(index);

            if (number > 0)
                Convert(ref number, index, romanNumeralBuilder);
        }

        private static void AddCharaterAndAddNumberValue(ref int number, int index, StringBuilder romanNumeralBuilder)
        {
            romanNumeralBuilder.Append(GetRomanCharacter(index));
            number += GetRomanCharacterValue(index);
        }

        private static bool CanNextIndexedCharacterBeAddedToRomanString(int number, int characterValue, int nextCharacterValue)
        {
            return (number >= characterValue - nextCharacterValue);
        }

        private static bool IsNextIndexedCharacterAvailable(int nextCharacterValue)
        {
            return (nextCharacterValue > 0);
        }
    }
}
