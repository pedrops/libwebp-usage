using Newtonsoft.Json.Linq;

namespace NetCore.Domain.Entities.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidJSON(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return false;

                JToken.Parse(value);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
