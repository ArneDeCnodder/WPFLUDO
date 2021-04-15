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
            // SQL statement delete 
            string sql = "Delete Spel where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { spel.ID });
        }
    }
}
