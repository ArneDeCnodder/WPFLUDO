﻿using System;
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
    class BoardDataService
    {
            // Ophalen ConnectionString uit App.config
            private static string connectionString =
            ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

            // Stap 1 Dapper
            // Aanmaken van een object uit de IDbConnection class en 
            // instantiëren van een SqlConnection.
            // Dit betekent dat de connectie met de database automatisch geopend wordt.
            private static IDbConnection db = new SqlConnection(connectionString);

            public SpelSpelerPion GetSpecificspeler(string kleur, int spelid)
            {
                // Stap 2 Dapper
                // Uitschrijven SQL statement & bewaren in een string. 
                string sql = "Select * from Spelspelerpion where spelid like "+spelid+" and kleur like '%"+kleur+"%'";

                // Stap 3 Dapper
                // Uitvoeren SQL statement op db instance 
                
                return db.QuerySingle<SpelSpelerPion>(sql);
            }
            public void UpdateSpel(Spel spel)
            {
                // SQL statement update 
                string sql = "Update Spel set Naam = @naam, Datum = @datum where id = @id";

                // Uitvoeren SQL statement en doorgeven parametercollectie
                db.Execute(sql, new
                {
                    spel.Naam,
                    spel.Datum,
                    spel.ID
                });
            }
            public void AddSpel(Spel spel)
            {
                // SQL statement insert
                string sql = "Insert into Spel (naam, datum) values (@naam, @datum)";

                // Uitvoeren SQL statement en doorgeven parametercollectie
                db.Execute(sql, new
                {
                    spel.Naam,
                    spel.Datum
                });
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
