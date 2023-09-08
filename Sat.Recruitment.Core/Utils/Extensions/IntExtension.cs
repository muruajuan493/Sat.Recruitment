namespace Sat.Recruitment.Core.Utils.Extensions
{
    public static class IntExtension
    {
        public static bool IsEmpty(this int value)
        {
            if (value == 0)
                return true;
            return false;
        }
    }
}
