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
            int anzahl;
            Geschaeftspartner neuerGP = new Geschaeftspartner()
                {
                    Eintrittsdatum = DateTime.Now,
                    EMail = "test@test.de",
                    Vorname = "Test",
                    Nachname = "Testman",
                    Vorgesetzter = sut.GetGeschaeftspartner(0),
                };

            // act
            var result = sut.GeschaeftspartnerSpeichern(neuerGP);
            var gpAusRepo = sut.GetGeschaeftspartner(5);

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(2,sut.GetDirekteGeschaeftspartner().Count);
            Assert.IsNotNull(gpAusRepo);
            Assert.Greater(neuerGP.Id,0);
        }

        [Test]
        public void GeschaeftspartnerAktualisierenTest()
        {
            // arrange
            int id = 1;
            Geschaeftspartner bearbeteterGP = sut.GetGeschaeftspartner(id);
            Geschaeftspartner gpAusRepo;
            bool result = false;
            string neuerName = "WilliWill";
            DateTime geburtstag = new DateTime(1988,6,21);
            
            // act
            bearbeteterGP.Vorname = neuerName;
            bearbeteterGP.Geburtstag = geburtstag;
            result = sut.GeschaeftspartnerAktualisieren(bearbeteterGP);
            gpAusRepo = sut.GetGeschaeftspartner(id);

            // assert
            Assert.AreEqual(neuerName,gpAusRepo.Vorname);
            Assert.AreEqual(geburtstag,gpAusRepo.Geburtstag);
            Assert.IsTrue(result);
        }

        [Test]
        public void GeschaeftspartnerSuchenTest()
        {
            // arrange
            List<Geschaeftspartner> result;

            // act
            
            // assert
            Assert.Inconclusive();
        }
    }
}
