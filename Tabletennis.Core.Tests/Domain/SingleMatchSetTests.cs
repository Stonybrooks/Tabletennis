using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabletennis.Core.Domain;
using Tabletennis.Demo.Domain;

namespace Tabletennis.Core.Tests.Domain
{
    [TestClass]
    public class SingleMatchSetTests
    {
        [TestMethod]
        public void CreateSet__setscore_1_and_2_equals_zero()
        {
            uint expected = 0;
            var set = new Set();

            Assert.AreEqual(expected, set.Score1);
            Assert.AreEqual(expected, set.Score2);
        }

        [TestMethod]
        public void AddSetToMatch__set_property_contains_one_item_after_add()
        {
            // TODO: decide if this test makes any sence to have. It only tests the .net List<T> doesn't it?

            Match match = new SingleMatch();

            match.Sets.Add(new Set());

            Assert.AreEqual(1, match.Sets.Count);
        }
    }
}
