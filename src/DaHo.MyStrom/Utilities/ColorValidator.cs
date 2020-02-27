using DaHo.MyStrom.Models.Enums;
using System.Globalization;

namespace DaHo.MyStrom.Utilities
{
    internal static class ColorValidator
    {
        internal static ValidationResult ValidateFormat(BulbColorMode colorMode, string color)
        {
            switch (colorMode)
            {
                case BulbColorMode.Wrgb:
                    return ValidateWrgb(color);
                case BulbColorMode.Hsv:
                    return ValidateHsv(color);
                case BulbColorMode.Mono:
                    return ValidateMono(color);
                default:
                    return new ValidationResult { Success = false, ValidationError = "An unknown color mode was specified" };
            }
        }

        private static ValidationResult ValidateWrgb(string color)
        {
            if (color.Length != 8)
                return new ValidationResult { Success = false, ValidationError = "The WRGB color must contain exactly 4 bytes (= 8 hex chars)" };

            if (!byte.TryParse(color.Substring(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte _))
                return new ValidationResult { Success = false, ValidationError = "An invalid white value was specified" };

            if (!byte.TryParse(color.Substring(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte _))
                return new ValidationResult { Success = false, ValidationError = "An invalid red value was specified" };

            if (!byte.TryParse(color.Substring(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte _))
                return new ValidationResult { Success = false, ValidationError = "An invalid green value was specified" };

            if (!byte.TryParse(color.Substring(6, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte _))
                return new ValidationResult { Success = false, ValidationError = "An invalid blue value was specified" };

            return new ValidationResult { Success = true };
        }

        private static ValidationResult ValidateHsv(string color)
        {
            var hsvParts = color.Trim(';').Split(';');
            if (hsvParts.Length != 3)
                return new ValidationResult { Success = false, ValidationError = "The HSV-color must be in form of <0..360>;<0..100>;<0..100>" };

            if (!int.TryParse(hsvParts[0], out int hue) || hue < 0 || hue > 360)
                return new ValidationResult { Success = false, ValidationError = "The hue must be an integer between 0 and 360" };

            if (!int.TryParse(hsvParts[1], out int saturation) || saturation < 0 || saturation > 100)
                return new ValidationResult { Success = false, ValidationError = "The saturation must be an integer between 0 and 100" };

            if (!int.TryParse(hsvParts[2], out int brightness) || brightness < 0 || brightness > 100)
                return new ValidationResult { Success = false, ValidationError = "The brightness must be an integer between 0 and 100" };

            return new ValidationResult { Success = true };
        }

        private static ValidationResult ValidateMono(string color)
        {
            var monoParts = color.Trim(';').Split(';');
            if (monoParts.Length != 2)
                return new ValidationResult { Success = false, ValidationError = "The mono-color must be in form of <1..18>;<0..100>" };

            if (!int.TryParse(monoParts[0], out int value) || value < 1 || value > 18)
                return new ValidationResult { Success = false, ValidationError = "The value must be an integer between 1 and 18" };

            if (!int.TryParse(monoParts[1], out int brightness) || brightness < 0 || brightness > 100)
                return new ValidationResult { Success = false, ValidationError = "The brightness must be an integer between 0 and 100" };

            return new ValidationResult { Success = true };
        }


        internal struct ValidationResult
        {
            public bool Success { get; set; }

            public string ValidationError { get; set; }
        }
    }
}
