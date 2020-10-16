using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Tarjetas.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Institucion> Institucion { set; get; }
        public DbSet<Tarjeta> tarjeta { set; get; }

        public AppDbContext()
            :base (new OracleConnection (
               System.Configuration.ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString)
                 ,true)
        {
            //var conection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
            Database.SetInitializer<AppDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(Database.Connection.ConnectionString);
            modelBuilder.HasDefaultSchema(sqlConnectionStringBuilder.UserID);
        }
    }


}