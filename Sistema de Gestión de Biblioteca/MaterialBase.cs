using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public abstract class MaterialBase
    {
        protected string titulo;
        protected string autor;
        protected int añoPublicacion;
        protected bool disponible;

        //Constructor Base
        public MaterialBase(string titulo, string autor, int añoPublicacion)
        {
            //Validaciones de string y logica
            this.titulo = !string.IsNullOrWhiteSpace(titulo) ? titulo.Trim() : "Sin titulo";
            this.autor = !string.IsNullOrWhiteSpace(autor) ? autor.Trim() : "Sin autor";
            this.añoPublicacion = añoPublicacion;

            //Un material nuevo esta disponible
            this.disponible = true;
        }
        //propiedades publicas con get/set
        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    titulo = value.Trim();
                }
                else
                {
                    titulo = "Sin titulo";
                }
            }
        }
        public string Autor
        {
            get { return autor; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    autor = value.Trim();
                }
                else
                {
                    autor = "Sin autor";
                }
            }
        }
        public int AñoPublicacion
        {
            get { return añoPublicacion; }
            set
            {
                if (value > 0)
                {
                    añoPublicacion = value;
                }
                else
                {
                    añoPublicacion = DateTime.Now.Year;
                }
            }
        }

        public bool Disponible
        {
            get { return disponible; }
            protected set
            {
                disponible = value;
            }
        }
        private int vecesPrestado;
        public int VecesPrestado
        {
            get { return vecesPrestado; } // lectura
            private set { vecesPrestado = value; }//escritura solo dentro de la clase
        }
        //Metodos virtuales para luego sobrescribirlas en las hijas
        public virtual void Prestar()
        {
            if (!Disponible)
            {

                Console.WriteLine("No se puede prestar: ya está prestado.");
                return;
            }

            Disponible = false;
            VecesPrestado++;
            Console.WriteLine("Material prestado correctamente.");

        }

        public virtual void Devolver()
        {
            if (Disponible)
            {
                Console.WriteLine("No se puede devolver: ya esta disponible.");
                return;
            }
            else
            {
                disponible = false;
                Console.WriteLine("Material devuelto correctamente.");
            }
        }
        // Metodos que cada derivada debe implementar
        public abstract double CalcularMulta(int diasRetraso);

        public abstract string ObtenerInformacion();
    }
}
