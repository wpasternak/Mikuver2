using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;

namespace MiKuVer2.Repositories.Geschaeftspartner.MySQL
{
    using System.ComponentModel.Composition;
    using System.Data;

    using MiKuVer2.Model;

    using MySql.Data.MySqlClient;

    //todo: aktuell eingelogten GP setzen
    [Export(typeof(IGeschaeftspartnerRepository))]
    class GeschaeftspartnerRepository : IGeschaeftspartnerRepository
    {
        private MySqlConnection connection;

        public GeschaeftspartnerRepository()
        {
            this.connection = new MySqlConnection("Server=localhost;Database=mikuver2;Uid=root;Pwd=851778;");
            this.connection.Open();
        }

        ~GeschaeftspartnerRepository()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Gibt alle direkten Geschaeftsparner zurueck
        /// </summary>
        /// <returns>Liste aller direkten Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetDirekteGeschaeftspartner()
        {

            var gpsIds = new List<int>();

            var command = new MySqlCommand("SELECT ID FROM geschaeftspartner WHERE Vorgesetzter=@id",this.connection);
            command.Parameters.AddWithValue("@id", 1);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    gpsIds.Add(reader.GetInt32(0));
                }
            }

            reader.Close();
            reader.Dispose();

            return gpsIds.Select(gpsId => this.GetGeschaeftspartner(gpsId)).ToList();
        }

        /// <summary>
        /// Gibt alle Geschaeftspartner zurueck
        /// </summary>
        /// <returns>Liste aller Geschaeftspartner</returns>
        public List<Geschaeftspartner> GetAlleGeschaeftspartner()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gibt den Geschaeftspartner zurueck
        /// </summary>
        /// <param name="id">Die Id des Geschaeftspartners</param>
        /// <returns>Einen Geschaeftspartner</returns>
        public Geschaeftspartner GetGeschaeftspartner(int id)
        {
            var command = new MySqlCommand("SELECT Eintrittsdatum, PersonId FROM geschaeftspartner WHERE id=@id",this.connection);
            command.Parameters.AddWithValue("@id", id);

            var result = new Geschaeftspartner();
            int personId = 0;
            int vorgesetzterId = 0;

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Eintrittsdatum = reader.GetDateTime(0);
                        result.Id = id;
                        personId = reader.GetInt32(1);
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                reader.Dispose();
                throw;
            }

            command = new MySqlCommand("SELECT * FROM person WHERE id=@id",this.connection);
            command.Parameters.AddWithValue("@id", personId);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                    result.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                    result.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                    result.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                    result.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                    result.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                    result.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                    result.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                    result.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                    result.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                }
            }

            reader.Close();
            reader.Dispose();

            return result;
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
