
using Sistema_de_Gestión_de_Estudiantes_Universitarios.Excepciones;
using Sistema_de_Gestión_de_Estudiantes_Universitarios.Modelos;
using Sistema_de_Gestión_de_Estudiantes_Universitarios.Servicios;
using System.Numerics;

class Program
{
    private static GestorUniversidad gestor = new GestorUniversidad();
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE GESTIÓN UNIVERSITARIA ===");
        try
        {
            //Cargar datos de prueba
            CargarDatosPrueba();
            bool continuar = true;
            while (continuar)
            {
                try
                {
                    MostrarMenu();
                    continuar = ProcesarOpcionMenu();
                }
                catch (EstudianteException ex)
                {
                    Console.WriteLine($"Error de negocio: {ex.Message}");
                    if (!string.IsNullOrWhiteSpace(ex.CodigoError))
                    {
                        Console.WriteLine($"Código de error: {ex.CodigoError}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("El sistema continuará funcionando...");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error crítico del sistema: {ex.Message}");
            Console.WriteLine("El sistema debe cerrarse");
        }
        finally
        {
            Console.WriteLine("\nProcesando notificaciones pendientes...");
            gestor.ProcesarNotificaciones();
            Console.WriteLine("Sistema finalizado. Presiona cualquier tecla...");
            Console.ReadKey();
        }
    }
    static void CargarDatosPrueba()
    {
        try
        {
            Console.WriteLine("Cargando datos de prueba...");
            var estudiantes = new[]
            {
        new Estudiante("Ana García", "12345678", new DateTime(2000,5,15),"EST001","Ingeniería de Sistemas"),
        new Estudiante("Carlos López","87654321", new DateTime(1999,8,22),"EST002","Medicina"),
        new Estudiante("María Rodriguez","11223344", new DateTime(2001,2,10),"EST003","Ingeniería de Sistemas")
        };

            foreach (var estudiante in estudiantes)
            {
                gestor.RegistrarEstudiante(estudiante);

                //Agregar calificaciones de prueba
                var random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    var calificacion = random.NextDouble() * 20; //0-20
                    estudiante.AgregarCalificacion(calificacion);
                }
            }
            Console.WriteLine("Datos de prueba cargados exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar datos de prueba:{ex.Message}");
        }
    }
    static void MostrarMenu()
    {
        Console.WriteLine("\n" + "=".PadRight(50, '='));
        Console.WriteLine("MENÚ PRINCIPAL");
        Console.WriteLine("=".PadRight(50, '='));
        Console.WriteLine("1.Registrar nuevo estudiante");
        Console.WriteLine("2.Buscar estudiante");
        Console.WriteLine("3.Agregar calificación");
        Console.WriteLine("4.Ver estudiantes aprobados");
        Console.WriteLine("5.Generar reporte completo");
        Console.WriteLine("6.Ver historial de operaciones");
        Console.WriteLine("7.Procesar notificaciones");
        Console.WriteLine("8.Demostrar manejo de excepciones");
        Console.WriteLine("9.Salir");
        Console.WriteLine("=".PadRight(50, '='));
        Console.Write("Seleccione una opción: ");
    }
    static bool ProcesarOpcionMenu()
    {
        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            throw new ArgumentException("Opción inválida. Debe ser un numero.");
        }
        switch (opcion)
        {
            case 1:
                RegistrarNuevoEstudiante();
                break;
            case 2:
                BuscarEstudiante();
                break;
            case 3:
                AgregarCalificacion();
                break;
            case 4:
                MostrarEstudiantesAprobados();
                break;
            case 5:
                gestor.GenerarReporteCompleto();
                break;
            case 6:
                gestor.MostrarHistorialReciente();
                break;
            case 7:
                gestor.ProcesarNotificaciones();
                break;
            case 8:
                DemostrarManejoExcepciones();
                break;
            case 9:
                return false;
            default:
                throw new ArgumentOutOfRangeException("Opción fuera del rango válido (1-9");

        }
        return true;
    }

    static void RegistrarNuevoEstudiante()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Identificación: ");
        string identificacion = Console.ReadLine();
        Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
        DateTime fecha = DateTime.Parse(Console.ReadLine());
        Console.Write("Código estudiante: ");
        string codigo = Console.ReadLine();
        Console.Write("Carrera: ");
        string carrera = Console.ReadLine();

        var estudiante = new Estudiante(nombre, identificacion, fecha, codigo, carrera);
        gestor.RegistrarEstudiante(estudiante);
    }
    static void BuscarEstudiante()
    {
        Console.Write("Ingrese código del estudiante: ");
        string codigo = Console.ReadLine();
        var estudiante = gestor.BuscarEstudiante(codigo);
        Console.WriteLine(estudiante.ObtenerInformacionCompleta());
    }
    static void AgregarCalificacion()
    {
        Console.Write("Ingrese código del estudiante: ");
        string codigo = Console.ReadLine();
        var estudiante = gestor.BuscarEstudiante(codigo);

        Console.Write("Ingrese materia: ");
        string materia = Console.ReadLine();
        Console.Write("ingrese calificacion (0-20)");
        Double calificacion = double.Parse(Console.ReadLine());

        estudiante.AgregarCalificacionMateria(materia, calificacion);
        Console.WriteLine("Calificación registrada correctamente.");
    }
    static void MostrarEstudiantesAprobados()
    {
        Console.WriteLine("=== ESTUDIANTES APROBADOS ===");
        foreach (var est in gestor.ObtenerEstudiantesAprobados())
        {
            Console.WriteLine(est.ObtenerInformacionCompleta());
        }
    }
    //Método que demuestra manejo avanzado de excepciones
    static void DemostrarManejoExcepciones()
    {
        Console.WriteLine("\n=== DEMOSTRACIÓN DE MANEJO DE EXCEPCIONES");

        var casos = new Dictionary<string, Action>
        {
            ["Calificación inválida"] = () =>
            {
                var estudiante = new Estudiante("Test", "123", DateTime.Now.AddYears(-20), "TEST", "Test");
                estudiante.AgregarCalificacion(25); // Debe fallar
            },

            ["Estudiante duplicado"] = () =>
            {
                var estudiante1 = new Estudiante("Test1", "123", DateTime.Now.AddYears(-20), "DUP001", "Test");
                var estudiante2 = new Estudiante("Test2", "456", DateTime.Now.AddYears(-21), "DUP001", "Test");
                gestor.RegistrarEstudiante(estudiante1);
                gestor.RegistrarEstudiante(estudiante2); //Debe fallar
            },

            ["Datos inválidos"] = () =>
            {
                var estudiante = new Estudiante("", "123", DateTime.Now.AddYears(-20), "INVALID", "Test");
            }
        };

        foreach (var caso in casos)
        {
            try
            {
                Console.WriteLine($"\nProbando: {caso.Key}");
                caso.Value();
                Console.WriteLine("No se generó la excepción esperada");
            }
            catch (EstudianteException ex)
            {
                Console.WriteLine($"Excepción de negocio capturada: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($" Excepción interna: {ex.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Excepción general capturada: {ex.GetType().Name} - {ex.Message} ");
            }
        }
    }
}