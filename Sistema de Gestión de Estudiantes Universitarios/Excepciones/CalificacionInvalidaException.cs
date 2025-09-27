using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Excepciones
{
    public class CalificacionInvalidaException : EstudianteException
    {
        public double CalificacionInvalida { get; }
        public CalificacionInvalidaException(double calificacion)
            : base($"La calificación {calificacion} o es válida. Debe estar entre 0 y 20", "CAL001")
        {
            CalificacionInvalida = calificacion;
        }

    }

}


