﻿using System;
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
            List<Product> products = Queries.GetProductsByName("Metal");
            foreach(var p in products)
            {
                Assert.AreEqual("Metal", p.Name.Substring(0,5));
                System.Diagnostics.Debug.WriteLine(p.Name + p.ProductID);
            }
            Assert.AreEqual(14, products.Count);

        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Queries.GetProductsByVendorName("Advanced Bicycles");

            foreach (var p in products)
            {

                System.Diagnostics.Debug.WriteLine(p.Name + " " + p.ProductID + " ");
            }
            Assert.AreEqual(16, products.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> productsName = Queries.GetProductNamesByVendorName("Advanced Bicycles");

            foreach(var pn in productsName)
            {
                System.Diagnostics.Debug.WriteLine(pn);
            }
            Assert.AreEqual(16, productsName.Count);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = Queries.GetProductVendorByProductName("Thin-Jam Hex Nut 9");
            System.Diagnostics.Debug.WriteLine(vendorName);
            Assert.AreEqual("Advanced Bicycles", vendorName);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Queries.GetProductsWithNRecentReviews(1);
            Assert.AreEqual(2, products.Count);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Queries.GetNRecentlyReviewedProducts(2);

            foreach (var pn in products)
            {
                System.Diagnostics.Debug.WriteLine(pn.Name);
            }
            Assert.AreEqual(2, products.Count);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Queries.GetNProductsFromCategory("Bikes", 2);

            foreach (var pn in products)
            {
                System.Diagnostics.Debug.WriteLine(pn.Name);
            }
            Assert.AreEqual(2, products.Count);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            decimal standartCost = Queries.GetTotalStandardCostByCategory(Queries.GetProductCategoryByName("Bikes"));
            System.Diagnostics.Debug.WriteLine(standartCost);
            Assert.AreEqual(92092.8230m, standartCost);
        }

        [TestMethod]
        public void ToStringProductsWithVendorsTest()
        {
            List<Product> products = Queries.GetAllProducts();
            int numLines = products.ToStringProductsWithVendors().Split('\n').Length;
            Assert.AreEqual(461, numLines);

        }

        [TestMethod]
        public void GetProductsWithoutCategoryImperativeTest()
        {
            List<Product> products = Queries.GetAllProducts();
            products = products.GetProductsWithoutCategoryImperative();
            Assert.AreEqual(209, products.Count);
        }

        [TestMethod]
        public void GetProductsWithoutCategoryDeclarativeTest()
        {
            List<Product> products = Queries.GetAllProducts();
            products = products.GetProductsWithoutCategoryDeclarative();
            Assert.AreEqual(209, products.Count);
        }

        [TestMethod]
        public void GetPageWithProductsImperativeTest()
        {
            List<Product> products = Queries.GetAllProducts();
            products = products.GetPageWithProductsImperative(7,2);
            Assert.AreEqual(7, products.Count);
        }

        [TestMethod]
        public void GetPageWithProductsDeclarativeTest()
        {
            List<Product> products = Queries.GetAllProducts();
            products = products.GetPageWithProductsDeclarative(7, 2);
            Assert.AreEqual(7, products.Count);
        }
    }
}
