using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Interfaces
{
    public interface IPersona
    {
        string Nombre { get; set; }
        string Identificacion { get; set; }
        DateTime FechaNacimiento { get; set; }

        int CalcularEdad();
        string ObtenerInformacionCompleta();
    }
}
