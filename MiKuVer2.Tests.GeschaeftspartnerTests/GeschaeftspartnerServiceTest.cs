using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Tests.GeschaeftspartnerTests
{
    using MiKuVer2.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    class GeschaeftspartnerServiceTest
    {
        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IGeschaeftspertnerRepository>();
        }
    }
}
