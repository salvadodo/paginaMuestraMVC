using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webApiRestMiCasa2.Models
{
    public class CasasDueñosJoins
    {
        public int idCasa { get; set; }

        [Required]
        [StringLength(15)]
        public string tipodeCasa { get; set; }

        [Required]
        [StringLength(50)]
        public string Ubicacion { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int? Dueño { get; set; }
        public int idDueño { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

    }
}