using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ProjectMEJN.Model
{
    class SpelSpelerPionDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<SpelSpelerPion> GetSpelSpelers(int spelid)
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Spelspelerpion order by ID where spelid = "+spelid+"";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<SpelSpelerPion>)db.Query<SpelSpelerPion>(sql);
        }
        public void UpdateSpelSpeler(SpelSpelerPion spelspelerpion, int id,int aantal, int spelid)
        {
            // SQL statement insert
            if (aantal < 16)
            {
                for (int i = 1; i < 5; i++)
                {
                    int positienummer = 56 + i;
                    string sql = "Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + ","+spelid+", " + positienummer + ", 'Blauw',0)";
                    string nieuwsql = "insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) Select " + id + " Where not exists(select * from Spelspelerpion where spelerid = " + id + ")";
                    string newsql = "If select count(*) from Spelspelerpion where spelerid='"+id+ "' having count(*)<4 Begin Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + ", 1, " + positienummer + ", 'Blauw',0) End";
                    // Uitvoeren SQL statement en doorgeven parametercollectie
                    db.Execute(sql, new
                    {
                        spelspelerpion.SpelerId,
                        spelspelerpion.SpelId,
                        spelspelerpion.Positie,
                        spelspelerpion.Kleur,
                        spelspelerpion.IsBinnen
                    });
                }
            }
            
            
        }
        //public void VerwijderSpelSpeler(SpelSpelerPion spelspelerpion)
        //{
        //    // SQL statement update 
        //    string sql = "Update Lid set Gaatmee = @neemtDeel where id = @id";

        //    // Uitvoeren SQL statement en doorgeven parametercollectie
        //    db.Execute(sql, new
        //    {
        //        neemtDeel,
        //        lid.Id
        //    });
        //}
    }

    
}
