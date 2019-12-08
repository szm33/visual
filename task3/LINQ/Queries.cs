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
        //            orderby productReview.ReviewDate descending
        //            select product).Take(howManyReviews).ToList();
        //}

        public static List<Product> GetNRecentlyReviewedProducts(int howManyReviews)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    join productReview in db.ProductReview on product.ProductID equals productReview.ProductID
                    orderby productReview.ReviewDate descending
                    select product).Take(howManyReviews).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    join productSubcategory in db.ProductSubcategory on product.ProductSubcategoryID equals productSubcategory.ProductSubcategoryID
                    join productCategory in db.ProductCategory on productSubcategory.ProductCategoryID equals productCategory.ProductCategoryID
                    where productCategory.Name.Equals(categoryName)
                    orderby product.Name ascending
                    select product).Take(n).ToList();
        }

        public static decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    join productSubcategory in db.ProductSubcategory on product.ProductSubcategoryID equals productSubcategory.ProductSubcategoryID
                    join productCategory in db.ProductCategory on productSubcategory.ProductCategoryID equals productCategory.ProductCategoryID
                    where productCategory.Equals(category)
                    select product.StandardCost).Sum();
        }

        public static ProductCategory GetProductCategoryByName(string categoryName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from productCategory in db.ProductCategory
                    where productCategory.Name.Equals(categoryName)
                    select productCategory).First();
        }

        public static List<Vendor> GetVendorsByProductID(int productId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from vendor in db.Vendor
                    join productVendor in db.ProductVendor on vendor.BusinessEntityID equals productVendor.BusinessEntityID
                    join product in db.Product on productVendor.ProductID equals product.ProductID
                    where product.ProductID.Equals(productId)
                    select vendor).ToList();
        }


    public static List<Product> GetAllProducts()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from product in db.Product
                    select product).ToList();

        }
       

    }
}
