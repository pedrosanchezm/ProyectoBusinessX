using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessX.Entities
{
    public class Libro
    {
        //Tercer comentario
        public int IDL { get; set; }
        public string NombreL { get; set; }
        public string AutorL { get; set; }
        public string Editorial { get; set; }
        public string ISBN { get; set; }
        public double PrecioL { get; set; }
        public string RutaImgL { get; set; }
        public int IDGeneroL { get; set; }
    }
}
