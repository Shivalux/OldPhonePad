using System;
using System.Collections.Generic;

namespace OldPhonePad
{
    public class Program
    {
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
                    result = result.PadRight(result.Length + (count + 1));
                else
                    result += PhonePad[keypad][(count) % (PhonePad[keypad].Length)];
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