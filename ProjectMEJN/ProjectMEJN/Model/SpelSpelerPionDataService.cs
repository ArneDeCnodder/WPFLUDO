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
            string sql = "Select * from Spelspelerpion where Spelid like '"+spelid+"'order by ID";

            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<SpelSpelerPion>)db.Query<SpelSpelerPion>(sql);
        }
        public void UpdateSpelSpeler1(SpelSpelerPion spelspelerpion, int id,int aantal, int spelid)
        {
            // SQL statement insert
            if (aantal < 4)
            {
                    int positienummer = 57;
                    string sql = "Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + ","+spelid+", " + positienummer + ", 'Groen',0)";
                    
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
        public void UpdateSpelSpeler2(SpelSpelerPion spelspelerpion, int id, int aantal, int spelid)
        {
            // SQL statement insert
            if (aantal < 4)
            {
                
                    int positienummer = 58;
                    string sql = "Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + "," + spelid + ", " + positienummer + ", 'Blauw',0)";
                    
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

        public void UpdateSpelSpeler3(SpelSpelerPion spelspelerpion, int id, int aantal, int spelid)
        {
            // SQL statement insert
            if (aantal < 4)
            {
                
                    int positienummer = 59;
                    string sql = "Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + "," + spelid + ", " + positienummer + ", 'Geel',0)";
                    
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

        public void UpdateSpelSpeler4(SpelSpelerPion spelspelerpion, int id, int aantal, int spelid)
        {
            // SQL statement insert
            if (aantal < 4)
            {
                
                    int positienummer = 60;
                    string sql = "Insert into Spelspelerpion (spelerid, spelid, positie, Kleur, IsBinnen) values (" + id + "," + spelid + ", " + positienummer + ", 'Rood',0)";
                    
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
}
