using Api.Core.Utils;

namespace Api.Core.Rest.Api
{
   internal class HttpHeaderManager
   {
      internal static IDictionary<string, string> CreateHeader(IDictionary<string, string> headers)
      {
         headers ??= new Dictionary<string, string>();

         return headers;
      }
   }
}
