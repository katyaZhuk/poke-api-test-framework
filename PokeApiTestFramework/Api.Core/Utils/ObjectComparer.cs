using KellermanSoftware.CompareNetObjects;

namespace Api.Core.Utils
{
   public static class ObjectComparer
   {
      public static void CompareObjects<TActual, TExpected>(TActual actual, TExpected expected)
      {
         CompareLogic compareLogic = new CompareLogic
         {
            Config =
                {
                    CaseSensitive = false,
                    MaxDifferences = 10,
                }
         };
         ComparisonResult result = compareLogic.Compare(actual, expected);
         Assert.That(result.AreEqual, result.DifferencesString);
      }
   }
}
