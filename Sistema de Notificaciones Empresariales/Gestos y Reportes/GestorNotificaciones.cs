using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Gestos_y_Reportes
{
    public class GestorNotificaciones
    {
        private INotificacion[] notificaciones;
        private ICanalComunicacion[] canales;
        private int totalNotificaciones;
        private int totalCanales;

        public GestorNotificaciones(int capacidadMaxima)
        {
            if (capacidadMaxima < 1)
            {
                capacidadMaxima = 1;
            }
            notificaciones = new INotificacion[capacidadMaxima];
            canales = new ICanalComunicacion[capacidadMaxima];
            totalNotificaciones = 0;
            totalCanales = 0;
        }

        public bool AgregarNotificacion(INotificacion notificacion)
        {
            if (notificacion == null)
            {
                return false;
            }
            if (totalNotificaciones >= notificaciones.Length)
            {
                return false;
            }
            notificaciones[totalNotificaciones++] = notificacion;
            return true;
        }
        public bool RegistrarCanal(ICanalComunicacion canal)
        {
            if (canal == null)
            {
                return false;
            }
            if (totalCanales >= canales.Length)
            {
                return false;
            }
            canales[totalCanales++] = canal;
            return true;
        }

        public INotificacion[] ObtenerNotificaciones()
        {
            var copia = new INotificacion[totalNotificaciones];
            for (int i = 0; i < totalNotificaciones; i++)
            {
                copia[i] = notificaciones[i];
            }
            return copia;
        }
        public ICanalComunicacion[] ObtenerCanales()
        {
            var copia = new ICanalComunicacion[totalCanales];
            for (int i = 0; i < totalCanales; i++)
            {
                copia[i] = canales[i];
            }
            return copia;
        }
        public void ProcesarTodasLasNotificaciones()
        {
            foreach (INotificacion notif in notificaciones)
            {
                if (notif == null)
                {
                    continue;
                }
                if (notif != null && !notif.Enviada)
                {
                    notif.Enviar();
                    Console.WriteLine(notif.GenerarReporte());
                }
            }
        }
        public void ProcesarTexto()
        {
            foreach (INotificacion notif in notificaciones)
            {
                if (notif == null)
                {
                    continue;
                }
                if (notif is IProcesadorTexto procesador)
                {
                    string textoLimpio = procesador.ProcesarTexto(notif.Contenido);
                    int palabras = procesador.ContarPalabras(textoLimpio);
                    Console.WriteLine($"Texto procesado: {palabras} palabras");
                }
            }
        }
        public void EnviarPendientesPorCanal(string destinatario, string nombreCanalPreferido)
        {
            ICanalComunicacion canal = null;
            for (int i = 0; i < totalCanales; i++)
            {
                if (canales[i] != null && canales[i].NombreCanal.Equals(nombreCanalPreferido, StringComparison.OrdinalIgnoreCase))
                {
                    canal = canales[i];
                    break;
                }
            }
            if (canal == null || !canal.EstadoActivo)
            {
                Console.WriteLine("Canal no disponible/activo.");
                return;
            }
            for (int i = 0; i < totalNotificaciones; i++)
            {
                var notif = notificaciones[i];
                if (notif != null && !notif.Enviada)
                {
                    if (canal.ValidarDestinatario(destinatario) && canal.EnviarMensaje(destinatario, notif.Contenido))
                    {
                        notif.Enviar();
                        Console.WriteLine($"[Canal {canal.NombreCanal}] Enviada notificacion: {notif.Titulo}");
                    }
                }
            }
        }
        public double CalcularCostoEstimado(double multiplicador = 1.0)
        {
            int pendientes = 0;
            for (int i = 0; i < totalNotificaciones; i++)
            {
                if (notificaciones[i] != null && !notificaciones[i].Enviada)
                {
                    pendientes++;
                }
            }
            if (pendientes == 0)
            {
                return 0;
            }
            double sumaCostos = 0;
            int activos = 0;
            for (int i = 0; i < totalCanales; i++)
            {
                if (canales[i] != null && canales[i].EstadoActivo)
                {
                    sumaCostos += canales[i].CostoEnvio;
                    activos++;
                }
            }
            double costoPromedio = activos > 0 ? sumaCostos / activos : 0;
            return pendientes * costoPromedio * (multiplicador <= 0 ? 1.0 : multiplicador);
        }
    }
}
