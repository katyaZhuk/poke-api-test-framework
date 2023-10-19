namespace Api.Core.Helpers
{
   public static class DirectoryHelper
   {
      public static string GetSolutionDirectory()
      {
         DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

         while (directory != null && !directory.GetFiles("*.sln").Any())
         {
            directory = directory.Parent;
         }

         return directory.FullName;
      }
   }
}
