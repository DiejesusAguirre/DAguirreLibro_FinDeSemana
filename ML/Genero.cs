using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Genero
    {
        [DisplayName("Genero del Libro")]
        public int IdGenero { get; set; }
        [DisplayName("Genero del Libro")]
        public string NombreGenero { get; set; }
        public List<Object> Generos { get; set; }
    }
}
