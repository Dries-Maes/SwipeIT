using NUnit.Framework;
using SwipeIT.Models;
using SwipeIT.Services;
using SwipeIT.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwipeIT.Tests
{
    public class DeveloperRepoTests
    {
        private DeveloperRepo repo;

        [SetUp]
        public void Setup()
        {
            repo = new DeveloperRepo();
        }

        [TestCase(1)]
        public void GetItemAsync_WhenCalled_ReturnItem(int id)
        {
            int devId = id;
            var dev = repo.GetItemAsync(id);
            Assert.AreEqual(devId, dev.Id);
        }

        [Test]
        public void GetAllItemsAsync_WhenCalled_ReturnItems()
        {
            var devs = repo.GetAllItemsAsync();
            Assert.IsNotNull(devs);
        }
    }
}