using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ;
using System.Collections.Generic;

namespace LINQTest
{
    [TestClass]
    public class QueriesTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = Queries.GetProductsByName("metal");
            foreach(var p in products)
            {
                System.Diagnostics.Debug.WriteLine(p.Name + p.ProductID);
            }
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Queries.GetProductsByVendorName("Advanced Bicycles");

            foreach (var p in products)
            {
                System.Diagnostics.Debug.WriteLine(p.Name + " " + p.ProductID + " ");
            }
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> productsName = Queries.GetProductNamesByVendorName("Advanced Bicycles");

            foreach(var pn in productsName)
            {
                System.Diagnostics.Debug.WriteLine(pn);
            }
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = Queries.GetProductVendorByProductName("Thin-Jam Hex Nut 9");
            System.Diagnostics.Debug.WriteLine(vendorName);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {

        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Queries.GetNRecentlyReviewedProducts(2);

            foreach (var pn in products)
            {
                System.Diagnostics.Debug.WriteLine(pn.Name);
            }
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Queries.GetNProductsFromCategory("Bikes", 2);

            foreach (var pn in products)
            {
                System.Diagnostics.Debug.WriteLine(pn.Name);
            }
        }

        [TestMethod]
        public void GetTotalStandardCostByCategory()
        {
            decimal standartCost = Queries.GetTotalStandardCostByCategory(Queries.GetProductCategoryByName("Bikes"));
            System.Diagnostics.Debug.WriteLine(standartCost);
        }

        [TestMethod]
        public void test()
        {
            List<Product> products = Queries.GetProductsByName("");

            foreach (var pn in products)
            {
                System.Diagnostics.Debug.WriteLine(pn.Name);
            }
            System.Diagnostics.Debug.WriteLine("");

            System.Diagnostics.Debug.WriteLine(products.ToStringProductsWithVendors());
        }
    }
}
