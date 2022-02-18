using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiRestMiCasa.Models
{
    public class Casas
    {
        public int idCasa { get; set; }
        public string tipodeCasa { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Dueño { get; set; }
        public virtual Dueños Dueños { get; set; }

    }
}