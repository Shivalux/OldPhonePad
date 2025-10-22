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
        /// Processes an input string simulating an old mobile phone keypad, 
        /// where each number corresponds to a set of characters.
        /// convert keypad input to human readable text.
        /// The function stops processing when encountering the '#' character in the input.
        /// </summary>
        /// <param name="input">
        /// It must contain the '#' character to indicate the end of the input.
        /// The input can contain digits (0-9), spaces for multiple characters with same keypad,
        /// the '*' character for deleting previous characters, and the '0' character to add spaces.</param>
        /// <returns>
        /// A string representing the processed readable output of the key presses based on old phone keypad.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the input string does not contain a '#' character or 
        /// contains invalid characters not allowed by the keypad (digits 0-9, '*', '#', and space).</exception>
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
                    insideBracket = RemoveCharacter(result, ++count, insideBracket);
                else if (keypad == '0')
                    result.Append(' ', ++count);
                else
                    insideBracket = AddCharacter(result, KeypadMapping[keypad][count % KeypadMapping[keypad].Length], insideBracket);
            }
            return result.ToString();
        }

        /// <summary>
        /// Adds a character to the StringBuilder and toggles the 'insideBracket' state.
        /// If the character is '(', it appends ')' if 'insideBracket' is true, otherwise it appends '('.
        /// </summary>
        /// <param name="str">The StringBuilder that the character will be appended to.</param>
        /// <param name="character">The character to add.</param>
        /// <param name="insideBracket">Indicates whether the current string is inside a bracket.</param>
        /// <returns>
        /// The updated 'insideBracket' state after the character is added.
        /// </returns>
        private static bool AddCharacter(StringBuilder str, char character, bool insideBracket)
        {
            str.Append(character == '(' && insideBracket ? ')' : character);
            return character == '(' ? !insideBracket : insideBracket;
        }

        /// <summary>
        /// Removes a specified number of characters from the StringBuilder while tracking 'insideBracket' state.
        /// </summary>
        /// <param name="currentStr">The StringBuilder from which characters will be removed.</param>
        /// <param name="count">The number of characters to remove.</param>
        /// <param name="insideBracket">Indicates whether the string is currently inside brackets.</param>
        /// <returns>
        /// The updated 'insideBracket' state after the character is removed.
        /// </returns>
        private static bool RemoveCharacter(StringBuilder currentStr, int count, bool insideBracket)
        {
            string originalStr =  currentStr.ToString();
            int index = 0;

            currentStr.Clear();
            insideBracket = false;
            while (index < originalStr.Length - count)
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