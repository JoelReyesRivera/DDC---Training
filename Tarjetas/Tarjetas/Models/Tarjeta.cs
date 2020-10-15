using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tarjetas.Models
{
    public class Tarjeta
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            [MaxLength(255)]
            [Index(IsUnique = true)]
            public String Nombre { get; set; }
            public bool EsActivo { get; set; }
            [MaxLength(50)]
            public String Usuario { get; set; }
            public DateTime Fecha { get; set; }
            public Institucion InstitucionObjecto{ get; set; }
            [Required]
            public int Institucion { get; set; }

    }
}
