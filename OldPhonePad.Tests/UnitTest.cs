using System;
using Xunit;
using OldPhonePad;

namespace OldPhonePad.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("1234* 445666 678  900")]
        public void OldPhonePad_NoContainSharpShouldFail(string input)
        {
            Assert.Throws<ArgumentException>("invalid_sharp", () => Program.OldPhonePad(input));
        }
        
        [Theory]
        [InlineData("HELLO#")]
        [InlineData("22 2_0#")]
        public void OldPhonePad_InvalidCharactersShouldFail(string input)
        {
            Assert.Throws<ArgumentException>("invalid_characters", () => Program.OldPhonePad(input));
        }

        [Theory]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8888 88777444666*664#", "TURING")]
        [InlineData("   44 33 55555512*  *        555 666#   ", "HELLO")]
        [InlineData("2#2222222", "A")]
        [InlineData("******* ** *99999999999999444 444444 44444444422*#", "XIII")]
        [InlineData("0************#", "")]
        [InlineData("0123456789*********#", " ")]
        [InlineData("*** ****   ***#", "")]
        [InlineData("       #", "")]
        [InlineData("#", "")]
        [InlineData("1 11 111 1111 11111 111111#", "&'(&')")]
        [InlineData("2 22 222 2222 22222 222222#", "ABCABC")]
        [InlineData("3 33 333 3333 33333 333333#", "DEFDEF")]
        [InlineData("4 44 444 4444 44444 444444#", "GHIGHI")]
        [InlineData("5 55 555 5555 55555 555555#", "JKLJKL")]
        [InlineData("6 66 666 6666 66666 666666#", "MNOMNO")]
        [InlineData("7 77 777 7777 77777 777777 7777777 77777777#", "PQRSPQRS")]
        [InlineData("8 88 888 8888 88888 888888#", "TUVTUV")]
        [InlineData("9 99 999 9999 99999 999999 9999999 99999999#", "WXYZWXYZ")]
        [InlineData("0#", " ")]
        [InlineData("0****0000000000000000000*********#", "          ")]
        [InlineData("000000000000000000002#", "                    A")]
        [InlineData("22 0  0 0  0 0  0 0   0  0  0 #", "B          ")]
        [InlineData("02220#", " C ")]
        [InlineData("111 111 111 111 111 111#", "()()()")]
        [InlineData("111 111 111 111 111#", "()()(")]
        [InlineData("111 111 111 111 111*111 111#", "()()()")]
        [InlineData("111*111 111 111 111 111***111 111 111**111****111*111 111#", "()")]
        [InlineData("            ********66655539957777  ***744666 6633723111*111 11 444667*7*7**66788888888 8 8*11 111#", "OLDPHONEPAD('INPUT')")]
        [InlineData("00***4447777777666  00***666 660   111222111*11102226666666663444664 110222442555 5553366433#", "IRON (C) CODING' CHALLENGE")]
        public void OldPhonePad_CorrectInputTestShouldWork(string input, string expect)
        {
            string actual = Program.OldPhonePad(input);
            Assert.Equal(expect, actual);

        }
    }

}