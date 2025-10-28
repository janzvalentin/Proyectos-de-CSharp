using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Delegados
{
    public class Personalizados
    {
        //Delegado para notificar cambios(agregado, eliminado...)
        public delegate void NotificadorCambio<T>(T item, string accion);
        //Delegate para validar un elemento antes de agregarlo o procesarlo
        public delegate bool ValidadorItem<T>(T item);
        //Delegate para formatear un elemento al generar reportes o mostrar datos
        public delegate string FormateadorItem<T>(T item);
    }
}
