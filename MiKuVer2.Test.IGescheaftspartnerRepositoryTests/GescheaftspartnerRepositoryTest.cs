using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Test.IGescheaftspartnerRepositoryTests
{
    using MiKuVer2.Model;
    using MiKuVer2.Repositories.Geschaeftspartner.Fake;

    using NUnit.Framework;

    [TestFixture]
    public class GescheaftspartnerRepositoryTest
    {
        private IGeschaeftspartnerRepository sut;

        [SetUp]
        public void Setup()
        {
            sut = new GescheaftspartnerRepositoryFake();
        }

        [TearDown]
        public void ClearTest()
        {
            sut = null;
        }

    }
}
