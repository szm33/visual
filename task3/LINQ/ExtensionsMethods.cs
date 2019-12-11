using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class ExtensionsMethods
    {
        public static List<Product> GetProductsWithoutCategoryImperative(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategoryID == null).Select(p => p).ToList();
        }

        public static List<Product> GetProductsWithoutCategoryDeclarative(this List<Product> products)
        {
            return (from product in products
                    where product.ProductSubcategoryID == null
                    select product).ToList();
        }

        public static List<Product> GetPageWithProductsImperative(this List<Product> products, int pageSize, int pageNumber)
        {
            return products.Where(p => products.IndexOf(p) / pageSize == pageNumber - 1).Select(p => p).ToList();
        }

        public static List<Product> GetPageWithProductsDeclarative(this List<Product> products, int pageSize, int pageNumber)
        {
            return (from product in products
                    where products.IndexOf(product) / pageSize == pageNumber - 1
                    select product).ToList();
        }

        public static string ToStringProductsWithVendors(this List<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Product product in products)
            {
                var vendors = Queries.GetVendorsByProductID(product.ProductID);
                
                foreach(var vendor in vendors)
                {
                    sb.Append(product.Name);
                    sb.Append("-" + vendor.Name);
                    sb.Append(Environment.NewLine);
                }
                
            }

            return sb.ToString();
        }
    }
}
