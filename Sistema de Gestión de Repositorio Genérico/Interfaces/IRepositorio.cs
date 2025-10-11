using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces
{
    public interface IRepositorio<T> where T : IIdentificable
    {
        // Interfaz de repositorio genérico
        void Agregar(T item);
        T Obtener(int id);
        List<T> ObtenerTodos();
        bool Actualizar(T item);
        bool Eliminar(int id);
        int ContarElementos();
    }
}
