using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Gestos_y_Reportes
{
    public class GeneradorReportes
    {
        public string GenerarReporteCompleto(GestorNotificaciones gestor)
        {
            StringBuilder reporte = new StringBuilder();
            reporte.AppendLine($"=== REPORTE DE NOTIFICACIONES ===");
            reporte.AppendLine($"Fecha: {DateTime.Now: dd/MM/yyyy HH:mm}");
            reporte.AppendLine();

            var todas = gestor.ObtenerNotificaciones();
            foreach (var notif in todas)
            {
                if (notif == null)
                {
                    continue;
                }
                reporte.AppendLine(notif.GenerarReporte());

                if (notif is IProcesadorTexto procesador)
                {
                    string procesado = procesador.ProcesarTexto(notif.Contenido);
                    int cantidadPalabras = procesador.ContarPalabras(procesado);
                    reporte.AppendLine($"Palabras (contenido procesado): {cantidadPalabras}");
                }
                reporte.AppendLine();
            }
            reporte.AppendLine("--- ESTADO DE CANALES ---");
            var canales = gestor.ObtenerCanales();
            foreach (var canal in canales)
            {
                if (canal == null)
                {
                    continue;
                }
                reporte.AppendLine($"{canal.NombreCanal} | Activo: {canal.EstadoActivo} | Costo: {canal.CostoEnvio:0.00:C}");

                string estadistica = canal.ObtenerEstadistica();
                reporte.AppendLine($"Estadistica: {estadistica}");

                reporte.AppendLine();
            }
            return reporte.ToString();
        }
    }
}
