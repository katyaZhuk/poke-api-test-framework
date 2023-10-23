namespace Api.Core.Extentions
{
   public static class EnumerableExtensions
   {
      public static Dictionary<string, string> AddToDictionary(this IEnumerable<(string Key, string Value)> list)
      {
         return list?.ToDictionary(tuple => tuple.Key, tuple => tuple.Value);
      }
   }
}
