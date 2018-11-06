using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmaceuticalsApp.Models;

namespace PharmaceuticalsAppTests.Models
{
    [TestClass()]
    public class PrescriptionItemTests
    {
        [TestMethod()]
        public void NumberOfContainersTest()
        {
            var item = CreateDefaultPrescriptionItem();

            Assert.AreEqual(4, item.NumberOfContainers);
        }

        [TestMethod()]
        public void UpdateDurationTest()
        {
            var item = CreateDefaultPrescriptionItem();

            Assert.AreEqual(7, item.Duration);

            item.UpdateDuration(7);

            Assert.AreEqual(14, item.Duration);

        }

        private PrescriptionItem CreateDefaultPrescriptionItem()
        {
            return new PrescriptionItem
            (
                "Name",
                5,
                7,
                10,
                false,
                "Comment"
            );
        }
    }
}