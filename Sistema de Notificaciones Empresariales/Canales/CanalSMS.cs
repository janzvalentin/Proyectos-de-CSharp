using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Canales
{
    public class CanalSMS : ICanalComunicacion
    {
        public string NombreCanal => "SMS";

        public bool EstadoActivo { get; set; }

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

        public string ObtenerEstadistica()
        {
            return "Canal SMS: latencia ~2s, tasa de entrega ~95% (simulada)";
        }

        public bool ValidarDestinatario(string destinatario)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
            {
                return false;
            }
            return Regex.IsMatch(destinatario, @"^\+?\d{9,15}$");
        }
    }
}
