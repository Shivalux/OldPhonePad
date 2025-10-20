using System;
using Xunit;
using OldPhonePad;

namespace OldPhonePad.Tests
{
    public class UnixTest
    {
        [Theory]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("4433555 555666*#", "HELL")]
        [InlineData("4433555 555666***#", "HELL")]
        [InlineData("4433555 555666***#", "HELL1")]
        [InlineData("4433555 555666***#", "HELL2")]
        [InlineData("44444#", "H")]
        public void OldPhonePad_Program_ReturnString(string input, string expect)
        {
            string result = Program.OldPhonePad(input);
            Assert.Equal(expect, result);
  
        }
    }

}