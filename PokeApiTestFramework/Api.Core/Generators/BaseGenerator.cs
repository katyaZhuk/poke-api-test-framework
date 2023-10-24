using Bogus;

namespace Api.Core.Generators
{
   public class BaseGenerator
   {
      public static string IncorrectPokemonName() => new Faker().Random.String2(10);
   }
}
