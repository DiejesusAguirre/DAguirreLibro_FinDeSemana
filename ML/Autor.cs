using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        [DisplayName("Nombre del Autor")]
        public int IdAutor { get; set; }
        [DisplayName("Nombre del Autor")]
        public string NombreAutor { get; set; }
        public List<Object> Autores { get; set; }
    }
}
