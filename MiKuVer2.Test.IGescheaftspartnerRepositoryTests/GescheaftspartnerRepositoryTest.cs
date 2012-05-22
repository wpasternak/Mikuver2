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

        [Test]
        public void GetDirekteGeschaeftspartnerTest()
        {
            // arrange
            List<Geschaeftspartner> result;

            // act
            result = sut.GetDirekteGeschaeftspartner();

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAlleGeschaeftspartnerTest()
        {
            // arrange
            List<Geschaeftspartner> result;

            // act
            result = sut.GetAlleGeschaeftspartner();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4,result.Count);
        }

        [Test]
        public void GetGeschaeftspartnerByIdTest()
        {
            // arrange
            Geschaeftspartner result;
            
            // act
            result = sut.GetGeschaeftspartner(2);

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNullOrEmpty(result.Nachname);
            Assert.IsNotNullOrEmpty(result.Vorname);
            Assert.AreEqual(2,result.Id);
        }

        [Test]
        public void GetGeschaeftspartnerByNameTest()
        {
            Geschaeftspartner result;

            // act
            result = sut.GetGeschaeftspartner("Stanojevic");

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNullOrEmpty(result.Nachname);
            Assert.IsNotNullOrEmpty(result.Vorname);
            Assert.AreEqual(0, result.Id);
        }

        [Test]
        public void GeschaeftspartnerSpeichernTest()
        {
            // arrange

            // act

            // assert
            Assert.Inconclusive();
        }

        [Test]
        public void GeschaeftspartnerAktualisierenTest()
        {
            // arrange

            // act

            // assert
            Assert.Inconclusive();
        }

        [Test]
        public void GeschaeftspartnerSuchenTest()
        {
            // arrange

            // act

            // assert
            Assert.Inconclusive();
        }
    }
}
