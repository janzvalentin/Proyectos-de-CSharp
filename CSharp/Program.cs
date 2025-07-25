using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Emit;
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

