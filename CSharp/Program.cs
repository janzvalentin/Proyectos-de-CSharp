using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
#region VARIABLES Y TIPOS DE DATOS / IMPRIMIR Y LEER EN CONSOLA
/* VARIABLES Y TIPOS DE DATOS
    int edad = 32;
float altura = 1.75f;
string nombre = "Janz";
bool esProgramador = true;
*/



//Ejercicio 1: Tu perfil en consola
/*
Console.WriteLine("Ingresa tu nombre:");
string nombre=Console.ReadLine();

Console.WriteLine("Ingresa tu edad");
int edad=Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Ingresa tu altura:");
float altura=float.Parse(Console.ReadLine());

Console.WriteLine("¿Eres estudiante?(si/no):");
string respuesta=Console.ReadLine().ToLower();

bool estudiante = (respuesta == "si"|| respuesta=="si");

Console.WriteLine($"Hola, {nombre}.");
Console.WriteLine($"Tienes {edad} años, mides {altura} metros.");
Console.WriteLine($"¿Eres estudiante? {(estudiante? "Si": "No")}");
Console.ReadLine();
*/

//Ejercicio 2: Calculadora simple
/*
Console.WriteLine("Ingrese el primer numero");
int Pnumero = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese el segundo numero");
int Snumero = int.Parse(Console.ReadLine());


int Suma = Pnumero + Snumero;

int Resta = Pnumero - Snumero;

int multi = Pnumero * Snumero;

Console.WriteLine($"La suma es: {Suma}");
Console.WriteLine($"La resta es: {Resta}");
Console.WriteLine($"La multiplicación es: {multi}");

if (Snumero != 0)
{
    double division = (double)Pnumero / Snumero;
    Console.WriteLine($"La division es: {division}");
}
else
{
    Console.WriteLine("No se puede dividir entre 0.");
}
*/
#endregion

#region CONDICIONALES ( IF, ELSE, ELSE IF Y SWITCH )

//Ejercicio 1: Evaluador de notas
/*
Console.WriteLine("Ingresa tu nota");
double nota = double.Parse(Console.ReadLine());

if (nota >= 18 && nota <= 20)
{
    Console.WriteLine("Excelente");
}
else if (nota >= 11 && nota <= 17)
{
    Console.WriteLine("Aprobado");
}
else if(nota >= 0 && nota <11)
{
        Console.WriteLine("Desaprobado");
}
else
{
    Console.WriteLine("Ingrese un numero de 0 y 20");
}
*/

// Ejercicio 2: Edad y beneficios
/*
Console.WriteLine("Ingresa tu edad");
int edad = int.Parse(Console.ReadLine());

if (edad >= 65)
{
    Console.WriteLine("Eres adulto mayor");
}
else if (edad >= 18)
{
    Console.WriteLine("Eres adulto");
}
else if (edad >= 0)
{
    Console.WriteLine("Eres menor de edad");
}
else
{
    Console.WriteLine("Edad no válida.No se aceptan valores negativos");
}
*/

// Ejercicio 3: Menú bancario (con switch)
/*
Console.WriteLine("*****MENÚ BANCARIO*****");
Console.WriteLine("1.- Ver saldo");
Console.WriteLine("2.- Depositar dinero");
Console.WriteLine("3.- Retirar dinero");
Console.WriteLine("4.- Salir");

Console.WriteLine("Ingrese una opcion:");
int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.WriteLine("Su saldo es S/1000");
        break;
    case 2:
        Console.WriteLine("Depósito realizado");
        break;
    case 3:
        Console.WriteLine("Retiro exitoso");
        break;
    case 4:
        Console.WriteLine("Salir");
        break;
    default:
        Console.WriteLine("Número incorrecto");
        break;
}
*/

//  Mini Reto: "Cajero automático sencillo" (nivel extra)
/*
double saldo = 1000;
Console.WriteLine("******MENÚ DE OPCIONES******");
Console.WriteLine("1.- Ver saldo");
Console.WriteLine("2.- Depositar dinero");
Console.WriteLine("3.- Retirar dinero");
Console.WriteLine("4.- Salir");

Console.WriteLine("Ingrese una de las opciones:");
int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.WriteLine($"El saldo actual es: S/{saldo}");
        break;
    case 2:
        Console.WriteLine("¿Cuánto desea depositar?");
        double depositar = double.Parse(Console.ReadLine());
        saldo += depositar;
        Console.WriteLine($"Su nuevo saldo es: S/{saldo}");
        break;
    case 3:
        Console.WriteLine("¿Cuánto desea retirar?");
        double retiro = double.Parse(Console.ReadLine());
        if (retiro<=saldo)
        {
            saldo -= retiro;
            Console.WriteLine($"Retiro exitoso.Su nuevo saldo es: S/{saldo}");
        }
        else
        {
            Console.WriteLine("Fondos insuficientes.");
        }
            break;
    case 4:
        Console.WriteLine("Gracias por usar nuestro sistema.");
        break;
    default:
        Console.WriteLine("Opción incorrecta.");
        break;
}
*/
#endregion

#region ESTRUCTURAS REPETITIVAS ( WHILE, DO WHILE Y FOR )

// Ejercicio 1: Contador de 1 a 10
/*
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Numero: {i}");
}
*/

// Ejercicio 2: Suma de pares del 1 al 100
/*
int i= 1;
int suma = 0;
while (i<=100)
{

    if (i%2==0)
    {
        Console.WriteLine($"El numero es par: {i}");
        suma += i;
    }
    i++;
}
Console.WriteLine($"La suma de los pares del 1 al 100 es: {suma}");
*/

// Ejercicio 3: Validación de contraseña
/*
string contraseña;

do
{
    Console.WriteLine("Ingrese su contraseña");
    contraseña = Console.ReadLine();

} while (contraseña != "1234");
Console.WriteLine($"Contraseña correcta! {contraseña}");
*/

