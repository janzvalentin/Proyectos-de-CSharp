using Sistema_de_Gestión_de_Estudiantes_Universitarios.Excepciones;
using Sistema_de_Gestión_de_Estudiantes_Universitarios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Estudiantes_Universitarios.Servicios
{
    public class GestorUniversidad
    {
        private Dictionary<string, Estudiante> estudiantes;
        private List<string> carreras;
        private SortedDictionary<string, List<Estudiante>> estudiantesPorCarrera;
        private Queue<string> notificacionesPendientes;
        private Stack<string> historialOperaciones;

        public GestorUniversidad()
        {
            estudiantes = new Dictionary<string, Estudiante>();
            carreras = new List<string>();
            estudiantesPorCarrera = new SortedDictionary<string, List<Estudiante>>();
            notificacionesPendientes = new Queue<string>();
            historialOperaciones = new Stack<string>();
        }

        public void RegistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (estudiante == null)
                    throw new ArgumentNullException(nameof(estudiante));

                if (estudiantes.ContainsKey(estudiante.CodigoEstudiante))
                    throw new EstudianteException($"Ya existe un estudiante con código {estudiante.CodigoEstudiante}", "EST002");

                //Agregar colecciones
                estudiantes.Add(estudiante.CodigoEstudiante, estudiante);

                if (!carreras.Contains(estudiante.Carrera))
                    carreras.Add(estudiante.Carrera);

                if (!estudiantesPorCarrera.ContainsKey(estudiante.Carrera))
                    estudiantesPorCarrera[estudiante.Carrera] = new List<Estudiante>();

                estudiantesPorCarrera[estudiante.Carrera].Add(estudiante);

                //Registrar operación
                historialOperaciones.Push($"Registrado: {estudiante.Nombre} - {DateTime.Now}");
                notificacionesPendientes.Enqueue($"Nuevo estudiante registrado: {estudiante.Nombre}");

                Console.WriteLine($"Estudiante {estudiante.Nombre} registrado exitosamente");
            }
            catch (EstudianteException ex)
            {
                Console.WriteLine($"Error específico de estudiante: {ex.Message} (Código: {ex.CodigoError})");
                throw; // Re-lanzar para manejo superior
            }
            catch (Exception ex)
            {
                var mensajeError = $"Error inesperado al registrar estudiante: {ex.Message}";
                historialOperaciones.Push($"ERROR: {mensajeError} - {DateTime.Now}");
                throw new EstudianteException(mensajeError, ex);
            }

        }
        public Estudiante BuscarEstudiante(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new ArgumentException("El código no puede estar vacío", nameof(codigo));

                if (estudiantes.TryGetValue(codigo, out Estudiante estudiante))
                {
                    historialOperaciones.Push($"Consultado: {codigo} - {DateTime.Now}");
                    return estudiante;
                }
                throw new EstudianteException($"No se encontró estudiante con código {codigo}", "EST003");
            }
            catch (EstudianteException)
            {

                throw;//Re-lanzar excepciones de negocio
            }
            catch (Exception ex)
            {
                throw new EstudianteException($"ERROR al buscar estudiante: {ex.Message}", ex);
            }
        }
        public IEnumerable<Estudiante> ObtenerEstudiantesAprobados()
        {
            foreach (var estudiante in estudiantes.Values)
            {
                bool aprobado = false;
                try
                {
                    aprobado = estudiante.EstaAprobado();
                }
                catch (InvalidOperationException)
                {
                    //SI no tiene notas, lo saltamos como no aprobado
                    aprobado = false;
                }
                if (aprobado)
                {
                    yield return estudiante;
                }
            }
        }

        public void GenerarReporteCompleto()
        {
            try
            {
                var reporte = new StringBuilder();
                reporte.AppendLine("=== REPORTE UNIVERSITARIO ===");
                reporte.AppendLine($"Fecha: {DateTime.Now: dd/MM/yyyy HH:mm}");
                reporte.AppendLine($"Total de estudiantes: {estudiantes.Count}");
                reporte.AppendLine($"Total de carreras: {carreras.Count}");

                //Estadística por carrera
                reporte.AppendLine("=== ESTADÍSTICA POR CARRERA ===");
                foreach (var carrera in estudiantesPorCarrera)
                {
                    var estudiantesCarrera = carrera.Value;
                    int aprobados = 0;
                    foreach (var e in estudiantesCarrera)
                    {
                        try
                        {
                            if (e.EstaAprobado()) aprobados++;
                        }
                        catch { }
                    }
                    reporte.AppendLine($"Carrera: {carrera.Key}");
                    reporte.AppendLine($" - Total: {estudiantesCarrera.Count}");
                    reporte.AppendLine($" - Aprobados: {aprobados}");
                    reporte.AppendLine($" - Reprobados: {estudiantesCarrera.Count - aprobados}");
                }

                //Top 5 estudiantes
                reporte.AppendLine("\n === Top 5 ESTUDIANTES ===");
                var listaOrdenada = new List<Estudiante>();

                //Copiar estudiantes a lista
                foreach (var e in estudiantes.Values)
                {
                    try
                    {
                        e.CalcularPromedio(); //si lanza error, lo excluimos
                        listaOrdenada.Add(e);
                    }
                    catch { }
                }
                //Ordenar manualmente
                listaOrdenada.Sort((a, b) =>
                {
                    double promedioA = a.CalcularPromedio();
                    double promedioB = b.CalcularPromedio();
                    return promedioB.CompareTo(promedioA);

                });
                int limite = Math.Min(5, listaOrdenada.Count);
                for (int i = 0; i < limite; i++)
                {
                    var est = listaOrdenada[i];
                    reporte.AppendLine($"{est.Nombre}: {est.CalcularPromedio():F2}");
                }

                Console.WriteLine(reporte.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar reporte: {ex.Message}");
            }
        }
        //Método para procesar notificaciones pendientes
        public void ProcesarNotificaciones()
        {
            Console.WriteLine("=== PROCESANDO NOTIFICACIONES ===");
            while (notificacionesPendientes.Count > 0)
            {
                var notificacion = notificacionesPendientes.Dequeue();
                Console.WriteLine($"{notificacion}");
            }
        }
        //Método para mostrar historial reciente
        public void MostrarHistorialReciente(int cantidad = 5)
        {
            Console.WriteLine($"=== ÚLTIMAS {cantidad} OPERACIONES ===");

            var historialArray = historialOperaciones.ToArray();
            int limite = Math.Min(cantidad, historialArray.Length);
            for (int i = 0; i < limite; i++)
            {
                Console.WriteLine($"* {historialArray[i]}");
            }

        }

    }
}
