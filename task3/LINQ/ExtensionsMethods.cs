using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class ExtensionsMethods
    {
        public static List<Product> GetProductsWithoutCategory(this List<Product> products)
        {
            List<Product> productsWithoutCategory = new List<Product>();
            foreach (Product product in products)
            {
                if (product.ProductSubcategoryID == null)
                {
                    productsWithoutCategory.Add(product);
                }
            }
            return productsWithoutCategory;
        }

        public static List<Product> GetPageWithProducts(this List<Product> products, int pageSize, int pageNumber)
        {
            return products.Where(p => products.IndexOf(p) / pageSize == pageNumber - 1).Select(p => p).ToList();
        }

        public static string ToStringProductsWithVendors(this List<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Product product in products)
            {
                var vendors = Queries.GetVendorsByProductID(product.ProductID);
                sb.Append(product.Name);
                foreach(var vendor in vendors)
                {
                    sb.Append("-" + vendor.Name);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
