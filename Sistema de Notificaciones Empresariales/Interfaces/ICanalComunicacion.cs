using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Interfaces
{

    public interface ICanalComunicacion
    {
        string NombreCanal { get; }
        bool EstadoActivo { get; set; }
        double CostoEnvio { get; }

        bool EnviarMensaje(string destinatario, string mensaje);
        bool ValidarDestinatario(string destinatario);
        string ObtenerEstadistica();
    }

}
