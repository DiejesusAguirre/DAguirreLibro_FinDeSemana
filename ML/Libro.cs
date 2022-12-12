using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Numero de Paginas")]
        public int NumeroPaginas { get; set; }
        [DisplayName("Fecha de la Publicacion")]
        public string FechaDePublicacion { get; set; }
        [DisplayName("Edicion del Libro")]
        public string Edicion { get; set; }
        public ML.Autor Autor { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Genero Genero { get; set; }
        public List<object> Libros { get; set; }
    }
}
