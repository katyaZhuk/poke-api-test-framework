using Api.Core.Models.PokemonModels;

namespace Api.Core.Generators.PokemonGenerators
{
   public class MeowthGenerator : BaseGenerator
   {
      public static Pokemon Get()
      {
         return new Pokemon
         {
            Id = 52,
            Name = "meowth",
            Species = new Species
            {
               Name = "meowth",
               Url = "https://pokeapi.co/api/v2/pokemon-species/52/"
            },
            Abilities = new List<PokemonAbility>
            {
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "pickup",
                     Url = "https://pokeapi.co/api/v2/ability/53/"
                  },
                  Slot = 1
               },
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "technician",
                     Url = "https://pokeapi.co/api/v2/ability/101/"
                  },
                  Slot = 2
               },
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "unnerve",
                     Url = "https://pokeapi.co/api/v2/ability/127/"
                  },
                  Slot = 3
               }
            },
            Forms = new List<Form>
            {
               new Form
               {
                  Name = "meowth",
                  Url = "https://pokeapi.co/api/v2/pokemon-form/52/"
               }
            },
            Height = 4,
            Weight = 42
         };
      }
   }
}
