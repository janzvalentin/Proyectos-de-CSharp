using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Notificaciones_con_Eventos_y_Delegates.Delegados.Personalizados;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Nucleo
{
    public class AlmacenObservable<T> where T : IIdentificable
    {
        //Eventos  y delegados
        public event NotificadorCambio<T> ItemAgregado;
        public event NotificadorCambio<T> ItemEliminado;
        public event EventHandler<AlertaEventArgs> AlertaStockBajo;
        private readonly List<T> items = new List<T>();
        private readonly object _lock = new object();
        public List<T> ObtenerTodos()
        {
            lock (_lock)
            {
                return new List<T>(items);
            }
        }
        //Agrega un item si el validador devuelve true y lanza InvalidOperationException si validador lanza o devuelve false
        public void Agregar(T item, ValidadorItem<T> validador)
        {
            if (validador == null) throw new ArgumentNullException(nameof(validador));

            bool valido;
            try
            {
                valido = validador(item);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error durante la validación del item.", ex);
            }

            if (!valido) throw new InvalidOperationException("El item no pasó la validación.");

            lock (_lock)
            {
                items.Add(item);
            }

            // Invoca los handlers de ItemAgregado de forma segura (cada handler por separado)
            InvokeNotificador(ItemAgregado, item, "Agregado");
        }
        // Elimina un item por id y devuelve true si lo encontró y elimino.
        public bool Eliminar(int id)
        {
            T encontrado = default;
            lock (_lock)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Id == id)
                    {
                        encontrado = items[i];
                        items.RemoveAt(i);
                        break;
                    }
                }
            }

            if (encontrado != null)
            {
                InvokeNotificador(ItemEliminado, encontrado, "Eliminado");
                return true;
            }
            return false;
        }
        public void TriggerAlertIf(Func<T, bool> predicate, AlertaEventArgs args)
        {
            if (predicate == null || args == null) return;

            List<T> coincidencias = new List<T>();
            lock (_lock)
            {
                foreach (var it in items)
                {
                    try
                    {
                        if (predicate(it)) coincidencias.Add(it);
                    }
                    catch
                    {

                    }
                }
            }

            foreach (var m in coincidencias)
            {
                InvokeEventHandlers(AlertaStockBajo, m, args);
            }
        }

        // ---------- Helpers para invocar handlers con manejo de excepciones ----------

        // Invoca cada handler de NotificadorCambio<T> por separado para evitar que uno falle y detenga los demás
        private void InvokeNotificador(NotificadorCambio<T> del, T item, string accion)
        {
            if (del == null) return;

            foreach (Delegate d in del.GetInvocationList())
            {
                try
                {
                    ((NotificadorCambio<T>)d)(item, accion);
                }
                catch (Exception ex)
                {
                    // Registramos en consola el fallo del handler pero continuamos con los demás.
                    Console.WriteLine($"[Error] Handler de NotificadorCambio falló: {ex.Message}");
                }
            }
        }

        //Invoca cada handler de EventHandler<AlertaEventArgs> por separado
        private void InvokeEventHandlers(EventHandler<AlertaEventArgs> del, T senderObj, AlertaEventArgs args)
        {
            if (del == null) return;

            foreach (Delegate d in del.GetInvocationList())
            {
                try
                {
                    ((EventHandler<AlertaEventArgs>)d)(senderObj, args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Handler de evento falló: {ex.Message}");
                }
            }
        }
        public void DispararAlertaStockBajo(T item, string mensaje, int nivel)
        {
            var args = new AlertaEventArgs
            {
                Mensaje = mensaje,
                FechaAlerta = DateTime.Now,
                NivelSeveridad = nivel
            };

        
            AlertaStockBajo?.Invoke(item, args);
        }
    }
}
