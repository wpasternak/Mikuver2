﻿using System;
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
        private IGeschaeftspartnerService sut;

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
            sut = new GeschaeftspartnerService();
            geschaeftspartner.Add(willi);
            geschaeftspartner.Add(kristl);
            kristl.Partner.Add(willi);
        }

        [TearDown]
        public void ClearTest()
        {
            sut = null;
            kristl.Partner.Clear();
            willi.Partner.Clear();
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
            Geschaeftspartner geschaeftspartner1 = sut.GetGeschaeftspartner("Kristina");

            // assert
            Assert.AreEqual(kristl, geschaeftspartner1);
        }

        [Test]
        public void GetDirekteGeschaeftspartnerTest()
        {
            // arrange
            var mock = new Mock<IGeschaeftspartnerRepository>();
            mock.Setup(repo => repo.GetDirekteGeschaeftspartner(1)).Returns(kristl.Partner);
            sut.GeschaeftspartnerRepository = mock.Object;

            // act
            List<Geschaeftspartner> gps = sut.GetDirekteGeschaeftspartner(1);

            // assert
            Assert.IsNotEmpty(gps);
        }

        [Test]
        public void GetAlleGeschaeftspartnerTest()
        {
            // arrange
            var mock = new Mock<IGeschaeftspartnerRepository>();
            mock.Setup(repo => repo.GetAlleGeschaeftspartner(1)).Returns(kristl.Partner);
            sut.GeschaeftspartnerRepository = mock.Object;

            // act
            List<Geschaeftspartner> gps = sut.GetAlleGeschaeftspartner(1);

            // assert
            Assert.IsNotEmpty(gps);
        }

        [Test]
        public void GeschaeftspartnerSpeichernTest()
        {
            // arrange
            var mock = new Mock<IGeschaeftspartnerRepository>();
            mock.Setup(repo => repo.GeschaeftspartnerSpeichern(It.IsAny<Geschaeftspartner>())).Returns(true).Callback(() => geschaeftspartner.Add(new Geschaeftspartner()));
            sut.GeschaeftspartnerRepository = mock.Object;

            // act
            var result = sut.GeschaeftspartnerSpeichern(new Geschaeftspartner());

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(3,geschaeftspartner.Count);
        }


    }
}
