using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMEJN.Model
{
    class SpelDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Spel> GetSpellen()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Spel order by ID";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<Spel>)db.Query<Spel>(sql);
        }
        public void UpdateSpel(Spel spel)
        {
            // SQL statement update 
            string sql = "BEGIN IF NOT EXISTS (SELECT * FROM Spel WHERE Naam = @naam AND datum = @datum) BEGIN Update Spel set Naam = @naam, Datum = @datum where id = @id END END";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            if (spel.Naam != "" && spel.Datum != "")
            {
                db.Execute(sql, new
                {
                    spel.Naam,
                    spel.Datum,
                    spel.ID
                });
            }
              
        }
        public void AddSpel(Spel spel)
        {
            // SQL statement insert
            //string sql = "Insert into Spel (naam, datum) values (@naam, @datum)";
            string newsql = "BEGIN IF NOT EXISTS (SELECT * FROM Spel WHERE Naam = @naam AND datum = @datum) BEGIN INSERT INTO Spel(naam, datum) values (@naam, @datum) END END";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            if (spel.Datum != null && spel.Naam != null)
            {
                db.Execute(newsql, new
                {
                    spel.Naam,
                    spel.Datum
                });
            }
            
        }

        public void DeleteSpel(Spel spel)
        {
            string spelpion = "Delete Spelspelerpion where spelid=@id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(spelpion, new { spel.ID });

            // SQL statement delete 
            string sql = "Delete Spel where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { spel.ID });
                        
        }
    }
}
