using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public class Program
    {
        private const string ValidKeysInput = "1234567890*# ";
        private const string ERR_SHARP_MSG = "the input must contains # character.";
        private const string ERR_CHARACTER_MSG = "invalid characters in the input.";
        private static readonly Dictionary<char, string> KeypadMapping = new Dictionary<char, string>()
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string OldPhonePad(string input)
        {
            StringBuilder result = new StringBuilder();
            bool insideBracket = false;
            int index = 0;
            int count;
            char keypad;

            if (!input.Contains('#'))
                throw new ArgumentException(ERR_SHARP_MSG, "invalid_sharp");
            while (index < input.Length)
            {
                count = 0;
                keypad = input[index++];
                if (!ValidKeysInput.Contains(keypad))
                    throw new ArgumentException(ERR_CHARACTER_MSG, "invalid_characters");
                if (keypad == '#') break;
                while (index < input.Length && input[index] == keypad)
                {
                    count++;
                    index++;
                }
                if (keypad == ' ') continue;
                else if (keypad == '*')
                    insideBracket = RemoveCharacter(result, count, insideBracket);
                else if (keypad == '0')
                    result.Append(' ', count + 1);
                else
                    insideBracket = AddCharacter(result, KeypadMapping[keypad][count % KeypadMapping[keypad].Length], insideBracket);
            }
            return result.ToString();
        }

        private static bool AddCharacter(StringBuilder str, char character, bool insideBracket)
        {
            str.Append(character == '(' && insideBracket ? ')' : character);
            return character == '(' ? !insideBracket : insideBracket;
        }

        private static bool RemoveCharacter(StringBuilder currentStr, int count, bool insideBracket)
        {
            string originalStr =  currentStr.ToString();
            int index = 0;

            currentStr.Clear();
            insideBracket = false;
            while (index < originalStr.Length - (count + 1))
            {
                if (originalStr[index] == '(' || originalStr[index] == ')')
                    insideBracket = !insideBracket;
                currentStr.Append(originalStr[index]);
                index++;
            }
            return insideBracket;
        }

        static void Main(string[] args)
        {
            string[] example = ["33#", "227*#", "4433555 555666#", "8 88777444666*664#"];

            args = args.Length == 0 ? example : args;
            foreach (string item in args)
            {
                try
                {
                    Console.WriteLine($"OldPhonePad(\"{item}\") => output: |{OldPhonePad(item)}|");
                }
                catch (ArgumentException e)
                {
                    int index = e.Message.IndexOf(" (Parameter '");
                    Console.WriteLine($"OldPhonePad(\"{item}\") => {e.Message[..index]}");
                }
            }
        }
    }
}