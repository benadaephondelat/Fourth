namespace DataLayer.Tests
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Data;
    using Models;
    using Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [Obsolete("Use testing database, not the real one. If you call SaveChanges here it will save to the prod database!")]
    public class GenericRepositoryTests
    {
        private IData data;

        [TestInitialize]
        public void SetUp()
        {
            this.data = new Data(ApplicationDbContext.Create());
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_All_Method()
        {
            this.data.Categories.All();
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_Find_Method()
        {
            this.data.Employees.Find(1);
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_Add_Method()
        {
            var region = new Region()
            {
                RegionID = 5,
                RegionDescription = "Region",
                Territories = new List<Territory>()
            };

            this.data.Regions.Add(region);
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_Update_Method()
        {
            var region = new Region()
            {
                RegionID = 5,
                RegionDescription = "RegionUpdated",
                Territories = new List<Territory>()
            };

            this.data.Regions.Update(region);
        }

        [TestMethod]
        public async void GenericRepository_Should_Expose_UpdateAsync_Method()
        {
            var region = new Region()
            {
                RegionID = 5,
                RegionDescription = "RegionUpdated",
                Territories = new List<Territory>()
            };

            var result = Task.Run(() =>
            {
                this.data.Regions.UpdateAsync(region);
            });

            result.Wait();
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_Delete_Method()
        {
            var region = new Region()
            {
                RegionID = 5,
                RegionDescription = "RegionUpdated",
                Territories = new List<Territory>()
            };

            this.data.Regions.Delete(region);

            this.data.Regions.Delete(5);
        }

        [TestMethod]
        public void GenericRepository_Should_Expose_SaveChanges_Method()
        {
            this.data.SaveChanges();
        }

        [TestMethod]
        public async void GenericRepository_Should_Expose_SaveChangesAsync_Method()
        {
            await this.data.SaveChangesAsync();
        }
    }
}