using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Queries
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product 
                    where product.Name.StartsWith(namePart) 
                    select product).ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    join productVendor in db.ProductVendor on product.ProductID equals productVendor.ProductID
                    join vendor in db.Vendor on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                    where vendor.Name.Equals(vendorName)
                    select product).ToList();
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    join productVendor in db.ProductVendor on product.ProductID equals productVendor.ProductID
                    join vendor in db.Vendor on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                    where vendor.Name.Equals(vendorName)
                    select product.Name).ToList();
        }

        public static string GetProductVendorByProductName(string productName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from vendor in db.Vendor
                    join productVendor in db.ProductVendor on vendor.BusinessEntityID equals productVendor.BusinessEntityID
                    join product in db.Product on productVendor.ProductID equals product.ProductID
                    where product.Name.Equals(productName)
                    select vendor.Name).First();
        }

        //public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        //{
        //    DataClasses1DataContext db = new DataClasses1DataContext();
        //    return (from product in db.Product
        //            join productReview in db.ProductReview on product.ProductID equals productReview.ProductID
        //            where )
        //}
    }
}
