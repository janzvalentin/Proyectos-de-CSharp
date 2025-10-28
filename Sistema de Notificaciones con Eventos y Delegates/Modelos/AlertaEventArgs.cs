using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos
{
    public class AlertaEventArgs : EventArgs
    {
        public string Mensaje { get; set; }
        public DateTime FechaAlerta { get; set; }
        public int NivelSeveridad { get; set; }
    }
}
