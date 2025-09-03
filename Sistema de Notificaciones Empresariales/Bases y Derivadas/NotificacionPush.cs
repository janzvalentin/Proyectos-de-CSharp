using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Bases_y_Derivadas
{
    public class NotificacionPush : NotificacionBase
    {
        public string DeviceToken { get; set; }
        public string Icono { get; set; }
        public NotificacionPush(string titulo, string contenido, string deviceToken, string icono)
            : base(titulo, contenido)
        {
            this.DeviceToken = !string.IsNullOrWhiteSpace(deviceToken) ? deviceToken.Trim() : "No hay DeviceToken";
            this.Icono = !string.IsNullOrWhiteSpace(icono) ? icono.Trim() : "no hay icono";
        }
        public override bool Enviar()
        {
            Enviada = true;
            return true;
        }
        public override string GenerarReporte()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[PUSH] {(!Enviada ? "PENDIENTE" : "ENVIADA")}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Device: {DeviceToken}");
            sb.AppendLine($"Icono: {Icono}");
            sb.AppendLine($"Fecha: {FechaCreacion: dd/MM/yyyy} HH:mm");
            return sb.ToString();
        }
    }
}
