using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Interfaces
{
    public interface INotificacion
    {
        string Titulo { get; set; }
        string Contenido { get; set; }
        DateTime FechaCreacion { get; }
        bool Enviada { get; }

        bool Enviar();
        string GenerarReporte();
        void MarcarComoLeida();
    }
}