// Mini Reto: Adivina el número secreto
/*
Random rnd = new Random();
int secreto = rnd.Next(1, 101);

int intentos =1;
int maxIntentos = 7;
int numeroUsuario;
bool acertado = false;

while (intentos < maxIntentos && !acertado)
{
    Console.Write($"Intento #{intentos}: Ingresa un número entre 1 y 100: ");
    numeroUsuario = int.Parse(Console.ReadLine());
    intentos++;

    if (numeroUsuario == secreto)
    {
        Console.WriteLine($"¡Correcto! Adivinaste en {intentos} intento(s).");
        acertado = true;
    }
    else if (numeroUsuario < secreto)
    {
        Console.WriteLine("Muy bajo. Intenta de nuevo.");
    }
    else
    {
        Console.WriteLine("Muy alto. Intenta de nuevo.");
    }
}

if (!acertado)
{
    Console.WriteLine($"Perdiste. El número era {secreto}");
}
*/

// Mini Reto 2: Tabla de multiplicar personalizada
/*
Console.WriteLine("Ingrese un numero de 1 al 10");
int numero = int.Parse(Console.ReadLine());

Console.WriteLine($"\ntabla del {numero}");

for (int i = 1; i <=12; i++)
{
    Console.WriteLine($"{numero}x{i} = {numero*i}");
}
*/

// Mini Reto 3: Contador de números positivos, negativos y ceros
/*
int positivo = 0;
int negativo = 0;
int ceros = 0;
for (int i = 1; i<=10 ; i++)
{

    Console.WriteLine("Ingrese 10 numeros");
    int numeros = int.Parse(Console.ReadLine());
    if (numeros>0)
    {
        positivo++;
    }
    else if (numeros<0)
    {
        negativo++;
    }
    else
    {
        ceros++;
    }
}
Console.WriteLine("*****RESULTADOS*****");
Console.WriteLine($"Positivos: {positivo}");
Console.WriteLine($"Negativos: {negativo}");
Console.WriteLine($"Ceros: {ceros}");
*/

// Mini Reto Final de Bucles: Menú interactivo
/*
int opciones = 0;
while (opciones != 3)
{
    Console.WriteLine("*****MENÚ DE OPCIONES*****");
Console.WriteLine("1.- Saludar");
Console.WriteLine("2.- Mostrar hora actual");
Console.WriteLine("3.- Salir");
Console.Write("Ingresa a una de las opciones:");

 opciones = int.Parse(Console.ReadLine());

    switch (opciones)
    {

        case 1:
            Console.WriteLine("¡Hola, usuario!");
            break;
        case 2:
            Console.WriteLine($"Hora actual: {DateTime.Now}");
            break;
        case 3:
            Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }
    Console.WriteLine();
}
*/

// Mini Reto Integrador: Registro de Temperaturas
/*
int diasCalurosos = 0;
int diasFrios = 0;
double sumaTemperatura = 0;
double temperatura;

for (int i = 1; i <= 7; i++)
{
    Console.Write($"Ingrese la temperatura del dia {i}:");
    temperatura = double.Parse( Console.ReadLine() );
   
    sumaTemperatura += temperatura;  

    if (temperatura > 30)
    {
        diasCalurosos++;
    }
    else if ( temperatura<15)
    {
        diasFrios++;
    }

}
double promedio = sumaTemperatura / 7.0;
Console.WriteLine($"Promedio de Temperaturas: {promedio:F2}°C");
Console.WriteLine($"Dias por encima de 30°C: {diasCalurosos}°C");
Console.WriteLine($"Dias de debajo de 15°C: {diasFrios}°C");
*/

// Mini Reto Extra: Registro de gastos semanales
/*
double gastoTotal = 0;
double gasto;
for (int i = 1; i <= 7; i++)
{
    Console.Write($"Ingrese el gasto del día {i}: ");
    gasto = double.Parse( Console.ReadLine() );

    gastoTotal += gasto;
}
double promedio = gastoTotal / 7;

Console.WriteLine($"\nEl promedio diario de gastos es :{promedio:C}");
Console.WriteLine($"Total gastado en la semana es : {gastoTotal:C}");
*/

// Mini Reto Final: Encuesta de edades y clasificación
/*
int menores = 0;
int mayores = 0;
int mayores60 = 0;
int sumaEdades = 0;
int edad;

for (int i = 1; i <= 10; i++)
{
    Console.Write($"Ingresa la edad de la persona {i}: ");
    edad = int.Parse(Console.ReadLine());

    if (edad < 0)
    {
        Console.WriteLine("¡Edad inválida! Intenta otra vez.");
        i--;
        continue;
    }

    sumaEdades += edad;

    if (edad > 60)
    {
        mayores60++;
        mayores++; 
    }
    else if (edad >= 18)
    {
        mayores++;
    }
    else
    {
        menores++;
    }
}

double promedio = (double)sumaEdades / 10;

Console.WriteLine($"\nLa suma de edades es: {sumaEdades} años");
Console.WriteLine($"Menores de 18 años: {menores}");
Console.WriteLine($"Mayores de 18 años: {mayores}");
Console.WriteLine($"Mayores de 60 años: {mayores60}");
Console.WriteLine($"\nEl promedio de edades es: {promedio:F2} años");
*/
#endregion

#region ARRAYS
/*
string[] nombres = { "Juan", "María", "Pedro","Lucía" };

foreach (string nombre in nombres)
{
    Console.WriteLine($"Nombre: {nombre}");
}
*/

/*
Console.WriteLine("*********ELEMENTOS DEL ARRAY**********");
int[] numeros = { 4, 7, 2, 9, 5, 1 };

for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine($"Número:{numeros[i]}");
}

int suma = 0;
foreach (int numero in numeros)
{
    suma += numero;
}
Console.WriteLine($"La suma total es: {suma}");
Console.ReadKey();
*/

/*
int suma = 0;
int[] numeros = { 15, 17, 20, 14, 13, 18 };
for (int i = 0; i < numeros.Length;i++)
{
    suma += numeros[i];
}
double promedio = (double)suma/numeros.Length;
Console.WriteLine($"El promedio es: {promedio:F4}");
*/

