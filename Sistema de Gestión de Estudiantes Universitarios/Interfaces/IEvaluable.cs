using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Interfaces
{
    public interface IEvaluable
    {
        double CalcularPromedio();
        bool EstaAprobado();
        void AgregarCalificacion(double calificacion);
    }
}
