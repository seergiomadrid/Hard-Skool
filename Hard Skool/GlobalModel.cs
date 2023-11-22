using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_Skool
{
    public class GlobalModel
    {
        public enum TipoCentro
        {
            Público,
            Concertado,
            Privado,
            Otros
        }

        // Modelo para Provincia
        public class Provincia
        {
            public int Codigo { get; set; }
            public string Nombre { get; set; }
        }

        // Modelo para Localidad
        public class Localidad
        {
            public int Codigo { get; set; }
            public string Nombre { get; set; }
            public int EnProvincia { get; set; }
        }

        // Modelo para Centro_Educativo
        public class CentroEducativo
        {
            public int IdLocal { get; set; }
            public string Origen { get; set; }
            public string Nombre { get; set; }
            public TipoCentro Tipo { get; set; }
            public string Direccion { get; set; }
            public int CodigoPostal { get; set; }
            public float Longitud { get; set; }
            public float Latitud { get; set; }
            public int Telefono { get; set; }
            public string Descripcion { get; set; }
            public int EnLocalidad { get; set; }
        }
    }
}
