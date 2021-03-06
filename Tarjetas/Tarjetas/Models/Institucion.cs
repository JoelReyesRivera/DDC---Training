﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tarjetas.Models
{
    [Table("INSTITUCION")]

    public class Institucion
    {
        public Institucion(string nombre, string identificador, string usuario)
        {
            Nombre = nombre;
            Identificador = identificador;
            Usuario = usuario;
            EsActivo = "0";
            Fecha = DateTime.Now;
        }

        public Institucion()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(255)]
        [Index(IsUnique =true)]
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [MaxLength(255)]
        [Index(IsUnique = true)]
        [Column("IDENTIFICADOR")]
        public String Identificador { get; set; }
        [Column("ES_ACTIVO")]
        public String EsActivo { get; set; }
        [MaxLength(50)]
        [Column("USUARIO")]
        public String Usuario { get; set; } 
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [NotMapped]
        public List<Tarjeta> tarjetas { get; set; }
    }
}