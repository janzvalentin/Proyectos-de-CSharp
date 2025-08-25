using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public class DVD : MaterialBase
    {
        private int duracionMinutos;
        private string director;
        public int DuracionMinutos
        {
            get { return duracionMinutos; }
            set
            {
                if (value > 0)
                {
                    duracionMinutos = value;
                }
                else
                {
                    duracionMinutos = 1;
                }
            }
        }

        public string Director
        {
            get { return director; }
            // USANDO OPERADOR TERNARIO
            // set {director = !string.IsNullOrWhiteSpace(value) ? value.Trim() : "DESCONOCIDO";}
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    director = value.Trim();
                }
                else
                {
                    director = "DESCONOCIDO";
                }

            }
        }
        public DVD(string titulo, string autor, int añoPublicacion, int duracionminutos, string director)
            : base(titulo, autor, añoPublicacion)
        {
            this.DuracionMinutos = duracionminutos;
            this.Director = director;
        }
        public override double CalcularMulta(int diasRetraso)
        {
            if (!(diasRetraso > 0))
            {
                return 0.0;
            }
            double tarifaPorDia = 1.00;
            return tarifaPorDia * diasRetraso;
        }
        public override string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DVD | ");
            sb.Append("Titulo: ").Append(Titulo).Append(" | ");
            sb.Append("Director: ").Append(Director).Append(" | ");
            sb.Append("Año: ").Append(AñoPublicacion).Append(" | ");
            sb.Append("Duración: ").Append(DuracionMinutos).Append(" | ");
            sb.Append("Disponible: ").Append(Disponible ? "Si" : "No");
            return sb.ToString();
        }
    }
}
