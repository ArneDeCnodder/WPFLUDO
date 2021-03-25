using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ProjectMEJN.Model
{
    class SpelerDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Speler> GetSpelers()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Speler order by ID";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Speler>)db.Query<Speler>(sql);
        }

        public void UpdateSpeler(Speler speler)
        {
            // SQL statement update 
            string sql = "Update Speler set Voornaam = @voornaam, Kleur = @kleur, familienaam = @familienaam where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                speler.Voornaam,
                speler.Familienaam,
                speler.Kleur,
                speler.ID
            });
        }
        public void AddSpeler(Speler speler)
        {
            // SQL statement insert
            string sql = "Insert into Speler (voornaam, familienaam, kleur) values (@voornaam, @familienaam, @kleur)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                speler.Voornaam,
                speler.Familienaam,
                speler.Kleur
            });
        }

        public void DeleteSpeler(Speler speler)
        {
            // SQL statement delete 
            string sql = "Delete Speler where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { speler.ID });
        }
    }
}
