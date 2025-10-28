using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Notificaciones_con_Eventos_y_Delegates.Delegados.Personalizados;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Nucleo
{
    public class GeneradorReportes
    {
        public string GenerarReporte<T>(List<T> items, FormateadorItem<T> formateador)
         where T : IIdentificable
        {
            var lineas = new List<string>();

            foreach (var item in items)
            {
                // Usamos el delegate recibido para formatear cada item
                string linea = formateador(item);
                lineas.Add(linea);
            }

            // Unimos todas las líneas en un solo texto
            return string.Join(Environment.NewLine, lineas);
        }
        public void GenerarReportesMultiples<T>(List<T> items, params FormateadorItem<T>[] formateadores)
            where T : IIdentificable
        {
            // Recorremos cada formateador (cada uno puede tener un formato diferente)
            for (int i = 0; i < formateadores.Length; i++)
            {
                Console.WriteLine($"\n--- Reporte {i + 1} ---");

                var formateador = formateadores[i];

                foreach (var item in items)
                {
                    // Aplicamos cada delegate sobre el mismo conjunto de items
                    Console.WriteLine(formateador(item));
                }
            }
        }
    }
}
