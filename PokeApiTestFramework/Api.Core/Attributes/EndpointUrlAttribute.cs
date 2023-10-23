namespace Api.Core.Attributes
{
   public class EndpointUrlAttribute : Attribute
   {
      protected EndpointUrlAttribute(string url)
      {
         Uri = url;
      }

      public HttpMethod HttpMethod { get; protected set; }

      public string Uri { get; }

   }
}
