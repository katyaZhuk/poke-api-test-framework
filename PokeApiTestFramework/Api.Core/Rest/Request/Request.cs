using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Api.Core.Rest.Request
{
   public class Request
   {
      private object _content;

      public Request()
      {
      }

      public Request(Dictionary<string, string> routes)
      {
         Route = new Route(routes);
      }

      public static HttpCompletionOption CompletionOption => HttpCompletionOption.ResponseContentRead;

      public Route Route { get; }

      public IEnumerable<(string Key, string Value)> QueryParameters { get; set; } = new List<(string Key, string Value)>();

      public object Content
      {
         get => _content == null ? string.Empty : JsonConvert.SerializeObject(_content, GetJsonSerializerSettings());
         set => _content = value;
      }

      public List<(string Key, string Value)> Headers { get; set; } = new List<(String Key, string Value)>();

      private JsonSerializerSettings GetJsonSerializerSettings()
      {
         var options = new JsonSerializerSettings
         {
            Formatting = Formatting.Indented,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
         };

         options.Converters.Add(new StringEnumConverter());

         return options;
      }
   }
}
