namespace Sat.Recruitment.Core.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string? Extract(this string input, int len)
        {
            return input?[0..Math.Min(input.Length, len)];
        }

        public static string? ExtractRight(this string input, int len)
        {
            return input?.Substring(input.Length - len, len);
        }

        public static bool CanStringConvertedToNumber(this string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int ConvertStringToNumber(this string input)
        {
            return Convert.ToInt32(input);
        }
    }
}
