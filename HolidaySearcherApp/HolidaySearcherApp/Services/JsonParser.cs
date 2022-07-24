using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace HolidaySearcherApp.Services
{
    public class JsonParser
    {
        public List<T> ParseDeserializeList<T>(string json) =>
            JsonConvert.DeserializeObject<List<T>>(json)!;

        public T ParseDeserialize<T>(string json) =>
            JsonConvert.DeserializeObject<T>(json)!;

        public string ParseSerialize<T>(List<T> itemToSerialize) =>
            JsonConvert.SerializeObject(itemToSerialize);

        public bool IsValidJson(string json)
        {
            try
            {
                var obj = JContainer.Parse(json);
                return true;
            }
            catch (JsonReaderException jex)
            {
                Debug.WriteLine($"{jex.Message}"); //would look to write to a logger here
                Console.WriteLine("An invalid Json character was detected..Please try again");
                return false;
            }
        }
    }
}