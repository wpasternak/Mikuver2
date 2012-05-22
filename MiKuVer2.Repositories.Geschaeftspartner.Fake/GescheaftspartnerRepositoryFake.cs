using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiKuVer2.Repositories.Geschaeftspartner.Fake
{
    using System.ComponentModel.Composition;

    using MiKuVer2.Model;

    [Export(typeof(IGeschaeftspartnerRepository))]
    public class GescheaftspartnerRepositoryFake : IGeschaeftspartnerRepository
    {
        private List<Geschaeftspartner> repo = new List<Geschaeftspartner>();

        private Geschaeftspartner angemeldeterUser;


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

        private Geschaeftspartner artur = new Geschaeftspartner()
        {
            Nachname = "Pasternak",
            Vorname = "Artur",
            Eintrittsdatum = DateTime.Now,
            EMail = "artur.pasternak@ergo.de",
            Id = 2
        };

        private Geschaeftspartner katha = new Geschaeftspartner()
        {
            Nachname = "Jerofejewa",
            Vorname = "Katharina",
            Eintrittsdatum = DateTime.Now,
            EMail = "katharina.jerofejewa@ergo.de",
            Id = 3
        };

        private Geschaeftspartner bea = new Geschaeftspartner()
        {
            Nachname = "Hügel",
            Vorname = "Beatrix",
            Eintrittsdatum = DateTime.Now,
            EMail = "beatrix.hügel@ergo.de",
            Id = 4
        };

        public GescheaftspartnerRepositoryFake()
        {
            angemeldeterUser = kristl;
            repo.Add(kristl);
            repo.Add(willi);
            repo.Add(artur);
            repo.Add(katha);
            repo.Add(bea);

            kristl.Partner.Add(willi);
            willi.Partner.AddRange(new List<Geschaeftspartner>(){{artur},{katha}});
            artur.Partner.Add(bea);
        }

        /// <summary>
        /// Gibt alle direkten Geschaeftsparner zurueck
        /// </summary>
        /// <returns>Liste aller direkten Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetDirekteGeschaeftspartner()
        {
            return angemeldeterUser.Partner;
        }

        /// <summary>
        /// Gibt alle Geschaeftspartner zurueck
        /// </summary>
        /// <returns>Liste aller Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetAlleGeschaeftspartner()
        {
            List<Geschaeftspartner> result = new List<Geschaeftspartner>();

            foreach (var partner in angemeldeterUser.Partner)
            {
                result.Add(partner);
                result.AddRange(this.GetAlleGeschaeftspartner(partner));
            }
            return result;
        }

        private List<Geschaeftspartner> GetAlleGeschaeftspartner(Geschaeftspartner geschaeftspartner)
        {
            List<Geschaeftspartner> result = new List<Geschaeftspartner>();

            foreach (var partner in geschaeftspartner.Partner)
            {
                result.Add(partner);
                result.AddRange(this.GetAlleGeschaeftspartner(partner));
            }
            return result;
        } 

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="id">Die Id des Geschaeftspartners</param>
        /// <returns>Einen Geschaeftspartner</returns>
        public Geschaeftspartner GetGeschaeftspartner(int id)
        {
            return this.repo.First(gp => gp.Id == id);
        }

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="name">Der Name des Geschaeftspartners</param>
        /// <returns> Einen Geschaeftspartner</returns>
        public Geschaeftspartner GetGeschaeftspartner(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Geschaeftspartner 
        /// gespeichert wurde
        /// </summary>
        /// <param name="neuerGeschaeftspartner">Der zu speichernde Geschaefts-
        /// partner</param>
        /// <returns>true oder false</returns>
        public bool GeschaeftspartnerSpeichern(Geschaeftspartner neuerGeschaeftspartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der vorhande Geschaeftspartner
        /// aktualisiert wurde
        /// </summary>
        /// <param name="geschaeftspartner">Der vorhande und zu aktualisierende 
        /// Geschaeftspartner</param>
        /// <returns>true oder false</returns>
        public bool GeschaeftspartnerAktualisieren(Geschaeftspartner geschaeftspartner)
        {
            throw new NotImplementedException();
        }
    }
}
