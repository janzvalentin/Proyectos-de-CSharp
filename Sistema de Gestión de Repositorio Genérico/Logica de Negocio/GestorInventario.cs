using Sistema_de_Gestión_de_Repositorio_Genérico.Entidades;
using Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Logica_de_Negocio
{
    public class GestorInventario
    {


        //Las dependencias ahora son privadas y se asignan en el constructor
        private IRepositorio<Producto> _repositorioProductos;
        private IRepositorio<Cliente> _repositorioClientes;

        //Constructor que utiliza inyección de dependencias
        public GestorInventario(IRepositorio<Producto> repositorioProductos, IRepositorio<Cliente> repositorioClientes)
        {
            _repositorioProductos = repositorioProductos;
            _repositorioClientes = repositorioClientes;
        }
        //Metodos de Productos
        public void AgregarProducto(Producto producto) => _repositorioProductos.Agregar(producto);
        public Producto BuscarProductoPorId(int id) => _repositorioProductos.Obtener(id);
        public List<Producto> ListarTodosLosProductos() => _repositorioProductos.ObtenerTodos();

        public IEnumerable<Producto> ObtenerProductosStockBajo(int cantidad = 10)
        {
            foreach (var producto in _repositorioProductos.ObtenerTodos())
            {
                if (producto.Stock < cantidad)
                {
                    yield return producto;
                }
            }
        }
        public double CalcularValorTotalInventario()
        {
            double total = 0;
            foreach (var p in _repositorioProductos.ObtenerTodos())
            {
                total += p.Precio * p.Stock;
            }
            return total;
        }

        //Métodos de Clientes
        public void AgregarCliente(Cliente cliente) => _repositorioClientes.Agregar(cliente);
        public List<Cliente> ObtenerClientesPorRango(DateTime inicio, DateTime fin)
        {
            var resultados = new List<Cliente>();
            foreach (var cliente in _repositorioClientes.ObtenerTodos())
            {
                if (cliente.FechaRegistro >= inicio && cliente.FechaRegistro <= fin)
                {
                    resultados.Add(cliente);
                }
            }
            return resultados;
        }
    }
}

