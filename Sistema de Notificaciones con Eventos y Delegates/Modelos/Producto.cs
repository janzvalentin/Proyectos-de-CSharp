using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos
{
    public class Producto : IIdentificable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return ($"{Nombre} (ID:{Id}) - {Precio:c} - Stock: {Stock} - Categoria: {Categoria}");
        }
    }
}
