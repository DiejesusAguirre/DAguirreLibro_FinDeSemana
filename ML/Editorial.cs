using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Editorial
    {
        [DisplayName("Nombre de la Editorial")]
        public int IdEditorial { get; set; }
        [DisplayName("Nombre de la Editorial")]
        public string NombreEditorial { get; set; }
        public List<Object> Editoriales { get; set; }
    }
}
