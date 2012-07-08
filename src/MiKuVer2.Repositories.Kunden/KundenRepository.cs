using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiKuVer2.Model;

namespace MiKuVer2.Repositories.Kunden
{
    using System.ComponentModel.Composition;
    using System.Data;

    using MySql.Data.MySqlClient;

    [Export(typeof(IKundenRepository))]
    class KundenRepository : IKundenRepository
    {
        private MySqlConnection connection;

        public KundenRepository()
        {
            this.connection = new MySqlConnection("Server=localhost;Database=mikuver2;Uid=root;Pwd=851778;");
            this.connection.Open();
        }

        ~KundenRepository()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Gibt alle eigenen Kunden zurueck
        /// </summary>
        /// <returns>Liste aller eigenen Kunden</returns>
        public List<Kunde> GetDirekteKunden()
        {
            var result = new List<Kunde>();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE geschaeftspartnerId=@id AND k.PersonId=p.ID", this.connection);
            command.Parameters.AddWithValue("@id", 1);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var kunde = new Kunde();
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                        result.Add(kunde);
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Gibt alle Kunden von allen Geschaeftspaertnern zurueck
        /// </summary>
        /// <returns>List aller Kunden</returns>
        public List<Kunde> GetAlleKunden()
        {
            var result = new List<Kunde>();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE k.PersonId=p.ID", this.connection);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var kunde = new Kunde();
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                        result.Add(kunde);
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Gibt alle direkten Kunden eines anderen Geschaeftspartners
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste direkter Kunden eines Geschaeftspartners</returns>
        public List<Kunde> GetDirekteKundenVonGeschaeftspartner(int id)
        {
            var result = new List<Kunde>();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE geschaeftspartnerId=@id AND k.PersonId=p.ID", this.connection);
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var kunde = new Kunde();
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                        result.Add(kunde);
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Gibt alle Kunden, eines Geschaeftspartners und aller seiner Geschaeftspartner, zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Liste aller direkten und indirekten Kunden eines Geschaeftspartners</returns>
        public List<Kunde> GetKundenVonGeschaeftspartner(int id)
        {
            var result = new List<Kunde>();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE geschaeftspartnerId=@id AND k.PersonId=p.ID", this.connection);
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var kunde = new Kunde();
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                        result.Add(kunde);
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="id">Die Id des Kunden</param>
        /// <returns>Einen Kunden</returns>
        public Kunde GetKunde(int id)
        {
            var kunde = new Kunde();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE k.ID=@id AND k.PersonId=p.ID", this.connection);
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return kunde;
        }

        /// <summary>
        /// Gibt einen Kunden zurueck
        /// </summary>
        /// <param name="name">Der Name des Kunden</param>
        /// <returns>Einen Kunden</returns>
        public Kunde GetKunde(string name)
        {
            var kunde = new Kunde();

            MySqlCommand command = new MySqlCommand(
                "SELECT k.ID, k.KundeSeit, p.Vorname, p.Nachname, p.Geburtsdatum, p.Fax, p.Telefon, p.Strasse, p.Hausnummer, p.PLZ, p.Ort, p.`E-Mail` FROM Kunden k, Person p WHERE p.Nachname like @name AND k.PersonId=p.ID", this.connection);
            command.Parameters.AddWithValue("@name", name);

            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        kunde.Id = reader.IsDBNull(reader.GetOrdinal("ID")) != true ? reader.GetInt32("ID") : 0;
                        kunde.KundeSeit = reader.IsDBNull(reader.GetOrdinal("KundeSeit")) != true ? reader.GetDateTime("KundeSeit") : DateTime.MinValue;
                        kunde.Vorname = reader.IsDBNull(reader.GetOrdinal("Vorname")) != true ? reader.GetString("Vorname") : "";
                        kunde.Nachname = reader.IsDBNull(reader.GetOrdinal("Nachname")) != true ? reader.GetString("Nachname") : "";
                        kunde.Geburtstag = reader.IsDBNull(reader.GetOrdinal("Geburtsdatum")) != true ? reader.GetDateTime("Geburtsdatum").Date : DateTime.MinValue;
                        kunde.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) != true ? reader.GetString("Fax") : "";
                        kunde.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon")) != true ? reader.GetString("Telefon") : "";
                        kunde.Strasse = reader.IsDBNull(reader.GetOrdinal("Strasse")) != true ? reader.GetString("Strasse") : "";
                        kunde.Hausnummer = reader.IsDBNull(reader.GetOrdinal("Hausnummer")) != true ? reader.GetString("Hausnummer") : "";
                        kunde.PLZ = reader.IsDBNull(reader.GetOrdinal("PLZ")) != true ? reader.GetString("PLZ") : "";
                        kunde.Ort = reader.IsDBNull(reader.GetOrdinal("Ort")) != true ? reader.GetString("Ort") : "";
                        kunde.EMail = reader.IsDBNull(reader.GetOrdinal("E-Mail")) != true ? reader.GetString("E-Mail") : "";
                    }
                }

                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Dispose();
            }

            return kunde;
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde gespeichert wurde
        /// </summary>
        /// <param name="neuerKunde">Der zu speichernde Kunde</param>
        /// <returns>true oder false</returns>
        public bool KundeSpeichern(Kunde neuerKunde,int gpId)
        {
            var command = new MySqlCommand("INSERT INTO person (Vorname, Nachname, Geburtsdatum, GeschlechtID, Fax, Telefon, Strasse, Hausnummer, PLZ, Ort, `E-Mail`) VALUES (@Vorname, @Nachname, @Geburtsdatum, @Geschlecht, @Fax, @Telefon, @Strasse, @Hausnummer, @PLZ, @Ort, @EMail)", this.connection);
            command.Parameters.AddWithValue("@Vorname", neuerKunde.Vorname);
            command.Parameters.AddWithValue("@Nachname", neuerKunde.Nachname);
            command.Parameters.AddWithValue("@Geburtsdatum", neuerKunde.Geburtstag);
            command.Parameters.AddWithValue("@Geschlecht", neuerKunde.Geschlecht);
            command.Parameters.AddWithValue("@Fax", neuerKunde.Fax != "" ? neuerKunde.Fax : null);
            command.Parameters.AddWithValue("@Telefon", neuerKunde.Telefon != "" ? neuerKunde.Telefon : null);
            command.Parameters.AddWithValue("@Strasse", neuerKunde.Strasse != "" ? neuerKunde.Strasse : null);
            command.Parameters.AddWithValue("@PLZ", neuerKunde.PLZ != "" ? neuerKunde.PLZ : null);
            command.Parameters.AddWithValue("@Ort", neuerKunde.Ort != "" ? neuerKunde.Ort : null);
            command.Parameters.AddWithValue("@EMail", neuerKunde.EMail != "" ? neuerKunde.EMail : null);
            command.Parameters.AddWithValue("@Hausnummer", neuerKunde.Hausnummer);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                return false;
            }

            var personId = (int)command.LastInsertedId;

            command = new MySqlCommand("INSERT INTO Kunden (KundeSeit, UnternehmenId, EmpfohlenVon, GeschaeftspartnerID, PersonId) VALUES (@KundeSeit, @UnternehmenId, @EmpfohlenVon, @GeschaeftspartnerID, @PersonId);", this.connection);
            command.Parameters.AddWithValue(
                "@KundeSeit", neuerKunde.KundeSeit != DateTime.MinValue ? neuerKunde.KundeSeit : DateTime.Now);
            command.Parameters.AddWithValue(
                "@UnternehmenID", neuerKunde.Unternehmen != null ? neuerKunde.Unternehmen.Id : 0);
            command.Parameters.AddWithValue(
                "@EmpfohlenVon", neuerKunde.EmpfohlenVon != null ? (object)neuerKunde.EmpfohlenVon.Id : null);
            command.Parameters.AddWithValue("@GeschaeftspartnerID", gpId); // todo: gpId als parameter übergeben
            command.Parameters.AddWithValue("@PersonId", personId);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gibt einen Wert zurueck ob der Kunde aktualisiert wurde
        /// </summary>
        /// <param name="kunden">Der vorhandene und zu aktualisierende Kunde</param>
        /// <returns>true oder false</returns>
        public bool KundenAktualisieren(Kunde kunden)
        {
            var command = new MySqlCommand("Update User SET Vorname=@Vorname, Nachname=@Nachname, Geburtsdatum=@Geburtsdatum, GeschlechtID=@Geschlecht, Fax=@Fax, Telefon=@Telefon, Strasse=@Strasse, Hausnummer=@Hausnummer, PLZ=@PLZ, Ort=@Ort, `E-Mail`=@EMail WHERE ID=@id", this.connection);
            command.Parameters.AddWithValue("@Vorname", kunden.Vorname);
            command.Parameters.AddWithValue("@Nachname", kunden.Nachname);
            command.Parameters.AddWithValue("@Geburtsdatum", kunden.Geburtstag);
            command.Parameters.AddWithValue("@Geschlecht", kunden.Geschlecht);
            command.Parameters.AddWithValue("@Fax", kunden.Fax != "" ? kunden.Fax : null);
            command.Parameters.AddWithValue("@Telefon", kunden.Telefon != "" ? kunden.Telefon : null);
            command.Parameters.AddWithValue("@Strasse", kunden.Strasse != "" ? kunden.Strasse : null);
            command.Parameters.AddWithValue("@PLZ", kunden.PLZ != "" ? kunden.PLZ : null);
            command.Parameters.AddWithValue("@Ort", kunden.Ort != "" ? kunden.Ort : null);
            command.Parameters.AddWithValue("@EMail", kunden.EMail != "" ? kunden.EMail : null);
            command.Parameters.AddWithValue("@Hausnummer", kunden.Hausnummer);
            command.Parameters.AddWithValue("@id", kunden.Id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                return false;
            }

            //var personId = (int)command.LastInsertedId;

            //command = new MySqlCommand("INSERT INTO Kunden (KundeSeit, UnternehmenId, EmpfohlenVon, GeschaeftspartnerID, PersonId) VALUES (@KundeSeit, @UnternehmenId, @EmpfohlenVon, @GeschaeftspartnerID, @PersonId);", this.connection);
            //command.Parameters.AddWithValue(
            //    "@KundeSeit", kunde.KundeSeit != DateTime.MinValue ? kunde.KundeSeit : DateTime.Now);
            //command.Parameters.AddWithValue(
            //    "@UnternehmenID", kunde.Unternehmen != null ? kunde.Unternehmen.Id : 0);
            //command.Parameters.AddWithValue(
            //    "@EmpfohlenVon", kunde.EmpfohlenVon != null ? (object)kunde.EmpfohlenVon.Id : null);
            //command.Parameters.AddWithValue("@GeschaeftspartnerID", gpId); // todo: gpId als parameter übergeben
            //command.Parameters.AddWithValue("@PersonId", personId);

            //try
            //{
            //    command.ExecuteNonQuery();
            //}
            //catch (Exception exception)
            //{
            //    return false;
            //}

            return true;
        }
    }
}
