using NUnit.Framework;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Tests
{
    public class RecruiterRepoTests
    {
        private RecruiterRepo repo;

        [SetUp]
        public void Setup()
        {
            repo = new RecruiterRepo();
        }

        [TestCase(1)]
        public void GetItemAsync_WhenCalled_ReturnItem(int id)
        {
            int recId = id;
            var rec = repo.GetItemAsync(id);
            Assert.AreEqual(recId, rec.Id);
        }

        [Test]
        public void GetAllItemsAsync_WhenCalled_ReturnItems()
        {
            var devs = repo.GetAllItemsAsync();
            Assert.IsNotNull(devs);
        }
    }
}