namespace Api.Core.Attributes
{
   public class HttpGetAttribute : EndpointUrlAttribute
   {
      public HttpGetAttribute(string url)
         : base(url)
      {
         HttpMethod = HttpMethod.Get;
      }
   }
}