/*
int [] numeros = { 3, 6, 2, 9, 10, 7, 4, 1, 8, 5 };

int contadorPares = 0;
for (int i = 0; i < numeros.Length; i++)
{
    if (numeros[i] %2==0)
    { 
    contadorPares++;
    }
}
Console.WriteLine($"Cantidad de números pares: {contadorPares}");
Console.ReadKey();
*/

/*
Console.WriteLine("**********Contar cuántos números son mayores o iguales a 10**********");
int[] numeros = { 5, 12, 8, 17, 3, 10, 22, 1, 14, 6 };

int contadorMayores10 = 0;
for (int i = 0; i < numeros.Length; i++)
{
    if (numeros[i] >= 10)
    {
        contadorMayores10++;
    }
}
Console.WriteLine($"Cantidad de números mayores o igual a 10:{contadorMayores10}");
*/
#endregion
/*
int contadosEstudiantesProcesados = 0;
string continuar = "si";
while (continuar == "si")
{
    string nombre = "";
    int numMaterias = 0;
    double sumaTotalCalificaciones = 0;
    double promedio = 0;
    bool aprobado = false;

    Console.Write("Ingrese el nombre del estudiante: ");
    nombre = Console.ReadLine();



    bool numero = false;
    while (!numero)
    {
        Console.Write("Ingrese el número de materias que cursó (entre 1 y 10): ");

        string ingreseNumMaterias = Console.ReadLine();
        bool validarNumero = int.TryParse(ingreseNumMaterias, out numMaterias);
        if (validarNumero && numMaterias >= 1 && numMaterias <= 10)
        {
            numero = true;
        }
        else
        {
            Console.WriteLine("Numero de materia inválida. Vuelva intentarlo.");
        }
    }

    Console.WriteLine("Ingrese las calificaciones de cada materia (valores entre 0.0 y 10.0)");

    for (int i = 1; i <= numMaterias; i++)
    {
        Console.Write($"Materia {i}: ");


        bool calificacion = false;
        while (!calificacion)
        {

            double nota = 0;
            string ingreseCalificacion = Console.ReadLine();


            if (double.TryParse(ingreseCalificacion, out nota) && nota >= 0.0 && nota <= 10.0)
            {
                calificacion = true;
                sumaTotalCalificaciones += nota;
            }
            else
            {
                Console.WriteLine("Número de calificación es incorrecta. Vuelva intentarlo.");
            }

        }
    }
    promedio = sumaTotalCalificaciones / numMaterias;

    aprobado = promedio >= 6.0;
    string resultado = aprobado ? "Aprobó" :"Desaprobó";

    if (promedio >= 9.0)
    {
        Console.WriteLine("Rendimiento: Excelente");
    }
    else if (promedio >= 8.0)
    {
        Console.WriteLine("Rendimiento: Muy Bueno");
    }
    else if (promedio >= 7.0)
    {
        Console.WriteLine("Rendimiento: Bueno");
    }
    else if (promedio >= 6.0)
    {
        Console.WriteLine("Rendimiento: Suficiente");
    }
    else
    { 
    Console.WriteLine("Rendimiento: insuficiente");
    }

    contadosEstudiantesProcesados++;
    Console.WriteLine("**********RESULTADOS DEL PROCESO**********");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Numero de Materias que cursó: {numMaterias}");
    Console.WriteLine($"Suma de Calificaciones: {sumaTotalCalificaciones}");
    Console.WriteLine($"Promedio: {promedio:F2}");
    Console.WriteLine($"Rsultado: {resultado}");

    Console.WriteLine($"Estudiantes que usaron el Sistema: {contadosEstudiantesProcesados}");

    Console.WriteLine($"¿Desea calcular otro estudiante? (si/no)");
    continuar = Console.ReadLine();
}
*/

