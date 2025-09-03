using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Canales
{

    public class CanalEmail : ICanalComunicacion
    {
        public string NombreCanal => "Email";
        public bool EstadoActivo { get; set; } = true;
        public double CostoEnvio => 0.01;

        public bool EnviarMensaje(string destinatario, string mensaje)
        {
            if (!EstadoActivo)
            {
                return false;
            }
            if (!ValidarDestinatario(destinatario))
            {
                return false;
            }
            return true;
        }
        public bool ValidarDestinatario(string destinatario)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
            {
                return false;
            }
            return Regex.IsMatch(destinatario, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        string ICanalComunicacion.ObtenerEstadistica()
        {
            return "Canal Email: latencia ~100ms, tasa de entrega ~98% (simulada)";
        }
        public string ObtenerEstadisticaDetallada()
        {
            return "Email detallado: 0.01/envio, formato HTML/texto, adjuntos no soportados aquí (demo).";
        }


    }

}
