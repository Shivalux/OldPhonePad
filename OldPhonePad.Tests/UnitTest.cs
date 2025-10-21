using System;
using Xunit;
using OldPhonePad;

namespace OldPhonePad.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData("222 2 22#", "CAB")]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8888 88777444666*664#", "TURING")]
        [InlineData("******* ** *99999999999999444 444444 44444444422*#", "XIII")]
        [InlineData("************#", "")]
        [InlineData("*** ****   ***#", "")]
        [InlineData("       #", "")]
        [InlineData("222_2_22#", "")]
        [InlineData("222 2 22", "")]
        [InlineData("44 33 555          555 666#", "HELLO")]

        // string[] testCases =
        // [
        //     "222 2 22#",
        //     "33#",
        //     "227*#",
        //     "4433555 555666#",
        //     "8888 88777444666*664#",
        //     // "",
        //     // "#",
        //     // "******2222222222 222224**#",
        //     "202202220222202222200*222222000***#",
        //     "3000000000*0*0*003300**0333000000****0*333300033333*33333000**333333000*****333333#",
        //     // "HELLO#",
        // ];
        public void OldPhonePad_Program_ReturnString(string input, string expect)
        {
            string actual = Program.OldPhonePad(input);
            Assert.Equal(expect, actual);
  
        }
    }

}