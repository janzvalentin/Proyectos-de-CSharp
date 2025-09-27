using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Excepciones
{
    public class EstudianteException : Exception
    {
        public string CodigoError { get; }
        public EstudianteException(string mensaje, string codigo = null) : base(mensaje)
        {
            CodigoError = codigo;
        }
        public EstudianteException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}
