using System;
using System.Collections.Generic;

namespace OldPhonePad
{
    public class Program
    {
       /// <summary>
       /// 
       /// </summary>
        private static readonly Dictionary<char, string> PhonePad = new Dictionary<char, string>()
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
        /// The OldPhonePad function processes input characters based on a specific phone keypad layout,
        /// with special handling for '#' to stop processing.
        /// </summary>
        /// <param name="input">The `OldPhonePad` method takes a string input and processes it according
        /// to certain rules. It looks for specific characters in the input string and performs
        /// different actions based on those characters. The method processes the input string until it
        /// encounters the '#' character, at which point it stops and returns the result.</param>
        /// <returns>
        /// The `OldPhonePad` method returns a string that is the result of processing the input string
        /// 
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public static string OldPhonePad(string input)
        {
            string  result = "";
            int     index = 0;
            int     count;
            char    keypad;

            if (!input.Contains('#'))
                throw new ArgumentException("the input must contains # character.", "invalid_sharp");
            while (index < input.Length)
            {
                count = 0;
                keypad = input[index++];
                if (!"1234567890*# ".Contains(keypad))
                    throw new ArgumentException("invalid characters in the input.", "invalid_characters");
                if (keypad == '#') break;
                while (index < input.Length && input[index] == keypad)
                {
                    count++;
                    index++;
                }
                if (keypad == ' ') continue;
                else if (keypad == '*')
                    result = result[..(result.Length - (count + 1) < 0 ? 0 : result.Length - (count + 1))];
                else if (keypad == '0')
                    result = result.PadRight(result.Length + count + 1);
                else
                    result += PhonePad[keypad][count % PhonePad[keypad].Length];
            }
            return (result);
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