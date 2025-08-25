using Sistema_de_Gestión_de_Biblioteca;
using System.Dynamic;

Biblioteca biblioteca = new Biblioteca();
bool salir = false;
while (!salir)
{
    Console.WriteLine("\n=== SISTEMA DE GESTION DE BIBLIOTECA ===");
    Console.WriteLine("1. Gestion de Materiales");
    Console.WriteLine("  1.1 Agregar material (Libro/Revista/DVD)");
    Console.WriteLine("  1.2 Buscar material");
    Console.WriteLine("  1.3 Mostrar inventario completo");
    Console.WriteLine("  1.4 Eliminar material");
    Console.WriteLine("2. Gestion de usuarios");
    Console.WriteLine("  2.1 Registrar usuario");
    Console.WriteLine("  2.2 Buscar usuario");
    Console.WriteLine("  2.3 Ver historial de prestamos");
    Console.WriteLine("3. Operaciones de Prestamos");
    Console.WriteLine("  3.1 Prestar material");
    Console.WriteLine("  3.2 Devolver material");
    Console.WriteLine("  3.3 Calcular multas pendientes");
    Console.WriteLine("4. Resportes");
    Console.WriteLine("  4.1 Materiales mas prestados");
    Console.WriteLine("  4.2 Usuarios con mas prestamos");
    Console.WriteLine("  4.3 Multas pendientes");
    Console.WriteLine("  4.4 Estadísticas generales");
    Console.WriteLine("5. Salir");

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        //1. Gestion de materiales
        case "1.1":
            Console.WriteLine("Seleccione tipo: 1)Libro 2)Revista 3)DVD");
            string tipo = Console.ReadLine();

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor/Directos: ");
            string autor = Console.ReadLine();

            Console.Write("Año: ");
            int año = int.Parse(Console.ReadLine());

            if (tipo == "1")
            {
                Console.Write("Páginas: ");
                int paginas = int.Parse(Console.ReadLine());

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();
                biblioteca.AgregarMaterial(new Libro(titulo, autor, año, paginas, isbn));
            }
            else if (tipo == "2")
            {
                Console.Write("Numero de edicion: ");
                int edicion = int.Parse(Console.ReadLine());

                Console.Write("periodicidad: ");
                string periodicidad = Console.ReadLine();
                biblioteca.AgregarMaterial(new Revista(titulo, autor, año, edicion, periodicidad));
            }
            else if (tipo == "3")
            {
                Console.Write("Duracion de minutos: ");
                int duracion = int.Parse(Console.ReadLine());

                Console.WriteLine("Director: ");
                string director = Console.ReadLine();
                biblioteca.AgregarMaterial(new DVD(titulo, autor, año, duracion, director));
            }
            break;

        case "1.2":
            Console.Write("Ingrese titulo a buscar: ");
            string criterio = Console.ReadLine();

            var material = biblioteca.BuscarMaterial(criterio);
            Console.WriteLine(material != null ? material.ObtenerInformacion() : "No encontrado.");
            break;

        case "1.3":
            biblioteca.GenerarReporte();
            break;

        case "1.4":
            Console.Write("Ingrese el título del material a eliminar: ");
            string tituloEliminar = Console.ReadLine();
            biblioteca.EliminarMaterial(tituloEliminar);
            break;


        //2. Gestion de usuarios
        case "2.1":
            Console.Write("Nombre Usuario: ");
            string nombre = Console.ReadLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Limite de prestamos: ");
            int limite = int.Parse(Console.ReadLine());

            biblioteca.AgregarUsuario(new Usuario(nombre, id, limite));
            break;

        case "2.2":
            Console.Write("ID del usuario: ");
            int idUsuario = int.Parse(Console.ReadLine());

            Usuario usuario = biblioteca.BuscarUsuario(idUsuario);

            Console.WriteLine(usuario != null ? $"Usuario: {usuario.Nombre}, ID: {usuario.NumeroIdentificacion}" : "usuario no encontrado.");
            break;

        case "2.3":
            Console.Write("Ingrese el ID del usuario: ");
            int idHistorial = int.Parse(Console.ReadLine());
            Usuario usuarioHistorial = biblioteca.BuscarUsuario(idHistorial);

            if (usuarioHistorial != null)
            {
                usuarioHistorial.MostrarHistorial();
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            break;

        //3. operaciones de prestamo
        case "3.1":
            Console.Write("ID del usuario: ");
            int idUsuarioP = int.Parse(Console.ReadLine());

            Console.Write("Titulo del material: ");
            string tituloP = Console.ReadLine();

            Usuario usuarioP = biblioteca.BuscarUsuario(idUsuarioP);
            MaterialBase materialBase = biblioteca.BuscarMaterial(tituloP);

            if (usuarioP != null && materialBase != null)
            {
                usuarioP.PrestarMaterial(materialBase);
            }
            else
            {
                Console.WriteLine("Usuario o material no encontrado.");
            }
            break;

        case "3.2":
            Console.Write("ID del usuario: ");
            int idUsuarioD = int.Parse(Console.ReadLine());

            Console.Write("Titulo del material: ");
            string tituloD = Console.ReadLine();

            Usuario usuarioD = biblioteca.BuscarUsuario(idUsuarioD);
            MaterialBase matD = biblioteca.BuscarMaterial(tituloD);

            if (usuarioD != null && matD != null)
            {
                usuarioD.DevolverMaterial(matD);
            }
            else
            {
                Console.WriteLine("Usuario o material no encontrado."); 
            }
            break;


        case "3.3":
            Console.Write("Ingrese el ID del usuario: ");
            int idMulta = int.Parse(Console.ReadLine());
            Usuario usuarioMulta = biblioteca.BuscarUsuario(idMulta);

            if (usuarioMulta != null)
            {
                usuarioMulta.CalcularMultas();
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            break;

        //4. Reportes
        case "4.1":
            biblioteca.ReporteMaterialesMasPrestados();
            break;

        case "4.2":
            biblioteca.ReporteUsuariosMasPrestamos();
            break;

        case "4.3":
            biblioteca.ReporteMultasPendientes();
            break;

        case "4.4":
            biblioteca.ReporteEstadisticasGenerales();
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opcion no valida.");
            break;
    }
}
Console.WriteLine("¡Gracias por usar el sistema de biblioteca!");