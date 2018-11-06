using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PharmaceuticalsAppTests.Models
{
    [TestClass()]
    public class PharmaceuticalTests
    {
        [TestMethod()]
        public void FormattedDescriptionTest()
        {
            var pharmaceuticalRepository = new PharmaceuticalRepositoryDummy();

            var pharmaceutical = pharmaceuticalRepository.Get().First();

            var expected = "Ant-Acid medication;\r\nComes in a 100ml bottle;\r\nAvailable over the counter and maybe cheaper;\r\n";

            Assert.AreEqual(expected, pharmaceutical.FormattedDescription);

        }
    }
}