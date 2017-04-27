using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabletennis.Core.Domain;

namespace Tabletennis.Core.Tests.Domain
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void CreateMatch__does_not_throw_error()
        {
            var match = new Match();  
            
            Assert.IsNotNull(match);
        }

        [TestMethod]
        public void CreateMatch__Match_Set_property_is_not_null()
        {
            var match = new Match();

            Assert.IsNotNull(match.Sets);
        }
    }
}
