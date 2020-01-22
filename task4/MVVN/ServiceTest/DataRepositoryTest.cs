using Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GraphicalData.Model;
using System;

namespace ServiceTest
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void AddVendorTest()
        {
            IDataRepository repo = new DataRepository();
            int recordsCount = repo.GetAllVendors().ToList().Count();
            Vendor vendor1 = new Vendor
            {
                Name = "vendor1",
                BusinessEntityID = 1,
                AccountNumber = "AAAAA1",
                CreditRating = 1,
                PreferredVendorStatus = true,
                ActiveFlag = true,
                ModifiedDate = DateTime.Now
            };
            repo.AddVendor(vendor1);

            Assert.AreEqual(recordsCount + 1, repo.GetAllVendors().ToList().Count());
        }

        [TestMethod]
        public void DeleteVendorTest()
        {
            IDataRepository repo = new DataRepository();
            int recordsCount = repo.GetAllVendors().ToList().Count();

            repo.DeleteVendor(1);
            Assert.AreEqual(recordsCount - 1, repo.GetAllVendors().ToList().Count());
        }

        [TestMethod]
        public void UpdateVendorTest()
        {
            IDataRepository repo = new DataRepository();
            Vendor vendor1 = new Vendor
            {
                Name = "vendor1",
                BusinessEntityID = 2,
                AccountNumber = "AAAAA1",
                CreditRating = 1,
                PreferredVendorStatus = true,
                ActiveFlag = true,
                ModifiedDate = DateTime.Now
            };
            repo.AddVendor(vendor1);
            repo.UpdateVendorName("vendor2", 2);
            Assert.AreEqual("vendor2", repo.GetVendroById(2).Name);
            repo.DeleteVendor(2);
        }

    }
}
