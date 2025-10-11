using Sistema_de_Gestión_de_Repositorio_Genérico.Excepciones;
using Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T: IIdentificable
    {
        private Dictionary<int, T> _elementos = new Dictionary<int, T>();

        public void Agregar(T item)
        {
            // Validación: El ID debe ser mayor que 0.
            if (item.Id <= 0)
            {
                throw new RepositorioException("El ID del elemento debe ser mayor que 0.");
            }
            // Validación: No se permiten IDs duplicados.
            if (_elementos.ContainsKey(item.Id))
            {
                throw new RepositorioException($"Error: Ya existe un elemento con el ID {item.Id}.");
            }
            _elementos.Add(item.Id, item);
        }

        public T Obtener(int id)
        {
            // Intentamos obtener el valor. Si no existe, lanzamos nuestra excepción personalizada.
            if (_elementos.TryGetValue(id, out T item))
            {
                return item;
            }
            throw new RepositorioException($"Error: No se encontró ningún elemento con el ID {id}.");
        }

        public List<T> ObtenerTodos()
        {
            // Creamos una nueva lista a partir de los valores del diccionario.
            return new List<T>(_elementos.Values);
        }

        public bool Actualizar(T item)
        {
            // Para actualizar, primero verificamos que el elemento exista.
            if (_elementos.ContainsKey(item.Id))
            {
                _elementos[item.Id] = item; // Reemplazamos el valor existente.
                return true; // Indicamos que la operación fue exitosa.
            }
            return false; // Indicamos que no se encontró el elemento a actualizar.
        }

        public bool Eliminar(int id)
        {
            // El método Remove de Dictionary devuelve 'true' si el elemento existía y se eliminó.
            return _elementos.Remove(id);
        }

        public int ContarElementos()
        {
            // La propiedad Count del diccionario nos da el número de elementos.
            return _elementos.Count;
        }

        public List<T> Buscar<TValue>(Func<T, TValue> selector, TValue valor)
        {
            var resultados = new List<T>();
            foreach (var elemento in _elementos.Values)
            {
                if (selector(elemento).Equals(valor))
                {
                    resultados.Add(elemento);
                }
            }
            return resultados;
        }
    }
}
