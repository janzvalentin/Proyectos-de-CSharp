
//Este es un contador para saber cuantos estudiantes han sido procesado en el Sistema
int numeroDeEstudiantesProcesados = 0;

//Variable para repetir nuevamente el proceso sistema
string deseaContinuar = "si";

Console.WriteLine("==========Sistema de Calificaciones=========");

//Con este bucle se determina si el usuario quiere continuar
while (deseaContinuar == "si")
{
    //Declaracion de variables
    string nombre = "";
    int numMaterias = 0;
    double sumaTotalCalificaciones = 0;
    double promedio = 0;
    bool aprobo = false;

    //Solicitar al usuario que ingrese su nombre
    Console.Write("Ingrese el nombre del estudiante: ");
    nombre = Console.ReadLine();

    //Validacion del numero de materias(1 y 10)
    bool numero = false;
    while (!numero)
    {
        Console.Write("Ingrese el número de materias que cursó (entre 1 y 10): ");
        string ingreseNumero = Console.ReadLine();
        bool validarNumero = int.TryParse(ingreseNumero, out numMaterias);
        if (validarNumero && numMaterias >= 1 && numMaterias <= 10)
        {  
            //El numero ingresado es correto y sale del buble
            numero = true;

        }
        else
        {
            Console.WriteLine("Ingrese un número correcto. Vuelva intentarlo.");
        }
    }

    //Mensaje para que el usuario inrese las notas
    Console.WriteLine($"Ingrese las calificaciones de cada materia (valores entre 0.0 y 10.0):");

    //Este es el ciclo de las notas que tiene cada materia
    for (int i = 1; i <= numMaterias; i++)
    {

        double nota = 0;
        bool calificaciones = false;
        //Se realiza las validaciones de cada nota que ingresa el usuario
        while (!calificaciones)
        {
            Console.Write($"Materia {i}: ");
            string ingreseCalificaciones = Console.ReadLine();

            if (double.TryParse(ingreseCalificaciones, out nota) && nota >= 0.0 && nota <= 10.0)
            {

                calificaciones = true;

                //acumula las notas
                sumaTotalCalificaciones += nota;
            }
            else
            {
                Console.WriteLine("Calificación incorrecta.Vuelva intentarlo.");
            }
        }
    }

    //Se calcula el promedio
    promedio = sumaTotalCalificaciones / numMaterias;

    //Determinamos si el estudiante aprobó
    aprobo = promedio >= 6.0;

    //Usamos el operador ternario
    string resultado = aprobo ? "ESTUDIANTE APROBADO" : "ESTUDIANTE DESAPROBADO"; //Oprador ternario

    
    /*
     //Este es el if-else tradicional
   if (aprobó)
   {
       Console.WriteLine("Aprobado");
   }
   else
   {
       Console.WriteLine("Desaprobado");
   }
   */

    //Muestra los resultados del estudiante
    Console.WriteLine("\n**********RESULTADO DEL ESTUDIANTE**********");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Número de Materias: {numMaterias}");
    Console.WriteLine($"Suma de Calificaciones: {sumaTotalCalificaciones}");
    Console.WriteLine($"Promedio: {promedio} - {resultado}");

    //Clasificación del rendimiento dependiendo del promedio
    if (promedio >= 9.0)
    {
        Console.WriteLine("Excelente");
    }
    else if (promedio >= 8.0)
    {
        Console.WriteLine("Muy Bueno");
    }
    else if (promedio >= 7.0)
    {
        Console.WriteLine("Bueno");
    }
    else if (promedio >= 6.0)
    {
        Console.WriteLine("Suficiente");
    }
    else
    {
        Console.WriteLine("insuficiente");
    }

    //Aumenta el contador del numero de estudiantes Procesador
    numeroDeEstudiantesProcesados++;

    //Muestra cuantos estudiantes son procesados en el sistema
    Console.WriteLine($"Número total de estudiantes procesados en el Sistema: {numeroDeEstudiantesProcesados}");

    //Preguntar al usuario si desea calcular otro estudiante
    Console.Write("¿Desea calcular otro estudiante?(si/no):");
    deseaContinuar = Console.ReadLine();

    Console.WriteLine("¡Gracias por usar el sistema!");
}


