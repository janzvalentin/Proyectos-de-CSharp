using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public  class Libro : MaterialBase
    {
        private int numeroPaginas;
        private string isbn;
        public string ISBN
        {
            get { return isbn; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    isbn = value.Trim().ToUpper();
                }
                else
                {
                    isbn = "Sin ISBN";
                }

            }
        }
        public int NumeroPaginas
        {
            get { return numeroPaginas; }
            set
            {
                if (value > 0)
                {
                    numeroPaginas = value;
                }
                else
                {
                    numeroPaginas = 1;
                }
            }

        }
        public Libro(string titulo, string autor, int añoPublicacion, int numeroPaginas, string isbn)
            : base(titulo, autor, añoPublicacion)
        {
            this.numeroPaginas = numeroPaginas;
            this.isbn = !string.IsNullOrWhiteSpace(isbn) ? isbn.Trim() : "Sin ISBN";
        }
        public override double CalcularMulta(int diasRetraso)
        {

            if (!(diasRetraso > 0))
            {
                return 0.0;
            }
            double tarifaPorDia = 0.50;
            return tarifaPorDia * diasRetraso;
        }
        public override string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LIBRO | ");
            sb.Append("Titulo: ").Append(Titulo).Append(" | ");
            sb.Append("Autor: ").Append(Autor).Append(" | ");
            sb.Append("Año: ").Append(AñoPublicacion).Append(" | ");
            sb.Append("Páginas: ").Append(NumeroPaginas).Append(" | ");
            sb.Append("ISBN: ").Append(ISBN).Append(" | ");
            sb.Append("Disponible: ").Append(Disponible ? "Si" : "No");
            return sb.ToString();
        }
    }
}
