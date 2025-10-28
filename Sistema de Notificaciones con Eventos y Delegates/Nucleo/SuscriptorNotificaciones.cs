using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Nucleo
{
    public class SuscriptorNotificaciones
    {
        private readonly string nombre;
        private readonly List<string> historialNotificaciones = new();

        public SuscriptorNotificaciones(string nombre)
        {
            this.nombre = nombre;
        }
        // e ejecuta cuando se agrega un producto
        public void OnItemAgregado(Producto producto, string accion)
        {
            var mensaje = $"[{nombre}] Notificación: {accion} - {producto.Nombre} (ID:{producto.Id})";
            Console.WriteLine(mensaje);
            historialNotificaciones.Add($"{mensaje} - {DateTime.Now:HH:mm:ss}");
        }
        // Se ejecuta cuando se elimina un producto
        public void OnItemEliminado(Producto producto, string accion)
        {
            var mensaje = $"[{nombre}] Notificación: {accion} - {producto.Nombre} (ID:{producto.Id})";
            Console.WriteLine(mensaje);
            historialNotificaciones.Add($"{mensaje} - {DateTime.Now:HH:mm:ss}");
        }
        // Se ejecuta cuando se lanza un evento de alerta (por ejemplo, stock bajo)
        public void OnAlertaStockBajo(object sender, AlertaEventArgs e)
        {
            var producto = sender as Producto;
            var mensaje = $"[{nombre}] ALERTA: {e.Mensaje} - Producto: {producto?.Nombre} (Stock: {producto?.Stock})";
            Console.WriteLine(mensaje);
            historialNotificaciones.Add($"{mensaje} - {e.FechaAlerta:yyyy-MM-dd HH:mm:ss}");
        }
        // Muestra todo el historial de notificaciones del suscriptor
        public void MostrarHistorial()
        {
            Console.WriteLine($"\n=== Historial de {nombre} ===");
            if (historialNotificaciones.Count == 0)
            {
                Console.WriteLine("(Sin notificaciones)");
                return;
            }

            int i = 1;
            foreach (var noti in historialNotificaciones)
            {
                Console.WriteLine($"{i++}. {noti}");
            }
        }
    }
}
