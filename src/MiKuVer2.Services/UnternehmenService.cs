using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiKuVer2.Services
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;

    using MiKuVer2.Model;

    public class UnternehmenService : IUnternehmenService
    {
        public UnternehmenService()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (ChangeRejectedException exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Gets or sets KundenRepository.
        /// </summary>
        [Import(typeof(IUnternehmenRepository))]
        public IUnternehmenRepository UnternehmenRepository { get; set; }

        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="id">Die Id des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        public Unternehmen GetUnternehmen(int id)
        {
            return this.UnternehmenRepository.GetUnternehmen(id);
        }

        /// <summary>
        /// Gibt ein Unternehmen zurueck
        /// </summary>
        /// <param name="name">Der Name des Unternehmens</param>
        /// <returns>Ein Unternehmen</returns>
        public Unternehmen GetUnternehmen(string name)
        {
            return this.UnternehmenRepository.GetUnternehmen(name);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen gespeichert wurde
        /// </summary>
        /// <param name="neuesUnternehmen">Das zu speichernde Unternehmen</param>
        /// <returns>true oder false</returns>
        public bool UnternehmenSpeichern(Unternehmen neuesUnternehmen)
        {
            return this.UnternehmenRepository.UnternehmenSpeichern(neuesUnternehmen);
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob das Unternehmen aktualisiert wurde
        /// </summary>
        /// <param name="unternehmen">Das vorhandene und zu aktualisierende Unternehmen</param>
        /// <returns>true oder false</returns>
        public bool UnternehmenAktualisieren(Unternehmen unternehmen)
        {
            return this.UnternehmenRepository.UnternehmenAktualisieren(unternehmen);
        }
    }
}
