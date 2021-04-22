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
            // Type casten van het generieke return type naar een collectie van spelers
            return (List<Speler>)db.Query<Speler>(sql);
        }

        public List<SpelSpelerPion> GetspecificSpelers(int spelerid)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Spelspelerpion where spelerid = '"+spelerid+"' order by ID";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van spelers
            return (List<SpelSpelerPion>)db.Query<SpelSpelerPion>(sql);
        }

        public void UpdateSpeler(Speler speler)
        {
            // SQL statement update 
            string sql = "BEGIN IF NOT EXISTS(SELECT* FROM Speler WHERE Voornaam = @voornaam AND Familienaam = @familienaam) BEGIN Update Speler set Voornaam = @voornaam, familienaam = @familienaam where id = @id END END";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            if (speler.Voornaam != "" && speler.Familienaam != "")
            {
                db.Execute(sql, new
                {
                    speler.Voornaam,
                    speler.Familienaam,
                    speler.ID
                });
            }
            
        }
        public void AddSpeler(Speler speler)
        {
            // SQL statement insert
            string sql = "BEGIN IF NOT EXISTS(SELECT* FROM Speler WHERE Voornaam = @voornaam AND Familienaam = @familienaam) BEGIN INSERT INTO Speler(Voornaam, Familienaam) values(@voornaam, @familienaam) END END";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            if(speler.Voornaam != null && speler.Familienaam != null)
            {
                db.Execute(sql, new
                {
                    speler.Voornaam,
                    speler.Familienaam
                });
            }
            
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
