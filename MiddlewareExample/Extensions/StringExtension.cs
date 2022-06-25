namespace MiddlewareExample.Extensions
{
    public class StringExtension
    {
        public static bool IsValid(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            return false;
        }
    }
}
