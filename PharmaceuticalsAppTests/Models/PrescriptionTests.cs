using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmaceuticalsApp.Models;

namespace PharmaceuticalsAppTests.Models
{
    [TestClass()]
    public class PrescriptionTests
    {
        [TestMethod()]
        public void NumberOfPharmaceuticalsTest()
        {
            var prescription = new Prescription();
            Assert.AreEqual(0, prescription.NumberOfPharmaceuticals);
        }


        [TestMethod()]
        public void AddPrescriptionItemTest()
        {
            var prescription = new Prescription();

            prescription.AddPrescriptionItem("Name", 5, 7, 10, false, "Comment");
            Assert.AreEqual(1, prescription.NumberOfPharmaceuticals);

            prescription.AddPrescriptionItem("Name2", 5, 7, 10, false, "Comment");
            Assert.AreEqual(2, prescription.NumberOfPharmaceuticals);
        }

        [TestMethod()]
        public void AddExistingPrescriptionItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NumberOfContainersTest()
        {
            var prescription = new Prescription();

            prescription.AddPrescriptionItem("Name", 5, 7, 10, false, "Comment");
            Assert.AreEqual(4, prescription.NumberOfContainers);

            prescription.AddPrescriptionItem("Name2", 8, 7, 10, false, "Comment");
            Assert.AreEqual(10, prescription.NumberOfContainers);
        }

        [TestMethod()]
        public void RemovePrescriptionItemTest()
        {
            var prescription = new Prescription();

            prescription.AddPrescriptionItem("Name", 5, 7, 10, false, "Comment");
            prescription.AddPrescriptionItem("Name2", 5, 7, 10, false, "Comment");
            Assert.AreEqual(2, prescription.NumberOfPharmaceuticals);

            prescription.RemovePrescriptionItem("Name");
            Assert.AreEqual(1, prescription.NumberOfPharmaceuticals);

            prescription.RemovePrescriptionItem("Name2");
            Assert.AreEqual(0, prescription.NumberOfPharmaceuticals);
        }

        [TestMethod()]
        public void ClearPrescriptionTest()
        {
            var prescription = new Prescription();

            prescription.AddPrescriptionItem("Name", 5, 7, 10, false, "Comment");
            prescription.AddPrescriptionItem("Name2", 5, 7, 10, false, "Comment");
            Assert.AreEqual(2, prescription.NumberOfPharmaceuticals);

            prescription.ClearPrescription();
            Assert.AreEqual(0, prescription.NumberOfPharmaceuticals);
        }
    }
}