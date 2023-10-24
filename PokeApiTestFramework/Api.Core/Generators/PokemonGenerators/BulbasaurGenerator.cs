using Api.Core.Models.PokemonModels;

namespace Api.Core.Generators.PokemonGenerators
{
   public class BulbasaurGenerator : BaseGenerator
   {
      public static Pokemon Get()
      {
         return new Pokemon
         {
            Id = 1,
            Name = "bulbasaur",
            Species = new Species
            {
               Name = "bulbasaur",
               Url = "https://pokeapi.co/api/v2/pokemon-species/1/"
            },
            Abilities = new List<PokemonAbility>
            {
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "overgrow",
                     Url = "https://pokeapi.co/api/v2/ability/65/"
                  },
                  Slot = 1
               },
               new PokemonAbility
               {
                  Ability = new Ability
                  {
                     Name = "chlorophyll",
                     Url = "https://pokeapi.co/api/v2/ability/34/"
                  },
                  Slot = 3
               }
            },
            Forms = new List<Form>
            {
               new Form
               {
                  Name = "bulbasaur",
                  Url = "https://pokeapi.co/api/v2/pokemon-form/1/"
               }
            },
            Height = 7,
            Weight = 69
         };
      }
   }
}
