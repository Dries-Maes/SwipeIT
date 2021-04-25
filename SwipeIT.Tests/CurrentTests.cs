using NUnit.Framework;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeIT.Tests
{
    public class CurrentTests
    {
        [Test]
        public void GetSingleton_WhenCalled_ReturnInstancetup()
        {
            var instance = Current.GetSingleton();
            Assert.IsNotNull(instance);
        }
    }
}