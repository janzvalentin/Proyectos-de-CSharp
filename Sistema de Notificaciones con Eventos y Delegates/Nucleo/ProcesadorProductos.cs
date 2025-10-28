using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Nucleo
{
    public class ProcesadorProductos
    {
        private readonly AlmacenObservable<Producto> almacen;
        public ProcesadorProductos(AlmacenObservable<Producto> almacen)
        {
            this.almacen = almacen;
        }
        // Filtra los productos según un criterio (Func<Producto, bool>).
        public List<Producto> Filtrar(Func<Producto, bool> criterio)
        {
            var resultado = new List<Producto>();
            foreach (var p in almacen.ObtenerTodos())
            {
                if (criterio(p))
                    resultado.Add(p);
            }
            return resultado;
        }

        public void AplicarDescuento(Action<Producto> aplicador)
        {
            foreach (var p in almacen.ObtenerTodos())
            {
                aplicador(p);
            }
        }
        //Busca productos que cumplan una condición usando un Predicate<Producto>
        public List<Producto> BuscarProductos(Predicate<Producto> condicion)
        {
            var encontrados = new List<Producto>();
            foreach (var p in almacen.ObtenerTodos())
            {
                if (condicion(p))
                    encontrados.Add(p);
            }
            return encontrados;
        }
        public List<Producto> OrdenarPorPrecio(bool ascendente)
        {
            var lista = new List<Producto>(almacen.ObtenerTodos());

            // Expresión lambda para comparar precios
            lista.Sort((a, b) =>
            {
                int comparacion = a.Precio.CompareTo(b.Precio);
                return ascendente ? comparacion : -comparacion;
            });

            return lista;
        }

        public decimal CalcularTotal(Func<Producto, decimal> selector)
        {
            decimal total = 0;
            foreach (var p in almacen.ObtenerTodos())
            {
                total += selector(p);
            }
            return total;
        }
    }
}
