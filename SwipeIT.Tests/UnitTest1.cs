using NUnit.Framework;
using SwipeIT.ViewModels;

namespace SwipeIT.Tests
{
    public class ObservableObject
    {
        private BaseViewModel instance;

        [SetUp]
        public void Setup()
        {
            instance = new BaseViewModel();
        }

        [Test]
        public void GetSingleton_WhenCalled_ReturnInstance()
        {
            Assert.True(false);
        }
    }

    public class DeveloperRepo
    {
        private DeveloperRepo instance;

        [SetUp]
        public void Setup()
        {
            instance = new DeveloperRepo();
        }

        [Test]
        public void GetItemAsync_WhenCalled_ReturnItem()
        {
            Assert.True(false);
        }

        [Test]
        public void GetAllItemsAsync_WhenCalled_ReturnItems()
        {
            Assert.True(false);
        }
    }
}