using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Test.ModelTest
{
    using System.Text.RegularExpressions;

    using MiKuVer2.Model;

    using NUnit.Framework;

    [TestFixture]
    public class GeschaeftspartnerTest
    {

        [Test]
        public void NewInstanceOfGeschaeftspartner()
        {
            // arrange
            Geschaeftspartner gp = new Geschaeftspartner();
 
            // act

            // assert
            Assert.IsNotNull(gp,"Kein GP Object erstellt !");
            Assert.IsNotNull(gp.Partner, "Liste der GP´s nicht initialisiert !");
            Assert.IsNotNull(gp.Eintrittsdatum, "Kein Eintrittsdatum gesetzt !");
        }

        [Test]
        public void PLZisValid()
        {
            // arrange
            Geschaeftspartner geschaeftspartner = new Geschaeftspartner(){PLZ = "78554"};
            Regex re = new Regex(@"^(D-)?\d{5}$");

            // act

            // assert
            Assert.IsTrue(re.Match(geschaeftspartner.PLZ).Success);
        }
    }
}
