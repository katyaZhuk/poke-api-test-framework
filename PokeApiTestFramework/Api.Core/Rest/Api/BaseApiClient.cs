namespace Api.Core.Rest.Api
{
   public class BaseApiClient : BaseClient
   {
      protected BaseApiClient()
      {
         Http = new Http<BaseHttpUrlManager>(new HttpUrlManagerBeffe());
      }
   }
}  
