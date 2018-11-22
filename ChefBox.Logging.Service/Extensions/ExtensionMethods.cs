using Newtonsoft.Json;

namespace ChefBox.Logging.Service.Extensions
{
    public static class ExtensionMethods
    {
        public static string ToLogJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}
