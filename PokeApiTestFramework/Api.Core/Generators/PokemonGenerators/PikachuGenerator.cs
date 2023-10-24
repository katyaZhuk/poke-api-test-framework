using Api.Core.Models.PokemonModels;

namespace Api.Core.Generators.PokemonGenerators
{
   public class PikachuGenerator : BaseGenerator
   {
      public static Pokemon Get()
      {
         return new Pokemon
         {
            Id = 25,
            Name = "pikachu",
            Species = new Species
            {
               Name = "pikachu",
               Url = "https://pokeapi.co/api/v2/pokemon-species/25/"
            },
            Abilities = new List<PokemonAbility>
            {
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "static",
                     Url = "https://pokeapi.co/api/v2/ability/9/"
                  },
                  Slot = 1
               },
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "lightning-rod",
                     Url = "https://pokeapi.co/api/v2/ability/31/"
                  },
                  Slot = 3
               }
            },
            Forms = new List<Form>
            {
               new Form
               {
                  Name = "pikachu",
                  Url = "https://pokeapi.co/api/v2/pokemon-form/25/"
               }
            },
            Height = 4,
            Weight = 60
         };
      }
   }
}
