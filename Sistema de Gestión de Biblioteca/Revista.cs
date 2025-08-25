using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public class Revista : MaterialBase
    {
        private int numeroEdicion;
        private string periodicidad;


        public int NumeroEdicion
        {
            get { return numeroEdicion; }
            set
            {
                if (value > 0)
                {
                    numeroEdicion = value;
                }
                else
                {
                    numeroEdicion = 1;
                }
            }
        }
        public string Periodicidad
        {
            get { return periodicidad; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    periodicidad = value.Trim();
                }
                else
                {
                    periodicidad = "Desconocida";
                }
            }
        }

        public Revista(string titulo, string autor, int añoPublicacion, int numeroEdicion, string periodicidad)
            : base(titulo, autor, añoPublicacion)
        {
            this.NumeroEdicion = numeroEdicion;
            this.Periodicidad = periodicidad;
        }

        public override double CalcularMulta(int diasRetraso)
        {
            if (!(diasRetraso > 0))
            {
                return 0.0;
            }
            double tarifaPorDia = 0.25;
            return tarifaPorDia * diasRetraso;
        }

        public override string ObtenerInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("REVISTA | ");
            sb.Append("Titulo: ").Append(Titulo).Append(" | ");
            sb.Append("Autor: ").Append(Autor).Append(" | ");
            sb.Append("Año: ").Append(AñoPublicacion).Append(" | ");
            sb.Append("Edicion: ").Append(NumeroEdicion).Append(" | ");
            sb.Append("Periodicidad: ").Append(Periodicidad).Append(" | ");
            sb.Append("Disponible: ").Append(Disponible ? "Si" : "No");
            return sb.ToString();

        }
    }
}
