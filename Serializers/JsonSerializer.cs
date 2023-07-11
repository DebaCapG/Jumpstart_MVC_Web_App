using Newtonsoft.Json;
namespace Jumpstart_MVC_Web_App.Serializers
{
    public class JsonSerializer
    {
        public static string Serialize<T>(List<T> items)
        {
            return JsonConvert.SerializeObject(items);
        }

        public static List<T> Deserialize<T>(string json)
        {
            List<T>? items =  JsonConvert.DeserializeObject<List<T>>(json);
            if(items == null)
            {
                return new List<T> { };
            }

            return items;
        }
    }
}
