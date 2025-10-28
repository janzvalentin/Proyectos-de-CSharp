using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Modelos;
using Sistema_de_Notificaciones_con_Eventos_y_Delegates.Nucleo;
using static Sistema_de_Notificaciones_con_Eventos_y_Delegates.Delegados.Personalizados;

Console.WriteLine("=== SISTEMA DE NOTIFICACIONES CON DELEGATES Y EVENOS ===");
//Creamos el almacen Observable
var almacen = new AlmacenObservable<Producto>();
//Creamos suscriptores
var admin = new SuscriptorNotificaciones("Administrados");
var sistema = new SuscriptorNotificaciones("Sistema de Alertas");

//===Suscribir a eventos usando diferentes sintaxis
//1.-Método nombrado
almacen.ItemAgregado += admin.OnItemAgregado;
//2.-Expresion Lambda
NotificadorCambio<Producto> lambdaHandler =
                (p, accion) => Console.WriteLine($"[Lambda] Producto {p.Nombre} fue {accion.ToLower()}");
almacen.ItemAgregado += lambdaHandler;
//3.-Método anónimo
NotificadorCambio<Producto> anonimoHandler = delegate (Producto p, string accion)
{
    Console.WriteLine($"[Anónimo] Se {accion.ToLower()} el producto: {p.Nombre}");
};
almacen.ItemAgregado += anonimoHandler;
//Otros eventos
almacen.ItemEliminado += admin.OnItemEliminado;
almacen.AlertaStockBajo += sistema.OnAlertaStockBajo;
almacen.AlertaStockBajo += admin.OnAlertaStockBajo;
//Suscriptor que lanza error para probar manejo de excepciones
almacen.ItemAgregado += (p, accion) =>
{
    if (p.Nombre.Contains("Error"))
        throw new Exception("Simulación de error en manejador de eventos");
};
//Validacion
ValidadorItem<Producto> validador = p => p.Precio > 0 && p.Stock >= 0;
//Procesador y generador
var procesador = new ProcesadorProductos(almacen);
var generador = new GeneradorReportes();

//Menu interactivo con opciones:
int opcion;
do
{
    Console.WriteLine("\n--- MENÚ ---");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Eliminar producto");
    Console.WriteLine("3. Filtrar productos");
    Console.WriteLine("4. Aplicar descuento");
    Console.WriteLine("5. Generar reportes");
    Console.WriteLine("6. Ver historial de notificaciones");
    Console.WriteLine("7. Buscar productos por nombre");
    Console.WriteLine("8. Mostrar productos con stock bajo");
    Console.WriteLine("9. Salir");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción inválida. Intente nuevamente.");
        continue;
    }

    Console.WriteLine();

    try
    {
        switch (opcion)
        {
            case 1:
                var producto = new Producto();

                Console.Write("Ingrese ID: ");
                producto.Id = int.Parse(Console.ReadLine());

                Console.Write("Ingrese nombre: ");
                producto.Nombre = Console.ReadLine();

                Console.Write("Ingrese categoría: ");
                producto.Categoria = Console.ReadLine();

                Console.Write("Ingrese precio: ");
                producto.Precio = decimal.Parse(Console.ReadLine());

                Console.Write("Ingrese stock: ");
                producto.Stock = int.Parse(Console.ReadLine());

                almacen.Agregar(producto, validador);
                break;

            case 2:
                Console.Write("Ingrese ID del producto a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine());
                if (!almacen.Eliminar(idEliminar))
                    Console.WriteLine("No se encontró un producto con ese ID.");
                break;

            case 3:
                Console.Write("Ingrese precio mínimo: ");
                decimal minimo = decimal.Parse(Console.ReadLine());
                var filtrados = procesador.Filtrar(p => p.Precio > minimo);
                Console.WriteLine("Productos filtrados:");
                foreach (var f in filtrados)
                    Console.WriteLine($"- {f.Nombre}: {f.Precio:c}");
                break;

            case 4:
                Console.Write("Ingrese porcentaje de descuento (ej. 10 para 10%): ");
                decimal desc = decimal.Parse(Console.ReadLine()) / 100;
                procesador.AplicarDescuento(p => p.Precio -= p.Precio * desc);
                Console.WriteLine("Descuento aplicado correctamente.");
                break;

            case 5:
                var listaProductos = new List<Producto>(almacen.ObtenerTodos());
                FormateadorItem<Producto> formato1 = p => $"{p.Nombre} - {p.Precio:c}";
                FormateadorItem<Producto> formato2 = p => $"{p.Categoria.ToUpper()} | {p.Nombre} ({p.Stock} unds)";
                generador.GenerarReportesMultiples(listaProductos, formato1, formato2);
                break;

            case 6:
                admin.MostrarHistorial();
                sistema.MostrarHistorial();
                break;

            case 7:
                Console.Write("Ingrese texto a buscar: ");
                string texto = Console.ReadLine();
                var encontrados = procesador.BuscarProductos(p => p.Nombre.Contains(texto));
                Console.WriteLine("Resultados de búsqueda:");
                foreach (var e in encontrados)
                    Console.WriteLine($"- {e.Nombre}");
                break;

            case 8:
                Console.WriteLine("Productos con stock bajo:");
                foreach (var p in almacen.ObtenerTodos())
                {
                    if (p.Stock < 3)
                    {
                        almacen.DispararAlertaStockBajo(p, "Stock bajo detectado", 2);
                    }
                }
                break;

            case 9:
                Console.WriteLine("Saliendo del sistema...");
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Error] {ex.Message}");
    }
} while (opcion !=9);
Console.WriteLine("\n=== Fin del programa ===");



































