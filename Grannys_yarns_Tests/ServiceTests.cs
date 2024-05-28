using Grannys_yarns_API.Data;
using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;
using Grannys_yarns_API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Grannys_yarns_Tests
{

    public class ServiceTests
    {
        /*
        [Fact]
        public void TestingGetAllYarns()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var yarns = service.GetAllYarns();
            Assert.Equal(7, yarns.Count);
        }

        [Fact]
        public void TestingGetYarn()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var yarn = service.GetYarn(1);
            Assert.Equal("blue", yarn.color);
        }

        [Fact]
        public void TestingAddYarn()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var yarn = new Yarn
            {
                id = 7,
                name = "Alize Bella Yarn",
                color = "blue",
                price = 16,
                quantity = 15,
                size = 3
            };
            service.AddYarn(yarn);
            Assert.Equal(8, service.GetAllYarns().Count);
        }

        [Fact]
        public void TestingUpdateYarn()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var yarn = new Yarn
            {
                id = 4,
                name = "Alize Bella Yarn",
                color = "pink",
                price = 16,
                quantity = 15,
                size = 3
            };
            service.UpdateYarn(yarn);
            Assert.Equal("pink", service.GetYarn(4).color);
        }

        [Fact]
        public void TestingDeleteYarn()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            service.DeleteYarn(2);
            Assert.Equal(7, service.GetAllYarns().Count);
        }*/
        [Fact]
        public void TestingAddYarn()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var yarn = new Yarn
            {
                yid = 7,
                name = "Alize Bella Yarn",
                color = "blue",
                price = 16,
                quantity = 15,
                size = 3
            };
            service.AddYarn(yarn);
            Assert.Equal(8, service.GetAllYarns().Count);
        }
        

        [Fact]
        public void TestingGetDistributor()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var distributor = service.GetDistributor(1);
            Assert.Equal("Distributor2", distributor.name);
        }

        [Fact]
        public void TestingAddDistributor()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var distributor = new Distributor
            {
                did = 5,
                name = "Distributor5",
                address = "Address5",
                phone = "Phone5"
            };
            var len = service.GetAllDistributors().Count;
            service.AddDistributor(distributor);
            Assert.Equal(len + 1, service.GetAllDistributors().Count);
        }

        [Fact]
        public void TestingUpdateDistributor()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            var distributor = new Distributor
            {
                did = 0,
                name = "Distributor000",
                address = "Address000",
                phone = "0712-000000"
            };
            service.UpdateDistributor(distributor);
            Assert.Equal("0712-000000", service.GetDistributor(0).phone);
        }

        [Fact]
        public void TestingDeleteDistributor()
        {
            var repository = new MemoryRepository();
            var service = new Service(repository);
            service.DeleteDistributor(2);
            Assert.Equal(2, service.GetAllDistributors().Count);
        }
    
    }
}