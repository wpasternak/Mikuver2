using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Test.IGescheaftspartnerRepositoryTests
{
    using MiKuVer2.Model;
    using MiKuVer2.Repositories.Geschaeftspartner.Fake;
    using MiKuVer2.Repositories.Geschaeftspartner.MySQL;

    using NUnit.Framework;

    [TestFixture]
    public class GescheaftspartnerRepositoryTest
    {
        private IGeschaeftspartnerRepository sut;

        [SetUp]
        public void Setup()
        {
            this.sut = new GeschaeftspartnerRepository();
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
            result = sut.GetDirekteGeschaeftspartner(1);

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAlleGeschaeftspartnerTest()
        {
            // arrange
            List<Geschaeftspartner> result;

            // act
            result = sut.GetAlleGeschaeftspartner(1);

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetGeschaeftspartnerByIdTest()
        {
            // arrange
            Geschaeftspartner result;
            
            // act
            result = sut.GetGeschaeftspartner(1);

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNullOrEmpty(result.Nachname);
            Assert.IsNotNullOrEmpty(result.Vorname);
            Assert.AreEqual(1,result.Id);
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
                    EMail = "artur.pasternak@ergo.de",
                    Vorname = "Artur",
                    Nachname = "Pasternak",
                    Geburtstag = DateTime.Parse("21.06.1988"),
                    PLZ = "78554",
                    Ort = "Aldingen",
                    Strasse = "Im Eigenleh",
                    Hausnummer = "37",
                    Telefon = "",
                    Geschlecht = true,
                    Vorgesetzter = sut.GetGeschaeftspartner(2),
                };

            // act
            var result = sut.GeschaeftspartnerSpeichern(neuerGP);
            var gpAusRepo = sut.GetGeschaeftspartner(3);

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(2,sut.GetDirekteGeschaeftspartner(1).Count);
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
