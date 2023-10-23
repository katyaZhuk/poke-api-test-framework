using Serilog;

namespace Api.Core.Helpers
{
   public static class Logger
   {
      public static readonly ILogger Log;

      static Logger()
      {
         Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(Path.Combine(DirectoryHelper.GetSolutionDirectory(), "Logging", "ApiLog") + "/logfile.txt", rollingInterval: RollingInterval.Infinite)
            .CreateLogger();
      }
   }
}
