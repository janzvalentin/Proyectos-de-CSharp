using System;
using System.Numerics;

class Program
{
    //ARRAYS GLOBALES PARA ALM
    static string[] nombres = new string[2];
    static double[] precios = new double[2];
    static int[] cantidades = new int[2];
    static int totalProductos = 0;

    static void Main(string[] args)
    {
        //NOMBRE DEL PROYECTO
        Console.WriteLine("====Sistema de Gestión de Inventario====");
        Console.WriteLine(new string('-', 40));

        //BUBLE DEL MENU DE OPCIONES
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":

                    if (totalProductos >= 2)
                    {
                        Console.WriteLine("El inventario esta lleno.");
                        break;
                    }

                    Console.WriteLine("\nAregar producto:");
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Ingrese nombre del producto:");
                    string nombre = Console.ReadLine();

                    double precio = 0;
                    while (true)
                    {
                        Console.Write("Ingrese precio: ");
                        if (double.TryParse(Console.ReadLine(), out precio))
                        {
                            if (precio > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: EL PRECIO TIENE QUE SE MAYOR A 0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR: INGRESE UN NUMERO VÁLIDA.");
                        }
                    }
                    int cantidad = 0;
                    while (true)
                    {

                        Console.Write("Ingrese cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out cantidad))
                        {
                            if (cantidad >= 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERROS: LA CANTIDAD TIENE QUE SER MAYOR A 0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR: CANTIDAD INVÁLIDA");
                        }
                    }
                    if (AgregarProducto(nombres, precios, cantidades, ref totalProductos, nombre, precio, cantidad))
                    {
                        Console.WriteLine("¡PRODUCTO AGREGADO!");
                    }
                    Console.WriteLine(new string('-', 40));
                    break;

                case "2":
                    Console.WriteLine("\nBuscar Producto: ");
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Buscar nombre del producto: ");
                    string nombreBuscar = Console.ReadLine();

                    int indice = BuscarProducto(nombres, totalProductos, nombreBuscar);
                    if (indice != -1)
                    {
                        Console.WriteLine(new string('-', 50));
                        Console.WriteLine("=====PRODUCTO ENCONTRADO=====");
                        Console.WriteLine(new string('-', 50));
                        Console.WriteLine("{0,-10} {1,10} {2,8} {3,15}", "PRODUCTO", "PRECIO", "CANTIDAD", "SUBTOTAL");

                        double subtotal = precios[indice] * cantidades[indice];

                        Console.WriteLine("{0,-10} {1,10:C} {2,8} {3,15:C}", nombres[indice], precios[indice], cantidades[indice], subtotal);
                        Console.WriteLine(new string('-', 50));
                    }
                    else
                    {
                        Console.WriteLine("Procuto no encontrado.");
                    }
                    break;
                case "3":
                    MostrarInventario(nombres, precios, cantidades, totalProductos);
                    break;
                case "4":
                    Console.WriteLine();
                    double valorTotal = CalcularValorTotal(precios, cantidades, totalProductos);
                    Console.WriteLine($"Valor total del inventario: {valorTotal:C}");
                    Console.WriteLine(new string('-', 40));
                    break;
                case "5":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        }

    }

    static void MostrarMenu()
    {
        Console.WriteLine("*****Menú de opciones*****");
        Console.WriteLine("1.- Agregar producto");
        Console.WriteLine("2.- Buscar producto");
        Console.WriteLine("3.- Mostrar inventario");
        Console.WriteLine("4.- Calcular valor total");
        Console.WriteLine("5.- Salir");
        Console.WriteLine(new string('-', 40));

    }

    static bool AgregarProducto(string[] nombres, double[] precios, int[] cantidades, ref int totalproductos, string nombre,
        double precio, int cantidad)
    {
        if (precio <= 0)
        {
            Console.WriteLine("Precio incorrecta.");
            return false;
        }
        if (cantidad < 0)
        {
            Console.WriteLine("Cantidad incorrecta.");
            return false;
        }
        if (BuscarProducto(nombres, totalproductos, nombre) != -1)
        {
            return false;
        }
        if (totalproductos >= 2)
        {
            Console.WriteLine("Inventario lleno.");
        }
        nombres[totalproductos] = nombre;
        precios[totalproductos] = precio;
        cantidades[totalproductos] = cantidad;
        totalproductos++;
        return true;

    }
    static int BuscarProducto(string[] nombres, int totalProductos, string nombreBuscar)
    {
        for (int i = 0; i < totalProductos; i++)
        {
            if (nombres[i].Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }
    static void MostrarInventario(string[] nombres, double[] precios, int[] cantidades, int totalProductos)
    {
        if (totalProductos == 0)
        {
            Console.WriteLine("Inventario vacío. Agregue productos(opción 1)");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("============INVENTARIO ACTUAL============");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("{0,-10} {1,10} {2,8} {3,15}", "PRODUCTO", "PRECIO", "CANTIDAD", "SUBTOTAL");

        for (int i = 0; i < totalProductos; i++)
        {
            double subtotal = precios[i] * cantidades[i];
            Console.WriteLine("{0,-10} {1,9:C} {2,8} {3,14:C}", nombres[i], precios[i], cantidades[i], subtotal);

        }
        Console.WriteLine(new string('-', 50));
    }
    static double CalcularValorTotal(double[] precios, int[] cantidades, int totalProductos)
    {
        double total = 0;
        for (int i = 0; i < totalProductos; i++)
        {
            total += precios[i] * cantidades[i];
        }
        return total;
    }
}