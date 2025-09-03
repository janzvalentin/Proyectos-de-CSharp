using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Notificaciones_Empresariales.Bases_y_Derivadas
{
    public abstract class NotificacionBase : INotificacion
    {
        protected string titulo;
        protected string contenido;

        public string Titulo
        {
            get => titulo;
            set => titulo = !string.IsNullOrWhiteSpace(value) ? value.Trim() : "Sin titulo";
        }
        public string Contenido
        {
            get => contenido;
            set => contenido = !string.IsNullOrWhiteSpace(value) ? value.Trim() : "Sin contenido";
        }
        public DateTime FechaCreacion { get; protected set; }
        public bool Enviada { get; protected set; }
        protected NotificacionBase(string titulo, string contenido)
        {
            this.titulo = !string.IsNullOrWhiteSpace(titulo) ? titulo.Trim() : "Sin titulo";
            this.contenido = !string.IsNullOrWhiteSpace(contenido) ? contenido.Trim() : "Sin contenido";
            this.FechaCreacion = DateTime.Now;
            this.Enviada = false;
        }

        public virtual bool Enviar()
        {
            Enviada = true;
            return true;
        }

        public abstract string GenerarReporte();
        public virtual void MarcarComoLeida()
        {

        }
    }
}
