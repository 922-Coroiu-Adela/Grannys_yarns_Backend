using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;
using Grannys_yarns_API.Service;

namespace Grannys_yarns_Tests
{
    
    public class ServiceTests
    {
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
        }
    }
}