using Api.Core.Extentions;
using Api.Core.Helpers;
using Flurl.Http;
using Newtonsoft.Json;

namespace Api.Core.Rest.Response
{
   public class Response<T> : Response
   {
      public Response(IFlurlResponse response)
         : base(response, false)
      {
         InitModels();
      }

      public T SuccessModel { get; private set; }

      private void InitModels()
      {
         var response = Content;

         if (response == string.Empty)
         {
            Logger.Log.Debug("Response modal has no content");

            return;
         }

         try
         {
            var settings = new JsonSerializerSettings
            {
               Error = (se, ev) => { ev.ErrorContext.Handled = true; }
            };

            SuccessModel = JsonConvert.DeserializeObject<T>(response, settings);
         }
         catch
         {
            Logger.Log.Debug("Response has no valid model inside. Response content:\n" +
               Content.FormatJsonOrDefault());
         }
      }
   }
}
