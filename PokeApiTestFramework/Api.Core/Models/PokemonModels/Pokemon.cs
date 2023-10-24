namespace Api.Core.Models.PokemonModels
{
   public class Pokemon
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public Species Species { get; set; }

      public List<PokemonAbility> Abilities { get; set; }

      public List<Form> Forms { get; set; }

      public int Height { get; set; }

      public int Weight { get; set; }
   }
}