#region MÓDULO 8: PROGRAMACIÓN ORIENTADA A OBJETOS - FUNDAMENTOS
/*
class Libro
{
    public string Titulo { get; set; }
    private int añoPublicacion;
    private double precio;
    public int AñoPublicacion
    {
        get { return añoPublicacion; }
        set
        {
            if (value >= 1900)
                añoPublicacion = value;
            else
                Console.WriteLine("Año de publicación inválido. Debe ser mayor a 1900.");
        }
    }
    public double Precio
    {
        get { return precio; }
        set
        {
            if (value >= 1)
            {
                precio = value;
            }
            else
            {
                Console.WriteLine("Precio inválido. Debe ser mayor o igual a 1.");
            }
        }
    }

    public Libro() : this("Sin título", 2000, 10) { }

    public Libro(string titulo, int año, double precio)
    {
        Titulo = titulo;
        AñoPublicacion = año;
        Precio = precio;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Año: {AñoPublicacion}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Libro libro = new Libro("Cien años de Soledad", 1967, 25.50);// INSTANCIA CON VALORES PERSONALIZADO
        libro.MostrarInfo();

        Libro libro1 = new Libro();//INSTANCIA CON CONSTRUCTOR POR DEFECTO
        libro1.MostrarInfo();

        libro1.AñoPublicacion = 1899;
        libro1.Precio = 0;

    }
}
*/
/*
class Alumno
{
    public string Nombre { get; set; }
    public string Curso { get; set; }
    private int edad;

    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 5)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("Ingrese una edad correcta.");
            }
        }
    }

    private double notaFinal;
    public double NotaFinal
    {
        get { return notaFinal; }
        set
        {

            if (value >= 0 && value <= 20)
            {
                notaFinal = value;
            }
            else
            {
                Console.WriteLine("Ingrese una nota correcta.");
            }
        }
    }

    public Alumno() : this("Sin nombre", "Sin curso", 10, 18.5) { }
    public Alumno(string nombre, string curso, int edad, double notaFinal)
    {
        Nombre = nombre;
        Curso = curso;
        Edad = edad;
        NotaFinal = notaFinal;
    }
    public string Estado()
    {
        if (notaFinal >= 11)
        {
            return "Aprobado";
        }
        else
        {
            return "Desaprobado";
        }

    }
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {(Edad>0? Edad +" Años":"No establecida")}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Nota: {NotaFinal}");
        Console.WriteLine($"Estado: {Estado()} ");
        Console.WriteLine(new string('-', 35));
    }
}

class Program
{
    static void Main()
    {
        Alumno alumno = new Alumno("Carlos", "Aritmetica", 5, 11);
        alumno.MostrarInfo();

        Alumno al = new Alumno("Alex", "Algebra", 3, 10);
        al.MostrarInfo();

        Alumno alumno1 = new Alumno();
        alumno1.MostrarInfo();

        alumno1.Edad = 3;
        alumno1.NotaFinal = 21;
    }
}
*/
/*
class Categoria
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public Categoria() : this("Sin nombre", "Sin descripción") { }
    public Categoria(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }
    public void MostrarCategoria()
    {
        Console.WriteLine($"Categoría: {Nombre}| {Descripcion}");
    }
}

class Producto
{
    public string NombreProducto { get; set; }
    public Categoria Categoria { get; set; }
    private double precio;
    public double Precio
    {
        get { return precio; }
        set
        {
            if (value >= 1.00)
            {
                precio = value;
            }
            else
            {
                Console.WriteLine("ERROR: El precio tiene que ser mayor a 0");
            }
        }
    }

    private int stock;
    public int Stock
    {
        get { return stock; }
        set
        {
            if (value >= 0)
            {
                stock = value;
            }
            else
            {
                Console.WriteLine("ERROR: El stock es mayor o igual que 0.");
            }
        }

    }
    public Producto() : this("Sin nombre de producto", new Categoria(), 0, 0) { }
    public Producto(string nombreProducto, Categoria categoria, double precio, int stock)
    {
        NombreProducto = nombreProducto;
        Categoria = categoria;
        Precio = precio;
        Stock = stock;
    }
    public void MostrarInfo()
    {
        Console.WriteLine($"Producto: {NombreProducto}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine($"Stock: {Stock} unidades");
        Categoria.MostrarCategoria();
        Console.WriteLine(new string('-',50));

    }

}

class Program
{
    static void Main()
    {
        //crear categoria
        Categoria categoria = new Categoria("Higiene", "Produtos de limpieza del hogar");

        //crear producto con categoria
        Producto producto = new Producto("Jabon liquido",categoria,7.50, 20);
        producto.MostrarInfo();

        Producto produc = new Producto("Detergente", categoria,0,-1);
        produc.MostrarInfo();
    }
}
*/
/*
class Mascota
{
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public bool Vacunado { get; set; }
    private int edad;
    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 0)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("ERROR: Edad incorrecta.");
            }
        }
    }

    public Mascota() : this("Sin nombre", "Sin especie", false, 0) { }

    public Mascota(string nombre, string especie, bool vacunado, int edad)
    {
        Nombre = nombre;
        Especie = especie;
        Vacunado = vacunado;
        Edad = edad;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Especie: {Especie}");
        Console.WriteLine($"Vacunado: {(Vacunado? "Si":"No")}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine(new string('-',50));
    }




}
class Program
{
    static void Main()
    {
        Mascota mascota = new Mascota("Ruso","Perro",true,3);
        mascota.MostrarInfo();

        Mascota masc = new Mascota();
        masc.MostrarInfo();

        masc.Edad = -5;
    }
}
*/
/*
class Autor
{
    public string Nombre { get; set; }
    public string Nacionalidad { get; set; }

    public Autor() : this("Desconocido", "Desconocida") { }
    public Autor(string nombre, string nacionalidad)
    {
        this.Nombre = nombre;
        this.Nacionalidad = nacionalidad;
    }
    public void MostrarAutor()
    {
        Console.WriteLine($"Autor: {Nombre}");
        Console.WriteLine($"Nacionalidad: {Nacionalidad}");
    }
}

class Libro
{
    public string Titulo { get; set; }
    private int añoPublicacion;
    public int AñoPublicacion
    {
        get { return añoPublicacion; }
        set
        {
            if (value >= 1900)
            {
                añoPublicacion = value;
            }
            else
            {
                Console.WriteLine("ERROR: Año de publicación incorrecta.");
            }
        }
    }
    public Autor AutorDelLibro { get; set; }

    public Libro() : this("Sin titulo", 2000, new Autor()) { }
    public Libro(string titulo, int añoPublicacion, Autor autor)
    {
        Titulo = titulo;
        AñoPublicacion = añoPublicacion;
        AutorDelLibro = autor;

    }

    public void MostrarLibro()
    {
        Console.WriteLine($"Titulo: {Titulo}");
        Console.WriteLine($"Publicado en: {AñoPublicacion}");
        AutorDelLibro.MostrarAutor();
        Console.WriteLine(new string('-',40));
    }
}

class Program
{
    static void Main()
    {
        Autor autor = new Autor("Gabriel garcia marquez","Colombiano");
        Libro libro = new Libro("Cien años de soledad", 1967,autor);
        libro.MostrarLibro();

        Libro libro1 = new Libro();
        libro1.MostrarLibro();

        libro.AñoPublicacion = 1800;
    }
}
*/
/*
class Equipo
{
    public String Nombre { get; set; }
    public string Ciudad { get; set; }

    public Equipo() : this("sin nombre", "Sin ciudad") { }
    public Equipo(string nombre, string ciudad)
    {
        Nombre = nombre;
        Ciudad = ciudad;
    }

    public void MostrarInfoEquipo()
    {
        Console.WriteLine($"Equipo: {Nombre}");
        Console.WriteLine($"Ciudad: {Ciudad}");
    }
}

class Jugador
{
    public string Nombrejugador { get; set; }
    private int edad;
    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 16)
            {
                edad = value;
            }
            else
                Console.WriteLine("Es menor de edad.");
        }
    }
    public string Posicion { get; set; }
    public Equipo EquipoAsignado { get; set; }

    public Jugador() : this("Sin nombre del jugador", 15, "Delantero", new Equipo()) { }
    public Jugador(string nombreJugador, int edad, string posicion, Equipo equipo)
    {
        Nombrejugador = nombreJugador;
        Edad = edad;
        Posicion = posicion;
        EquipoAsignado = equipo;
    }
    public void MostrarInfoJugador()
    {
        Console.WriteLine($"Nombre del jugador: {Nombrejugador}");
        Console.WriteLine($"Edad: {(Edad>=16? "Mayor de edad": "Menor de edad")}");
        Console.WriteLine($"Posición: {Posicion}");
        EquipoAsignado.MostrarInfoEquipo();
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        Equipo equipo = new Equipo("Alianza Lima","Lima");
        Jugador jugador = new Jugador("Guerrero",32,"Delantero",equipo);
        jugador.MostrarInfoJugador();

        Jugador juga = new Jugador();
        juga.MostrarInfoJugador();

        juga.Edad = 10;
    }
}
*/
#endregion
#region MODULO 9: PROGRAMACIÓN ORIENTADO A OBJETOS - HERENCIA

