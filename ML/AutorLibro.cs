using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AutorLibro
    {
        public int IdAutorLibro { get; set; }
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
        public string AñoInicio { get; set; }
        public string AñoFin { get; set; }
        public List<object> AutoresLibros { get; set; }
        public object AutorLibro1 { get; set; }
    }
}
