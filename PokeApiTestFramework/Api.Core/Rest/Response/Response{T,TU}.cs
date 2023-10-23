using Flurl.Http;
using Newtonsoft.Json;

namespace Api.Core.Rest.Response
{
   public class Response<T, TU> : Response<T>
   {
      public Response(IFlurlResponse response)
         : base(response)
      {
         InitModels();
      }

      public TU ProblemDetails { get; private set; }

      private void InitModels()
      {
         var response = Content;

         if (response == string.Empty)
         {
            return;
         }

         try
         {
            var settings = new JsonSerializerSettings
            {
               Error = (se, ev) => { ev.ErrorContext.Handled = true; },
            };

            ProblemDetails = JsonConvert.DeserializeObject<TU>(response, settings);
         }
         catch
         {
            // ignored
         }
      }
   }
}
