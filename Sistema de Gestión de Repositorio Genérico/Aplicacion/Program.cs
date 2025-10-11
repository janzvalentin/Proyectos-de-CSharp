using Sistema_de_Gestión_de_Repositorio_Genérico.Entidades;
using Sistema_de_Gestión_de_Repositorio_Genérico.Excepciones;
using Sistema_de_Gestión_de_Repositorio_Genérico.Logica_de_Negocio;
using Sistema_de_Gestión_de_Repositorio_Genérico.Repositorios;
class Program
{
    static void Main()
    {
        Console.WriteLine("Sistema de Gestión de Inventario");

        // Creamos las instancias de los repositorios
        var repoProductos = new Repositorio<Producto>();
        var repoClientes = new Repositorio<Cliente>();

        // Inyectamos esas instancias al crear el GestorInventario.
        var gestor = new GestorInventario(repoProductos, repoClientes);

        // Bloque para agregar datos de ejemplo y manejar posibles errores al iniciar.
        try
        {

            gestor.AgregarProducto(new Producto(1, "Laptop Gamer", 1200.50, 15));
            gestor.AgregarProducto(new Producto(2, "Mouse Óptico", 25.00, 50));
            gestor.AgregarProducto(new Producto(3, "Teclado Mecánico", 80.75, 5));

            gestor.AgregarCliente(new Cliente(101, "Ana Torres", "ana.t@email.com", new DateTime(2023, 5, 15)));
            gestor.AgregarCliente(new Cliente(102, "Luis B.", "luis.b@email.com", new DateTime(2023, 8, 22)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inicializando datos: {ex.Message}");
        }

        // Bucle principal del menú de la aplicación.
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ DE GESTIÓN ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Agregar cliente");
            Console.WriteLine("3. Buscar producto por ID");
            Console.WriteLine("4. Listar todos los productos");
            Console.WriteLine("5. Listar productos con stock bajo");
            Console.WriteLine("6. Ver valor total del inventario");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            // Usamos un bloque try-catch para capturar cualquier error 
            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.Write("ID del producto: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Precio del producto: ");
                        double precio = double.Parse(Console.ReadLine());
                        Console.Write("Stock del producto: ");
                        int stock = int.Parse(Console.ReadLine());
                        gestor.AgregarProducto(new Producto(id, nombre, precio, stock));
                        Console.WriteLine("¡Producto agregado con éxito!");
                        break;

                    case "2": // Agregar nuevo cliente
                        Console.WriteLine("\n--- Agregar Nuevo Cliente ---");
                        Console.Write("ID del cliente: ");
                        int idCli = int.Parse(Console.ReadLine());
                        Console.Write("Nombre del cliente: ");
                        string nombreCli = Console.ReadLine();
                        Console.Write("Email del cliente: ");
                        string emailCli = Console.ReadLine();
                        // Usamos DateTime.Now para la fecha de registro actual
                        gestor.AgregarCliente(new Cliente(idCli, nombreCli, emailCli, DateTime.Now));
                        Console.WriteLine("¡Cliente agregado con éxito!");
                        break;

                    case "3":
                        Console.Write("Ingrese el ID del producto a buscar: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        Producto productoEncontrado = gestor.BuscarProductoPorId(idBuscar);
                        Console.WriteLine("Producto encontrado:");
                        Console.WriteLine(productoEncontrado.ObtenerDescripcion());
                        break;

                    case "4":
                        Console.WriteLine("\n--- Listado de Todos los Productos ---");
                        var todos = gestor.ListarTodosLosProductos();
                        if (todos.Count == 0)
                        {
                            Console.WriteLine("No hay productos en el inventario.");
                        }
                        foreach (var p in todos)
                        {
                            Console.WriteLine(p.ObtenerDescripcion());
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n--- Productos con Stock Bajo (<10) ---");
                        // Usamos ToList() para poder contar los elementos fácilmente.
                        var bajos = gestor.ObtenerProductosStockBajo().ToList();
                        if (bajos.Count == 0)
                        {
                            Console.WriteLine("No hay productos con stock bajo.");
                        }
                        foreach (var p in bajos)
                        {
                            Console.WriteLine(p.ObtenerDescripcion());
                        }
                        break;

                    case "6":
                        double valorTotal = gestor.CalcularValorTotalInventario();
                        Console.WriteLine($"\nEl valor total del inventario es: {valorTotal:c}");
                        break;

                    case "7":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            // Capturamos específicamente nuestra excepción personalizada.
            catch (RepositorioException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR DE REPOSITORIO: {ex.Message}");
                Console.ResetColor();
            }
            // Capturamos excepciones de argumentos inválidos (ej. precio negativo).
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR DE DATOS: {ex.Message}");
                Console.ResetColor();
            }
            // Capturamos un error común si el usuario ingresa texto en lugar de un número.
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERROR DE FORMATO: Ingrese un número válido.");
                Console.ResetColor();
            }
            // Bloque catch genérico para cualquier otro error inesperado.
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"OCURRIÓ UN ERROR INESPERADO: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}