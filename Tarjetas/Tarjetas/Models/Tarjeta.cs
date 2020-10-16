using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tarjetas.Models
{
    [Table("TARJETA")]

    public class Tarjeta
        {

        public Tarjeta(string numero, int institucion, string usuario)
        {
            Numero = numero;
            this.Institucion = institucion;
            Usuario = usuario;
            EsActivo = "0";
            Fecha = DateTime.Now;
        }

        public Tarjeta()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            [MaxLength(255)]
            [Index(IsUnique = true)]
            [Column("NUMERO")]
            public String Numero { get; set; }
            [Column("ES_ACTIVO")]
            public string EsActivo { get; set; }
            [MaxLength(50)]
            [Column("USUARIO")]
            public String Usuario { get; set; }
            [Column("FECHA")]
            public DateTime Fecha { get; set; }
            [Required]
            [Column("INSTITUCION")]
            public int Institucion { get; set; }
            [NotMapped]
            public Institucion institucionObject  { get; set; }
    }
}
