namespace Bootstrapper.Tests
{
    using System;
    using System.Linq;

    using WebAPI.App_Start;

    using Ninject;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ModulesTests
    {
        [TestMethod]
        public void Ninject_Kernel_Should_Be_Created_Successfuly()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ServiceLayerModule_Should_Exists()
        {
            ServiceLayerModule serviceLayerModule = new ServiceLayerModule();

            Assert.IsNotNull(serviceLayerModule);
        }

        [TestMethod]
        public void ServiceLayerModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                ServiceLayerModule module = modules.FirstOrDefault(m => m.Name == "Bootstrapper.ServiceLayerModule") as ServiceLayerModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("Bootstrapper.ServiceLayerModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DataLayerModule_Should_Exists()
        {
            DataLayerModule dataLayerModule = new DataLayerModule();

            Assert.IsNotNull(dataLayerModule);
        }

        [TestMethod]
        public void DataLayerModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                DataLayerModule module = modules.FirstOrDefault(m => m.Name == "Bootstrapper.DataLayerModule") as DataLayerModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("Bootstrapper.DataLayerModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Kernel_Should_Have_2_Modules()
        {
            IKernel kernel = NinjectWebCommon.CreateKernel();

            var modules = kernel.GetModules().ToList();

            Assert.AreEqual(2, modules.Count());
        }
    }
}