using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Interfaces
{
    public interface IProcesadorTexto
    {
        string ProcesarTexto(string textoOriginal);
        bool ValidarFormato(string texto);
        int ContarPalabras(string texto);
    }
}
