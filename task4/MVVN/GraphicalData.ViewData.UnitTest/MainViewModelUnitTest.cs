﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalData.ViewDataStandard;
using GraphicalData.Model;
using System.Linq;
using System.Threading;

namespace GraphicalData.ViewData.UnitTest
{
    [TestClass]
    public class MainViewModelUnitTest
    {
       
        [TestMethod]
        public void AddVendorTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = new ViewModelHelperConcrete();
            viewModel.DataRepository = new DataRepositoryConcrete();
            viewModel.Name = "test";
            viewModel.Id = 3;
            viewModel.AddVendorCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual(3, viewModel.DataRepository.GetAllVendors().ToList().Count);
        }

        [TestMethod]
        public void DeleteVendorTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.DataRepository = new DataRepositoryConcrete();
            viewModel.ViewModelHelper = new ViewModelHelperConcrete();
            viewModel.Id = 2;
            viewModel.RemoveVendorCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual(1, viewModel.DataRepository.GetAllVendors().ToList().Count);
        }

        [TestMethod]
        public void UpdateVendorTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = new ViewModelHelperConcrete();
            viewModel.DataRepository = new DataRepositoryConcrete();
            viewModel.Id = 2;
            viewModel.Name = "vendorTest";
            viewModel.UpdateVendorCommand.Execute(null);
            Thread.Sleep(500);
            Assert.AreEqual("vendorTest", viewModel.DataRepository.GetVendroById(2).Name);
        }

        [TestMethod]
        public void DataRepositoryTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.DataRepository = new DataRepositoryConcrete();
            viewModel.ViewModelHelper = new ViewModelHelperConcrete();
            Assert.IsNotNull(viewModel.DataRepository);
        }

        [TestMethod]
        public void VendorsFetchTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.DataRepository = new DataRepositoryConcrete();
            viewModel.ViewModelHelper = new ViewModelHelperConcrete();
            Thread.Sleep(500);
            Assert.AreEqual(2, viewModel.Vendors.Count);
        }
    }
}