/*
class Producto
{
    protected string nombre;
    protected double precio;

    public Producto(string nombre, double precio)
    {
        this.nombre = nombre;
        this.precio = precio;
    }

    protected void MostrarDatosBasicos()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Precio: {precio:C2}");
    }

    public virtual void MostrarInformacion()
    {
        MostrarDatosBasicos();
    }
}
class ProductoImportado : Producto
{
    private string paisOrigen;
    public ProductoImportado(string nombre, double precio, string paisOrigen)
        : base(nombre, precio)
    {
        this.paisOrigen = paisOrigen;
    }

    public override void MostrarInformacion()
    {
        MostrarDatosBasicos();
        Console.WriteLine($"Pais original: {paisOrigen}");
    }
}
class Program
{
    static void Main()
    {
        Producto producto = new Producto("Refrigeradora", 2500);
        producto.MostrarInformacion();

        Console.WriteLine(new string('-', 40));

        ProductoImportado productoImportado = new ProductoImportado("cuaderno", 4.50, "Perú");
        productoImportado.MostrarInformacion();
    }
}
*/
/*
class Animal
{
    protected string nombre;
    protected int edad;

    public Animal(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    protected void MostrarDatosBasicos()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Edad: {edad} años");
    }
    public virtual void HacerSonido()
    {
        MostrarDatosBasicos();
        Console.WriteLine("Este animal hace un sonido genérico");
    }
}

class Perro : Animal
{
    private string raza;
    public Perro(string nombre, int edad, string raza)
        : base(nombre, edad)
    {
        this.raza = raza;
    }

    public override void HacerSonido()
    {
        Console.WriteLine("Guau guau!");
    }
    public void MostrarInformacionCompleta()
    {
        MostrarDatosBasicos();
        Console.WriteLine($"Raza: {raza}");
        HacerSonido();
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Animal("Gato", 10);
        animal.HacerSonido();

        Console.WriteLine(new string('-', 40));

        Perro perro = new Perro("Rambo", 10, "Pitbul");
        perro.MostrarInformacionCompleta();
    }
}
*/
/*
class Empleado
{
    protected string nombre;
    protected double salario;
    public Empleado(string nombre, double salario)
    {
        this.nombre = nombre;
        this.salario = salario;
    }
    protected void MostrarDatosBasicos()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Salario: {salario:C2}");
    }

    public virtual void MostrarInformacion()
    {
        MostrarDatosBasicos();
        Console.WriteLine($"Bonificación: {CalcularBonificacion():C2}");
    }
    public virtual double CalcularBonificacion()
    {
        return 0.05 * salario;
    }
   
}
class Gerente : Empleado
{
    private string departamento;
    public Gerente(string nombre, double salario, string departamento)
        : base(nombre, salario)
    {
        this.departamento = departamento;
    }
    public override double CalcularBonificacion()
    {
       
        return  0.15 * salario;
    }
    
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Departamento: {departamento}");
    }
}
class Program
{
    static void Main()
    {
        Empleado empleado = new Empleado("Alex",2500);
        empleado.MostrarInformacion();

        Console.WriteLine(new string('-',40));

        Gerente gerente = new Gerente("Janz",5000,"Senior");
        gerente.MostrarInformacion();
    }
}
*/

/*
class Persona
{
    protected string nombre;
    protected int edad;
    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }
    protected void MostrarDatosBasicos()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Edad: {edad}");
    }
    public virtual void MostrarInformacion()
    {
        MostrarDatosBasicos();
    }
}
class Estudiante : Persona
{
    private string carrera;

    public Estudiante(string nombre, int edad, string carrera)
        : base(nombre, edad)
    {
        this.carrera = carrera;
    }
    public override void MostrarInformacion()
    {
        Console.WriteLine("---ESTUDIANTE---");
        base.MostrarInformacion();
        Console.WriteLine($"Carrera: {carrera}");
    }
}
class Profesor : Persona
{
    private string especialidad;
    public Profesor(string nombre, int edad, string especialidad)
    : base(nombre, edad)
    {
        this.especialidad = especialidad;
    }
    public override void MostrarInformacion()
    {
        Console.WriteLine("---PROFESOR---");
        base.MostrarInformacion();
        Console.WriteLine($"Especialidad: {especialidad}");
    }
}

class Program
{
    static void Main()
    {
        Estudiante estudiante = new Estudiante("janz", 32, "ing.software");
        estudiante.MostrarInformacion();

        Console.WriteLine(new string('-', 30));

        Profesor profesor = new Profesor("Rome", 31, "Abogado");
        profesor.MostrarInformacion();
    }
}
*/

