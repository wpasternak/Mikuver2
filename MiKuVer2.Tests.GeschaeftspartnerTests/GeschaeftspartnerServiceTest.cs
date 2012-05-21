using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Tests.GeschaeftspartnerTests
{
    using MiKuVer2.Model;
    using MiKuVer2.Services;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    class GeschaeftspartnerServiceTest
    {
        private IGeschaeftspartnerService sut = new GeschaeftspartnerService();

        private List<Geschaeftspartner> geschaeftspartner = new List<Geschaeftspartner>();

        private Geschaeftspartner willi = new Geschaeftspartner()
            {
                Nachname = "Pasternak",
                Vorname = "Willi",
                Eintrittsdatum = DateTime.Now,
                EMail = "willi.pasternak@ergo.de",
                Id = 1
            };

        private Geschaeftspartner kristl = new Geschaeftspartner()
        {
            Nachname = "Stanojevic",
            Vorname = "Kristina",
            Eintrittsdatum = DateTime.Now,
            EMail = "kristina.stanojevic@ergo.de",
            Id = 0
        };
        
        [SetUp]
        public void Setup()
        {
            geschaeftspartner.Add(willi);
            geschaeftspartner.Add(kristl);
        }

        [TearDown]
        public void ClearTest()
        {
            geschaeftspartner.Clear();
        }

        [Test]
        public void GetGeschaeftspartnerById()
        {
            // arrange
            var mock = new Mock<IGeschaeftspartnerRepository>();
            mock.Setup(repo => repo.GetGeschaeftspartner(0)).Returns(kristl);
            sut.GeschaeftspartnerRepository = mock.Object;

            // act
            Geschaeftspartner geschaeftspartner1 = sut.GetGeschaeftspartner(0);

            // assert
            Assert.AreEqual(kristl,geschaeftspartner1);
        }

        [Test]
        public void GetGeschaeftspartnerByName()
        {
            // arrange
            var mock = new Mock<IGeschaeftspartnerRepository>();
            mock.Setup(repo => repo.GetGeschaeftspartner("Kristina")).Returns(kristl);
            sut.GeschaeftspartnerRepository = mock.Object;

            // act
            Geschaeftspartner geschaeftspartner1 = sut.GetGeschaeftspartner(0);

            // assert
            Assert.AreEqual(kristl, geschaeftspartner1);
        }


    }
}
