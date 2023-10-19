﻿using Api.Core.Configuration;
using Api.Core.Helpers;
using Microsoft.Extensions.Configuration;

namespace Api.Core
{
   public static class ConfigManagerApi
   {
      static ConfigManagerApi()
      {
         string projectDirectory = Path.Combine(DirectoryHelper.GetSolutionDirectory(), "Api.Core", "Configuration");

         IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectDirectory)
            .AddJsonFile("appsettings.json", false)
            .Build();

         configuration.Bind(Settings);
      }

      public static Settings Settings { get; } = new Settings();
   }
}