/*
class Vehiculo
{
    protected string marca;
    protected string modelo;
    protected string año;
    public Vehiculo(string marca, string modelo, string año)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.año = año;
    }
    protected void MostrarDatosBasicos()
    {
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Modelo: {modelo}");
        Console.WriteLine($"Año: {año}");
    }
    public virtual void MostrarInformacion()
    {
        MostrarDatosBasicos();
    }
}
class Auto : Vehiculo
{
    private string tipoCombustible;
    public Auto(string marca, string modelo, string año, string tipoCombustible) : base(marca, modelo, año)
    {
        this.tipoCombustible = tipoCombustible;
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Tipo de combustible: {tipoCombustible}");
    }
}

sealed class Moto : Vehiculo
{
    private string cilindraje;
    public Moto(string marca, string modelo, string año, string cilindraje) : base(marca, modelo, año)
    {
        this.cilindraje = cilindraje;
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Cilindraje: {cilindraje}");
    }
}
class Program
{
    static void Main()
    {
        Auto auto = new Auto("honda", "Lg", "2025", "gasolina");
        auto.MostrarInformacion();

        Console.WriteLine(new string('-', 30));

        Moto moto = new Moto("xiaomi", "samsung", "1994", "165");
        moto.MostrarInformacion();

    }
}
*/
/*
class Vehiculo
{
    protected string marca;
    protected string modelo;
    protected int año;

    public Vehiculo(string marca, string modelo, int año)
    {
        marca = marca?.Trim();
        this.marca = !string.IsNullOrWhiteSpace(marca) ? marca : "Desconocido";

        modelo = modelo?.Trim();
        this.modelo = !string.IsNullOrWhiteSpace(modelo) ? modelo : "Desconocido";

        if (año >= 1900 && año <= DateTime.Now.Year)
            this.año = año;
        else
        {
            Console.WriteLine("⚠ Año inválido, se establecerá en 0");
            this.año = 0;
        }

    }
    protected void MostrarDatosProtegidos()
    {
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Modelo: {modelo}");
        Console.WriteLine($"Año: {año}");
    }
    public virtual void MostrarInformacion()
    {
        MostrarDatosProtegidos();
    }
}

class Auto : Vehiculo
{
    private string tipoCombustible;
    public Auto(string marca, string modelo, int año, string tipoCombustible) : base(marca, modelo, año)
    {
        tipoCombustible = tipoCombustible?.Trim();
        this.tipoCombustible = (!string.IsNullOrWhiteSpace(tipoCombustible)) ? tipoCombustible: "No especificado";
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Tipo de combustible: {tipoCombustible}");
    }
}
sealed class Moto : Vehiculo
{
    private string cilindraje;
    public Moto(string marca, string modelo, int año, string cilindraje) : base(marca, modelo, año)
    {
        cilindraje = cilindraje?.Trim();
        this.cilindraje = (!string.IsNullOrWhiteSpace(cilindraje)) ? cilindraje : "No especificado";
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Cilindraje: {cilindraje}");
    }
}
class Program
{
    static void Main()
    {
        Auto auto = new Auto("Honda", "yari", 1900, "gasolina");
        auto.MostrarInformacion();

        Console.WriteLine();

        Auto aut = new Auto("", "", 1800, "");
        aut.MostrarInformacion();

        Console.WriteLine(new string('-', 30));

        Moto moto = new Moto("Xiaomi", "LG", 2025, " Gas ");
        moto.MostrarInformacion();

        Console.WriteLine();

        Moto mot = new Moto("", " ", 2026, "  ");
        mot.MostrarInformacion();
    }
}
*/
using System.Text.RegularExpressions;
using System.Xml.Schema;
/*
class Estudiante
{
    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                nombre = value;
            }
            else
            {
                Console.WriteLine("❌ El nombre no puede estar vacío.");
            }
        }
    }

    private int edad;
    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 16)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("❌ La edad debe ser mayor o igual a 16.");
            }
        }
    }
    private string correo;
    public string Correo
    {
        get { return correo; }
        set
        {
            Regex regexCorreo = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (regexCorreo.IsMatch(value))
            {
                correo = value;
            }
            else
            {
                Console.WriteLine("❌ Correo inválido.");
            }
        }
    }
    private double notaFinal;
    public double NotaFinal
    {
        get { return notaFinal; }
        set
        {
            if (value >= 0 && value <= 20)
            {
                notaFinal = value;
            }
            else
            {
                Console.WriteLine("Nota inválida.");
            }
        }
    }
    public Estudiante(string nombre, int edad, string correo, double notaFinal)
    {
        Nombre = nombre;
        Edad = edad;
        Correo = correo;
        NotaFinal = notaFinal;

    }
    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre} | Edad: {Edad} | Correo: {Correo} | Nota Final: {NotaFinal}");
    }
}
class EstudianteRegular : Estudiante
{
    public EstudianteRegular(string nombre, int edad, string correo, double notaFinal) : base(nombre, edad, correo, notaFinal) { }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine("Tipo de estudiante: Regular");
    }
}
class EstudianteBecado : Estudiante
{
    public EstudianteBecado(string nombre, int edad, string correo, double notaFinal) : base(nombre, edad, correo, notaFinal) { }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine("Tipo de estudiante: Becado");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Control de Estudiantes ===");
        Console.WriteLine(new string('-', 40));

        Estudiante[] estudiantes = new Estudiante[10];
        int contador = 0;

        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();


            Console.Write("Ingrese una opcion: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("***** Registro de Estudiantes *****");



                    while (contador < estudiantes.Length)
                    {

                        Console.Write("Ingrese su nombre: ");
                        string nombre = Console.ReadLine();

                        int edad;
                        while (true)
                        {
                            Console.Write("Ingrese su edad: ");
                            if (int.TryParse(Console.ReadLine(), out edad) && edad >= 16)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Edad inválida, debe ser un numero mayor o igual a 16.");
                            }
                        }

                        string correo;
                        while (true)
                        {

                            Console.Write("Ingrese su correo: ");
                            correo = Console.ReadLine();

                            if (ExisteCorreo(estudiantes, contador, correo))
                            {
                                Console.WriteLine("❌ Este correo ya está registrado, use otro.");
                            }
                            else
                            {
                                break;
                            }

                        }

                        double notaFinal;
                        while (true)
                        {

                            Console.Write("Ingrese la nota final: ");
                            if (double.TryParse(Console.ReadLine(), out notaFinal) && notaFinal >= 0 && notaFinal <= 20)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("❌ Nota inválida.");
                            }
                        }

                        Estudiante nuevo;
                        Console.Write("¿El estudiante es becado?(si/no): ");
                        if (Console.ReadLine().ToLower() == "si")
                        {
                            nuevo = new EstudianteBecado(nombre, edad, correo, notaFinal);
                        }
                        else
                        {
                            nuevo = new EstudianteRegular(nombre, edad, correo, notaFinal);
                        }
                        estudiantes[contador] = nuevo;
                        contador++;

                        Console.Write("¿Desea registrar a otro estudiante?(si/no): ");
                        if (Console.ReadLine().ToLower() != "si")
                        {
                            break;
                        }



                    }
                    break;
                case "2":
                    Console.WriteLine("\n=== Mostrar Estudiantes ===");
                    for (int i = 0; i < contador; i++)
                    {
                        estudiantes[i].MostrarInfo();
                        Console.WriteLine(new string('-', 40));
                    }
                    break;
                case "3":
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
        Console.WriteLine("1.- Registrar Estudiante");
        Console.WriteLine("2.- Mostrar estudiantes");
        Console.WriteLine("3.- Salir del programa");
        Console.WriteLine(new string('-', 40));

    }

    static bool ExisteCorreo(Estudiante[] estudiantes, int cantidad, string correoBuscado)
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (estudiantes[i] !=null && estudiantes[i].Correo == correoBuscado)
            {
                return true;
            }
        }
        return false;
    }

}
*/
/*
class Vehículo
{
    private string placa;
    public string Placa
    {
        get { return placa; }
        set
        {
            Regex regexPlaca = new Regex(@"^[A-Z]{3}-[0-9]{3}$");
            if (regexPlaca.IsMatch(value))
            {
                placa = value;
            }
            else
            {
                Console.WriteLine("Placa incorrecta.");
            }
        }
    }

    private string marca;
    public string Marca
    {
        get { return marca; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                marca = value;
            }
            else
            {
                Console.WriteLine("Hay espacios vacías.");
            }
        }
    }

    private string modelo;
    public string Modelo
    {
        get { return modelo; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                modelo = value;
            }
            else
            {
                Console.WriteLine("Hay espacios vacías.");
            }
        }
    }

    private int añoFabricacion;
    public int AñoFabricacion
    {
        get { return añoFabricacion; }
        set
        {
            if (value >= 1980 && value <= DateTime.Now.Year)
            {
                añoFabricacion = value;
            }
            else
            {
                Console.WriteLine("Año de fabricación incorrecta.");
            }
        }
    }

    public Vehículo(string placa, string marca, string modelo, int añoFabricacion)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        AñoFabricacion = añoFabricacion;
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Placa: {Placa} | Marca: {Marca} | Modelo: {Modelo} | Año Fabricado:{AñoFabricacion}");
    }
}

class VehículoParticular : Vehículo
{
    public VehículoParticular(string placa, string marca, string modelo, int añoFabricacion) : base(placa, marca, modelo, añoFabricacion) { }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine("Tipo de vehículo: Particular");
    }
}

class VehículoComercial : Vehículo
{
    public VehículoComercial(string placa, string marca, string modelo, int añoFabricacion) : base(placa, marca, modelo, añoFabricacion) { }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine("Tipo de vehículo: Comercial");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n=== Sistema de Registro de Vehículos ===");
        Console.WriteLine(new string('-', 50));

        Vehículo[] vehículos = new Vehículo[10];
        int contador = 0;

        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    while (contador < vehículos.Length)
                    {
                        string placa;
                        do
                        {
                            Console.Write("Ingrese la placa (formato ABC-123): ");
                            placa = Console.ReadLine().ToUpper();

                            if (!Regex.IsMatch(placa, @"^[A-Z]{3}-[0-9]{3}$"))
                            {
                                Console.WriteLine("❌ Formato incorrecto. Debe ser ABC-123.");
                            }
                            else if (ExistePlaca(vehículos, contador, placa))
                            {
                                Console.WriteLine("❌ Esa placa ya está registrada.");
                            }
                        }
                        while (!Regex.IsMatch(placa, @"^[A-Z]{3}-[0-9]{3}$") || ExistePlaca(vehículos, contador, placa));

                        string marca;
                        do
                        {
                            Console.Write("Ingresa la marca: ");
                            marca = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(marca));

                        string modelo;
                        do
                        {
                            Console.Write("Ingresa el modelo: ");
                            modelo = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(modelo));

                        int año;
                        while (true)
                        {
                            Console.Write("Ingrese el año: ");
                            if (int.TryParse(Console.ReadLine(), out año) && año >= 1980 && año <= DateTime.Now.Year)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Año incorrecto.");
                            }
                        }

                        Vehículo nuevo;
                        Console.Write("¿El vehículo es particular?: (si/no)");
                        if (Console.ReadLine().ToLower() == "si")
                        {
                            nuevo = new VehículoParticular(placa, marca, modelo, año);
                        }
                        else
                        {

                            nuevo = new VehículoComercial(placa, marca, modelo, año);
                        }
                        vehículos[contador] = nuevo;
                        contador++;

                        Console.WriteLine("¿Desea registrar otro vehículo?: (si/no)");
                        if (Console.ReadLine().ToLower() != "si")
                        {
                            break;
                        }

                    }
                    break;
                case "2":
                    Console.WriteLine("\n=== Mostrar Informacion ===");
                    for (int i = 0; i < contador; i++)
                    {
                        vehículos[i].MostrarInfo();
                        Console.WriteLine(new string('-', 40));
                    }

                    break;
                case "3":
                    continuar = false;
                    break;


            }
        }


    }

    static void MostrarMenu()
    {
        Console.WriteLine("1.- Registrar Vehículo");
        Console.WriteLine("2.- Mostrar vehículo");
        Console.WriteLine("3.- Salir");
        Console.WriteLine(new string('-', 40));
    }
    static bool ExistePlaca(Vehículo[] vehículos, int cantidad, string placaBuscada)
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (vehículos[i] != null && vehículos[i].Placa == placaBuscada)
            {
                return true;
            }
        }
        return false;
    }

}
*/
/*
class Persona
{
    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                nombre = value;
            }
            else
            {
                Console.WriteLine($"Coloque su nombre correctamente.");
            }
        }
    }
    private int edad;
    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 0)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("La edad tiene que ser mayor que cero.");
            }
        }
    }
    public Persona(string nombre, int edad)
    {
        this.Nombre = nombre;
        this.Edad = edad;
    }
    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre} | Edad: {Edad}");
    }

}
class Empleado : Persona
{
    public double Sueldo { get; set; }
    public Empleado(string nombre, int edad, double sueldo) : base(nombre, edad)
    {
        this.Sueldo = sueldo;
    }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Sueldo: {Sueldo}");
    }
}
class Gerente : Empleado
{
    public string Departamento { get; set; }
    public Gerente(string nombre, int edad, double sueldo, string departamento) : base(nombre, edad, sueldo)
    {
        this.Departamento = departamento;
    }
    public override void MostrarInfo()
    {
        base.MostrarInfo();
        Console.WriteLine($"Departamento: {Departamento}");
    }
}

class Program
{
    static void Main()
    {
        Persona persona = new Persona("carlos", 32);

        Empleado empleado = new Empleado("Rene", 28, 2500.00);

        Gerente gerente = new Gerente("Janz", 32, 5000.00, "Ingeniero");

        Persona[] personas = new Persona[] { persona, empleado, gerente };
        foreach (Persona p in personas)
        {
            p.MostrarInfo();
        }


    }

}
*/
/*
// 1. Crear array con 5 nombres de empleados
string[] empleados = { "Luis", "María", "Carlos", "Ana", "Janz" };

// 2. Recorrer con foreach y mostrar en mayúsculas
Console.WriteLine("Empleados en mayúsculas:");
foreach (string nombre in empleados)
{
    Console.WriteLine(nombre.ToUpper());
}

Console.WriteLine();

// 3. Recorrer con for y mostrar índice + nombre
Console.WriteLine("Empleados con índice:");
for (int i = 0; i < empleados.Length; i++)
{
    Console.WriteLine($"Índice {i}: {empleados[i]}");
}
*/
/*
string[] empleados = { "ana", "luis", "carlos", "maria", "juan" };

foreach (string nombre in empleados)
{
    Console.WriteLine($"Nombres: {nombre.ToUpper()}");
}
Console.WriteLine();
for (int i = 1; i < empleados.Length; i++)
{
    Console.WriteLine($"Nombre {i}: {empleados[i]}");
}
*/


