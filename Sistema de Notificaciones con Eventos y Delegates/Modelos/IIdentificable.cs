using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos
{
    public interface IIdentificable
    {
        int Id { get; set; }
        string Nombre { get; set; }
    }
}
