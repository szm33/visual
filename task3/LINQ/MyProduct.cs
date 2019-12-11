using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class MyProduct : Product
    {
        public MyProduct(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
            ProductSubcategoryID = product.ProductSubcategoryID;
            ProductReview = product.ProductReview;

        }
    }
}