#endregion

#region MODULO 11 : INTERFACES
/*
interface IVehiculo
{
    void MostrarInfo();
}
class Auto : IVehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public Auto(string marca, string modelo)
    {
        this.Marca = marca;
        this.Modelo = modelo;
    }
    public void MostrarInfo()
    {
        Console.WriteLine($"Auto - Marca: {Marca}, Modelo: {Modelo}");
    }
}
class Moto : IVehiculo
{
    public string Marca { get; set; }
    public Moto(string marca)
    {
        this.Marca = marca;
    }
    public void MostrarInfo()
    {
        Console.WriteLine($"Moto - Marca: {Marca}");
    }
}
class Program
{
    static void Main()
    {
        Auto auto = new Auto("Toyota", "Corolla");
        Auto auto1 = new Auto("Honda", "Civic");
        Moto moto = new Moto("Yamaha");

        IVehiculo[] vehiculos = new IVehiculo[3];
        vehiculos[0] = auto;
        vehiculos[1] = auto1;
        vehiculos[2] = moto;

        Console.WriteLine("\n === Vehiculos ===");
        for (int i = 0; i < vehiculos.Length; i++)
        {
            vehiculos[i].MostrarInfo();
        }
    }
}
*/

interface IImprimible
{
    void Imprimir();
}

