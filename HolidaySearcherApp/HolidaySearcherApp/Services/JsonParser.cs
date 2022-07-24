using Newtonsoft.Json;

namespace HolidaySearcherApp.Services
{
    public class JsonParser
    {
        public List<T> ParseDeserializeList<T>(string json) =>
            JsonConvert.DeserializeObject<List<T>>(json)!;
    }
}
