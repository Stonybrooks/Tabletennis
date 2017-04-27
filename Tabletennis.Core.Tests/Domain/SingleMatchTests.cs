using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabletennis.Core.Domain;

namespace Tabletennis.Core.Tests.Domain
{
    [TestClass]
    public class SingleMatchTests
    {
        [TestMethod]
        public void CreateMatch__does_not_throw_error()
        {
            Match match = new SingleMatch();  
            
            Assert.IsNotNull(match);
        }

        [TestMethod]
        public void CreateMatch__Match_Set_property_is_not_null()
        {
            var match = new SingleMatch();

            Assert.IsNotNull(match.Sets);
        }
    }
}
