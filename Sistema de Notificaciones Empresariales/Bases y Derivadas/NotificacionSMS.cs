using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Bases_y_Derivadas
{
    public class NotificacionSMS : NotificacionBase, IProcesadorTexto
    {
        public string NumeroTelefono { get; set; }
        public int LimiteCaracteres { get; } = 160;

        public NotificacionSMS(string titulo, string contenido, string numeroTelefono)
            : base(titulo, contenido)
        {
            this.NumeroTelefono = !String.IsNullOrWhiteSpace(numeroTelefono) ? numeroTelefono.Trim() : "Sin numero";
        }
        public override bool Enviar()
        {
            var cuerpo = !string.IsNullOrWhiteSpace(contenido) ? contenido.Trim() : "Sin contenido";
            if (cuerpo.Length > LimiteCaracteres)
            {
                contenido = cuerpo.Substring(0, LimiteCaracteres);
            }
            Enviada = true;
            return true;
        }

        public override string GenerarReporte()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[SMS]{(!Enviada ? "PENDIENTE" : "ENVIADA")}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Destinatario: {NumeroTelefono}");
            sb.AppendLine($"Límite: {LimiteCaracteres} chars | Actual: {(!string.IsNullOrWhiteSpace(Contenido) ? Contenido.Length : 0)} chars");
            sb.AppendLine($"Fecha: {FechaCreacion: dd/MM/yyyy}");
            return sb.ToString();

        }

        public int ContarPalabras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return 0;
            }
            string limpio = Regex.Replace(texto.Trim(), @"\s+", " ");
            return limpio.Split(' ').Length;
        }

        public string ProcesarTexto(string textoOriginal)
        {
            if (textoOriginal == null)
            {
                return "";
            }
            string limpio = Regex.Replace(textoOriginal.Trim(), @"\s+", " ");
            return limpio;
        }

        public bool ValidarFormato(string texto)
        {
            if (texto == null)
            {
                return false;
            }
            return texto.Length <= LimiteCaracteres;
        }
    }
}
