using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Api.Core.Extentions
{
   public static class StringExtensions
   {
      public static string FormatJsonOrDefault(this string json)
      {
         try
         {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);

            var options = new JsonSerializerSettings
            {
               Formatting = Formatting.Indented,
               DateTimeZoneHandling = DateTimeZoneHandling.Utc,
               ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            options.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(parsedJson, options);
         }
         catch (Exception)
         {
            return json;
         }
      }
   }
}