class Factura : IImprimible
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public Factura(int numero, string cliente)
    {
        this.Numero = numero;
        this.Cliente = cliente;
    }
    public void Imprimir()
    {
        Console.WriteLine($"Factura N° {Numero} para el Cliente {Cliente}");
    }
}
class Reporte : IImprimible
{
    public string Titulo { get; set; }
    public Reporte(string titulo)
    {
        this.Titulo = titulo;
    }
    public void Imprimir()
    {
        Console.WriteLine($"Reporte: {Titulo}");
    }
}
class Foto : IImprimible
{
    public string NombreArchivo { get; set; }
    public Foto(string nombreArchivo)
    {
        this.NombreArchivo = nombreArchivo;
    }
    public void Imprimir()
    {
        Console.WriteLine($"Foto: {NombreArchivo}");
    }
}
class Program
{
    static void Main()
    {
        Factura factura = new Factura(1001, "Juan Pérez");
        Reporte reporte = new Reporte("Ventas del Mes");
        Foto foto = new Foto("vacaciones.jpg");
        Factura factura1 = new Factura(1002, "Ana López");

        IImprimible[] imprimibles = new IImprimible[4];
        imprimibles[0] = factura;
        imprimibles[1] = reporte;
        imprimibles[2] = foto;
        imprimibles[3] = factura1;

        for (int i = 0; i < imprimibles.Length; i++)
        {
            imprimibles[i].Imprimir();
        }

    }
}
#endregion  