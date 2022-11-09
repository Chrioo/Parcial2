using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculador.Datos
{
    internal class ClsEstudiante
    {
        public int id { get; set; }
        public string Nombre{ get; set; }

        public string Apellido { get; set; }

        public string Carrera { get; set; }

        public string Asignatura { get; set; }

        public decimal Promedio1 { get; set; }

        public decimal Promedio2 { get; set; }

        public decimal Promedio3 { get; set; }

        public decimal PromedioFinal { get; set; }

    }
}
