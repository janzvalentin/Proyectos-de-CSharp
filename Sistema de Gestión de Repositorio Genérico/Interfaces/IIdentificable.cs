using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Repositorio_Genérico.Interfaces
{
    //la interfaz simple para que la entidades tengan Id y descripcion
    public interface IIdentificable
    {
        int Id { get; set; }
        string ObtenerDescripcion();
    }
}
