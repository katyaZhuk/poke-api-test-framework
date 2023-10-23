namespace Api.Test.StepDefinitions
{
   public class ScenarioData
   {
      private static ScenarioContext _context;

      protected ScenarioData(ScenarioContext context)
      {
         _context = context;
      }

      public static string JsonDataSource
      {
         get => _context.ContainsKey(nameof(JsonDataSource)) ? _context.Get<string>(nameof(JsonDataSource)) : null;

         set => _context.Set(value, nameof(JsonDataSource));
      }
   }
}
