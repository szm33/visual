using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicalData.Model;
using Service;

namespace GraphicalData.ViewData.UnitTest
{
    class DataRepositoryMock : IDataRepository
    {
        private List<Vendor> vendors = new List<Vendor>();

        public DataRepositoryMock()
        {
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
            Vendor vendor2 = new Vendor
            {
                Name = "vendor2",
                BusinessEntityID = 2,
                AccountNumber = "BBBBB1",
                CreditRating = 1,
                PreferredVendorStatus = true,
                ActiveFlag = true,
                ModifiedDate = DateTime.Now
            };
            vendors.Add(vendor1);
            vendors.Add(vendor2);
        }

        public void AddVendor(Vendor vendor)
        {
            vendors.Add(vendor);
        }

        public void DeleteVendor(int id)
        {
            Vendor v = (from vTmp in vendors
                         where vTmp.BusinessEntityID == id
                         select vTmp).FirstOrDefault();
            vendors.Remove(v);
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return new List<Vendor>(vendors);
        }

        public Vendor GetVendorByName(string name)
        {
            return (from vTmp in vendors
                        where vTmp.Name == name
                        select vTmp).First();
        }

        public Vendor GetVendroById(int id)
        {
            return (from vTmp in vendors
                    where vTmp.BusinessEntityID == id
                    select vTmp).First();
        }

        public void UpdateVendorName(string name, int id)
        {
            vendors.First(v => v.BusinessEntityID == id).Name = name;
        }
    }
}
