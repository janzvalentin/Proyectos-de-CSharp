using Sistema_de_Gestión_de_Estudiantes_Universitarios.Excepciones;
using Sistema_de_Gestión_de_Estudiantes_Universitarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Modelos
{
    public class Estudiante : PersonaBase, IEvaluable, IComparable<Estudiante>
    {
        private List<double> calificaciones;
        private Dictionary<string, double> calificacionesPorMateria;
        private HashSet<string> materiasInscritas;

        public string CodigoEstudiante { get; }
        public string Carrera { get; set; }
        public int Semestre { get; set; }
        public Estudiante(string nombre, string identificacion, DateTime fechaNacimiento, string codigoEstudiante, string carrera)
            : base(nombre, identificacion, fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(codigoEstudiante))
                throw new EstudianteException("El código de estudiante es requerido", "EST001");
            CodigoEstudiante = codigoEstudiante;
            Carrera = carrera ?? throw new ArgumentNullException(nameof(carrera));

            //Inicializar colecciones
            calificaciones = new List<double>();
            calificacionesPorMateria = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
            materiasInscritas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }


        public void AgregarCalificacion(double calificación)
        {
            if (calificación < 0 || calificación > 20)
                throw new CalificacionInvalidaException(calificación);
            calificaciones.Add(calificación);
        }
        public void AgregarCalificacionMateria(string materia, double calificacion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(materia))
                    throw new ArgumentException("La materia no puede estar vacía", nameof(materia));

                AgregarCalificacion(calificacion);

                if (calificacionesPorMateria.ContainsKey(materia))
                    calificacionesPorMateria[materia] = calificacion;
                else
                    calificacionesPorMateria.Add(materia, calificacion);

                materiasInscritas.Add(materia);
            }
            catch (CalificacionInvalidaException ex)
            {

                throw new EstudianteException($"Error al agregar calificación en {materia}", ex);
            }
        }

        public double CalcularPromedio()
        {
            if (calificaciones.Count == 0)

                throw new InvalidOperationException("No hay calificaciones para calcular el promedio");

            double suma = 0;
            foreach (var nota in calificaciones)
            {
                suma += nota;
            }
            return suma / calificaciones.Count;

        }

        public bool EstaAprobado()
        {
            try
            {
                return CalcularPromedio() >= 10.5;
            }
            catch (InvalidOperationException)
            {

                return false;
            }
        }

        public int CompareTo(Estudiante other)
        {
            if (other == null) return 1;

            try
            {
                return this.CalcularPromedio().CompareTo(other.CalcularPromedio());
            }
            catch (InvalidOperationException)
            {

                return string.Compare(this.Nombre, other.Nombre, StringComparison.OrdinalIgnoreCase);
            }
        }

        public override string ObtenerInformacionCompleta()
        {
            var info = new StringBuilder();

            info.AppendLine($"Estudiante: {Nombre}");
            info.AppendLine($"Código: {CodigoEstudiante}");
            info.AppendLine($"Carrera: {Carrera}");
            info.AppendLine($"Edad: {CalcularEdad()} años");
            try
            {
                info.AppendLine($"Promedio: {CalcularPromedio():F2}");
                info.AppendLine($"Estado: {(EstaAprobado() ? "APROBADO" : "REPROBADO")}");
            }
            catch (InvalidOperationException)
            {
                info.AppendLine("Sin calificaciones registradas");
            }
            return info.ToString();
        }
        public IEnumerable<string> ObtenerMaterias() => materiasInscritas;
        public Dictionary<string, double> ObtenerCalificacionesPorMateria() => new Dictionary<string, double>(calificacionesPorMateria);
    }
}
