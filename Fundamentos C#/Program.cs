//declaración de diferentes tipos de variables
int edad = 0;
decimal alturaMetros = 0;
string nombre = "";
bool estudiante = false;

//Solicitar al usuario que ingrese su NOMBRE
Console.WriteLine("Ingresa tu Nombre: ");
nombre = Console.ReadLine();

//Solicitar al usuario que ingrese su ALTURA
Console.WriteLine("Ingresa tu altura: ");
string ingreseAltura = Console.ReadLine();

//Validación usando TRYPARSE a la ALTURA
bool validarAltura = decimal.TryParse(ingreseAltura, out alturaMetros);
if (validarAltura)
{
    Console.WriteLine($"Altura válida.");
}
else
{
    Console.WriteLine("Altura no válida.");
}

//Solicitar al usuario que ingrese su EDAD
Console.WriteLine("Ingresa tu edad: ");
string ingreseEdad = Console.ReadLine();

//Validación usando TRYPARSE a la EDAD
bool validarEdad = int.TryParse(ingreseEdad, out edad);
if (validarEdad)
{
    Console.WriteLine($"Edad válida.");
}
else
{
    Console.WriteLine("Edad no válida.");
}

//Preguntar si es ESTUDIANTE
Console.WriteLine("¿Eres estudiante (si/no)?");
string respuesta = Console.ReadLine();

//CONVERSION  de la la variable respuesta
if (respuesta == "si"||respuesta=="SI")
{
    estudiante = true;
}
else
{
    estudiante = false;
}

//uso de VAR y CONVERSION de EDAD(int) a DOUBLE
var edadDouble = Convert.ToDouble(edad);

//Cálculo de edad en meses
int edadMeses = edad * 12;

//INFORMACIÓN DEL USUARIO
Console.WriteLine($"*****INFORMACIÓN DE {nombre}");
Console.WriteLine($"Mi nombre es: {nombre}");
Console.WriteLine($"Mi altura es: {alturaMetros} metros");
Console.WriteLine($"Mi  edad es: {edad} años");
Console.WriteLine($"Edad convertido en Double: {edadDouble}");
Console.WriteLine($"Edad en meses: {edadMeses} meses");
Console.WriteLine($"¿Eres estudiante?: {estudiante}");

