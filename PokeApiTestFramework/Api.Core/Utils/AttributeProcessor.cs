using Api.Core.Attributes;
using System.Diagnostics;
using System.Reflection;

namespace Api.Core.Utils
{
   internal class AttributeProcessor
   {
      internal static string GetEndpointUrl()
      {
         return GetEndpointUrlAttribute().Uri;
      }

      internal static HttpMethod GetHttpMethod()
      {
         return GetEndpointUrlAttribute().HttpMethod;
      }

      private static EndpointUrlAttribute GetEndpointUrlAttribute()
      {
         var stackTrace = new StackTrace();

         var endpointUrlAttribute = stackTrace.GetFrames()
            .Select(frame => frame?.GetMethod()?.GetCustomAttribute<EndpointUrlAttribute>(true))
            .FirstOrDefault(attribute => attribute != null);

         return endpointUrlAttribute;
      }
   }
}
