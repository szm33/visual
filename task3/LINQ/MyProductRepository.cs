using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class MyProductRepository
    {
        List<MyProduct> myProducts = new List<MyProduct>();

        public MyProductRepository()
        {
            List<Product> products = Queries.GetAllProducts();
            foreach(Product product in products)
            {
                myProducts.Add(new MyProduct(product));
            }
        }

        public List<MyProduct> GetMyProductsList()
        {
            return myProducts;
        }


    }
}
