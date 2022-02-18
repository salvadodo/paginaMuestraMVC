using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiRestMiCasa.Models
{
    public class Dueños
    {
        public int idDueño { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Casas> Casas { get; set; }
    }
}