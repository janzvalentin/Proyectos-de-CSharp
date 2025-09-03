using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Bases_y_Derivadas
{
    public class NotificacionEmail : NotificacionBase, IProcesadorTexto
    {
        public string DireccionEmail { get; set; }
        public string Asunto { get; set; }
        public bool EsHTML { get; set; }
        public NotificacionEmail(string titulo, string contenido, string email, string asunto = "", bool esHTML = true)
            : base(titulo, contenido)
        {
            this.DireccionEmail = !string.IsNullOrWhiteSpace(email) ? email : "Sin Email";
            this.Asunto = !string.IsNullOrWhiteSpace(asunto) ? asunto : titulo;
            this.EsHTML = esHTML;
        }
        public override bool Enviar()
        {
            Enviada = true;
            return true;
        }

        public override string GenerarReporte()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Email] {(!Enviada ? "PENDIENTE" : "ENVIADA")}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Asunto: {Asunto}");
            sb.AppendLine($"Destinatario: {DireccionEmail}");
            sb.AppendLine($"Fecha: {FechaCreacion: dd/MM/yyyy}");
            return sb.ToString();
        }



        public string ProcesarTexto(string textoOriginal)
        {
            if (textoOriginal == null)
            {
                return "";
            }
            string limpio = Regex.Replace(textoOriginal.Trim(), @"\s+", " ");
            return !EsHTML ? limpio.ToUpper() : limpio;
        }

        public bool ValidarFormato(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }
            return texto.Trim().Length >= 5;
        }

        public int ContarPalabras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return 0;
            }
            String limpio = Regex.Replace(texto.Trim(), @"\s+", " ");
            return limpio.Split(' ').Length;
        }
    }
}
