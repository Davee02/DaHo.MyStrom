using DaHo.MyStrom.Models.Enums;
using DaHo.MyStrom.Utilities;
using NUnit.Framework;

namespace DaHo.MyStrom.Tests
{
    public class ColorValidatorTests
    {
        [TestCase(BulbColorMode.Wrgb, "#AABBCCDD", "The WRGB color must contain exactly 4 bytes (= 8 hex chars)")]
        [TestCase(BulbColorMode.Wrgb, "AABBCCD", "The WRGB color must contain exactly 4 bytes (= 8 hex chars)")]
        [TestCase(BulbColorMode.Wrgb, "AABBCCDDe", "The WRGB color must contain exactly 4 bytes (= 8 hex chars)")]
        [TestCase(BulbColorMode.Wrgb, "XABBCCDD", "An invalid white value was specified")]
        [TestCase(BulbColorMode.Wrgb, "AAXBCCDD", "An invalid red value was specified")]
        [TestCase(BulbColorMode.Wrgb, "AABBXCDD", "An invalid green value was specified")]
        [TestCase(BulbColorMode.Wrgb, "AABBCCXD", "An invalid blue value was specified")]
        [TestCase(BulbColorMode.Mono, "5;10;20", "The mono-color must be in form of <1..18>;<0..100>")]
        [TestCase(BulbColorMode.Mono, "1;;", "The mono-color must be in form of <1..18>;<0..100>")]
        [TestCase(BulbColorMode.Mono, "0;10", "The value must be an integer between 1 and 18")]
        [TestCase(BulbColorMode.Mono, "100;10", "The value must be an integer between 1 and 18")]
        [TestCase(BulbColorMode.Mono, "5;-10", "The brightness must be an integer between 0 and 100")]
        [TestCase(BulbColorMode.Mono, "5;120", "The brightness must be an integer between 0 and 100")]
        [TestCase(BulbColorMode.Hsv, "150;50;50;40", "The HSV-color must be in form of <0..360>;<0..100>;<0..100>")]
        [TestCase(BulbColorMode.Hsv, "150;50;", "The HSV-color must be in form of <0..360>;<0..100>;<0..100>")]
        [TestCase(BulbColorMode.Hsv, "-50;50;50", "The hue must be an integer between 0 and 360")]
        [TestCase(BulbColorMode.Hsv, "400;50;50", "The hue must be an integer between 0 and 360")]
        [TestCase(BulbColorMode.Hsv, "150;-50;50", "The saturation must be an integer between 0 and 100")]
        [TestCase(BulbColorMode.Hsv, "150;400;50", "The saturation must be an integer between 0 and 100")]
        [TestCase(BulbColorMode.Hsv, "150;50;-50", "The brightness must be an integer between 0 and 100")]
        [TestCase(BulbColorMode.Hsv, "150;50;400", "The brightness must be an integer between 0 and 100")]
        [Test]
        public void ValidationFails(BulbColorMode colorMode, string color, string expectedErrorMessage)
        {
            var validationResult = ColorValidator.ValidateFormat(colorMode, color);

            Assert.IsFalse(validationResult.Success);
            Assert.AreEqual(expectedErrorMessage, validationResult.ValidationError);
        }

        [TestCase(BulbColorMode.Wrgb, "AABBCCDD")]
        [TestCase(BulbColorMode.Wrgb, "11223344")]
        [TestCase(BulbColorMode.Mono, "1;0")]
        [TestCase(BulbColorMode.Mono, "18;100")]
        [TestCase(BulbColorMode.Hsv, "0;0;0")]
        [TestCase(BulbColorMode.Hsv, "360;100;100")]
        [Test]
        public void ValidationSucceeds(BulbColorMode colorMode, string color)
        {
            var validationResult = ColorValidator.ValidateFormat(colorMode, color);

            Assert.IsTrue(validationResult.Success);
            Assert.AreEqual(null, validationResult.ValidationError);
        }
    }
}