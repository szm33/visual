using System;
using System.Collections.Generic;
using System.Linq;
using GraphicalData.Model;

namespace Service
{
    public class DataRepository : IDataRepository
    {
        public IEnumerable<Vendor> GetAllVendors()
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                return (from vendor in db.Vendor
                        select vendor).ToList();
            }
        }

        public Vendor GetVendorByName(string name)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                return (from vendor in db.Vendor
                        where vendor.Name == name
                        select vendor).First();
            }
        }

        public Vendor GetVendroById(int id)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                return (from vendor in db.Vendor
                        where vendor.BusinessEntityID == id
                        select vendor).First();
            }
        }

        public void AddVendor(Vendor vendor)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                db.Vendor.InsertOnSubmit(vendor);
                db.SubmitChanges();
            }
        }

        public void UpdateVendorName(string name, int id)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Vendor vendorToUpdate = (from v in db.Vendor
                                         where v.BusinessEntityID == id
                                         select v).SingleOrDefault();
                vendorToUpdate.Name = name;
                db.SubmitChanges();
            }
        }

        public void DeleteVendor(int id)
        {
            using (DataBaseDataContext db = new DataBaseDataContext())
            {
                Vendor vendorToDelete = (from v in db.Vendor
                                         where v.BusinessEntityID == id
                                         select v).SingleOrDefault();
                db.Vendor.DeleteOnSubmit(vendorToDelete);
                db.SubmitChanges();
            }
        }
    }
}
