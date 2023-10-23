using Api.Core.Rest.Request;
using Api.Core.Utils;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.RegularExpressions;

namespace Api.Core.Rest
{
   public class BaseHttpUrlManager
   {
      public BaseHttpUrlManager()
      {
         BaseUrl = ConfigManagerApi.Settings.Beffe.BaseUrl;
      }

      public string BaseUrl { get; set; }

      internal string GetRequestedUrl(Route route, IDictionary<string, string> urlParameters)
      {
         var url = GetDynamicEndpoint(BaseUrl + AttributeProcessor.GetEndpointUrl(), route);

         if (urlParameters != null)
         {
            url = QueryHelpers.AddQueryString(url, urlParameters);
         }

         return url;
      }

      internal static string GetDynamicEndpoint(string uri, Route route)
      {
         if (!uri.Contains('{') && !uri.Contains('}') || route == null)
         {
            return uri;
         }

         var valueDictionary = GetUriParameterValueDictionary(uri, route);

         return valueDictionary.Aggregate(uri, (current, pair) => current.Replace($"{{{pair.Key}}}", pair.Value));
      }

      private static Dictionary<string, string> GetUriParameterValueDictionary(string uri, Route route)
      {
         var dict = route.Dictionary;

         return GetUriParameters(uri).ToDictionary(s => s, s => dict[s]);
      }

      private static IEnumerable<string> GetUriParameters(string uri)
      {
         var regex = new Regex(@"(?<={)\w*(?=})");

         var matchCollection = regex.Matches(uri);

         return (from Match m in matchCollection select m.Value).ToList();
      }
   }
}
