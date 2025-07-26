using System;
using System.Numerics;

class Program
{
    //ARRAYS GLOBALES 
    static string[] nombres = new string[2]; //ALMACENA NOMBRES DE PRODUCTOS
    static double[] precios = new double[2];//ALMACENA PRECIOS
    static int[] cantidades = new int[2];//ALMACENA LAS CANTIDADES
    static int totalProductos = 0; //ESTE ES UN CONTADOR DE LOS PRODUCTOS INGRESADOS

    static void Main(string[] args)
    {
        //NOMBRE DEL PROYECTO
        Console.WriteLine("====Sistema de Gestión de Inventario====");
        Console.WriteLine(new string('-', 40));//LINEA SQUE SEPARA CON 40 GUINES

        //BUBLE PRINCIPAL DEL MENU DE OPCIONES
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();// MUESTRA LAS OPCIONES DISPONIBLES
            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine(); //LEE LAS OPCIONESDEL USUARIO

            switch (opcion)
            {
                case "1": //Opción agregar producto

                    if (totalProductos >= 2)
                    {
                        Console.WriteLine("El inventario esta lleno.");
                        break; //sale del bucle y evita seguir piendo datos cuando ya esta lleno
                    }
                  
                    Console.WriteLine("\nAregar producto:");
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Ingrese nombre del producto:");
                    string nombre = Console.ReadLine();

                    //VALIDAD PRECIO
                    double precio = 0;
                    while (true)
                    {
                        Console.Write("Ingrese precio: ");
                        if (double.TryParse(Console.ReadLine(), out precio))
                        {
                            if (precio > 0)
                            {
                                break; // SALE DEL BUCLE SI EN PRECIO ES VALIDO
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

                    //VALIDAR CANTIDAD
                    int cantidad = 0;
                    while (true)
                    {

                        Console.Write("Ingrese cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out cantidad))
                        {
                            if (cantidad >= 0)
                            {
                                break; //ESTO INDICA QUE LA CANTIDAS INGRESADA FUE CORRECTO Y SALE DEL BUCLE PARA QUE SE GUARDE
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

                    //LLAMA AL METODO PARA AGREGAR PRODUCTO
                    if (AgregarProducto(nombres, precios, cantidades, ref totalProductos, nombre, precio, cantidad))
                    {
                        Console.WriteLine("¡PRODUCTO AGREGADO!");
                    }
                    Console.WriteLine(new string('-', 40));
                    break;

                case "2": //Opción para buscar producto
                    Console.WriteLine("\nBuscar Producto: ");
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Buscar nombre del producto: ");
                    string nombreBuscar = Console.ReadLine();

                    int indice = BuscarProducto(nombres, totalProductos, nombreBuscar);
                    if (indice != -1) //Si el indice producto que estoy buscando me arroja que ya existe(!=-1)
                    {
                        //ME ARROJARIA QUE EL PRODUCTO FUE ENCONTRADO Y ME MUESTRA LA INFORMACION TIPO TABLA
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
                case "3": //Opción para mostrar el inventario completo
                    MostrarInventario(nombres, precios, cantidades, totalProductos);
                    break;
                case "4": //Opción para calcular el Valor total del inventario
                    Console.WriteLine();
                    double valorTotal = CalcularValorTotal(precios, cantidades, totalProductos);
                    Console.WriteLine($"Valor total del inventario: {valorTotal:C}");
                    Console.WriteLine(new string('-', 40));
                    break;
                case "5": // Opción salir del programa
                    continuar = false; 
                    break;

                default:
                    Console.WriteLine("Opción inválida."); //Si el usuario ingresa una opción no válida
                    break;
            }

        }

    }

    //Método para mostrar el menú

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

    //Método para agregar un producto
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
            Console.WriteLine("Ese producto ya existe.");
            return false;
        }
        if (totalproductos >= 2)
        {
            Console.WriteLine("Inventario lleno.");
            return false;
        }

        //Agrego datos al inventario
        nombres[totalproductos] = nombre;
        precios[totalproductos] = precio;
        cantidades[totalproductos] = cantidad;
        totalproductos++;
        return true;

    }

    //Método para buscar un producto por nombre
    static int BuscarProducto(string[] nombres, int totalProductos, string nombreBuscar)
    {
        for (int i = 0; i < totalProductos; i++)
        {
            if (nombres[i].Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase)) // comprara los nombres que busqué incluso ignora las mayusculas/minusculas
            {
                return i;//Devuelve l indice si lo encuentra
            }
        }
        return -1;//No se encontró lo que estaba buscando
    }

    //Método para mostrar todo el inventario
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

    //Método para calcular valor total del inventario
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