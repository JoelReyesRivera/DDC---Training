﻿using Oracle.ManagedDataAccess.Client;
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
                "User Id = TARJETA; Password=12345;Data Source = (DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl.neoris.cxnetworks.net)))")
                 ,true)
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(Database.Connection.ConnectionString);
            modelBuilder.HasDefaultSchema(sqlConnectionStringBuilder.UserID);
        }
    }


}