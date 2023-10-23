namespace Api.Core.Rest.Request
{
   public class Route
   {
      public Route(Dictionary<string, string> routes)
      {
         Dictionary = routes;
      }

      public Dictionary<string, string> Dictionary { get; }
   }
}
