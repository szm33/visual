using GraphicalData.Model;
using System.Collections.Generic;


namespace Service
{
    public interface IDataRepository
    {
        IEnumerable<Vendor> GetAllVendors();
        Vendor GetVendorByName(string name);
        Vendor GetVendroById(int id);
        void AddVendor(Vendor vendor);
        void UpdateVendorName(string name, int id);
        void DeleteVendor(int id);

    }
}
