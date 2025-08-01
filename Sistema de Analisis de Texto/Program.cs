using System.Text;
class Program
{
    static string[] textos = new string[20];
    static int[] contadorPalabras = new int[20];
    static int[] contadorCaracteres = new int[20];
    static int totalTextos = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("===Sistema de Análisis de Texto===");
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarTexto();
                        break;
                    case 2:
                        BuscarPalabrasEnTextos();
                        break;
                    case 3:
                        MostrarAnalisisEspecifico();
                        break;
                    case 4:
                        GenerarReporte(textos, contadorPalabras, contadorCaracteres, totalTextos);
                        break;
                    case 5:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }

        }


    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n=== Menú de Opciones ===");
        Console.WriteLine("1.- Agregar texto para análisis.");
        Console.WriteLine("2.- Buscar palabras en textos.");
        Console.WriteLine("3.- Análisis de texto específico.");
        Console.WriteLine("4.- Generar reporte completo.");
        Console.WriteLine("5.- Salir.");
    }

    static void AgregarTexto()
    {
        if (totalTextos >= 20)
        {
            Console.WriteLine("No se puede añadir mas textos.");
            return;
        }

        Console.WriteLine("\nIngrese el texto para analizar:");
        Console.Write("> ");
        string textoOriginal = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(textoOriginal))
        {
            Console.WriteLine("El texto no puede estar vacío.");
            return;
        }

        int palabras, caracteres, vocales;
        ProcesarTexto(textoOriginal, out palabras, out caracteres, out vocales);

        textos[totalTextos] = textoOriginal;
        contadorPalabras[totalTextos] = palabras;
        contadorCaracteres[totalTextos] = caracteres;
        totalTextos++;

        Console.WriteLine("Texto Procesado exitosamente!");
        Console.WriteLine("Estadísticas:");
        Console.WriteLine($"- Palabras: {palabras}");
        Console.WriteLine($"- Caracteres: {caracteres}");
        Console.WriteLine($"- Vocales: {vocales}");
        Console.WriteLine($"- Texto limpio: \"{LimpiarTexto(textoOriginal)}\"");
    }

    //Limpiar un texto: Eliminar signos y convertir el texto a minúsculas
    static string LimpiarTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return "";
        }
        //limpieza basica: el texto pasarlo a minusculas, quitar estamos al inicio y al final
        string textoLimpio = texto.Trim().ToLower();

        //quitar los signos de puntuación mas comunes
        string[] signosPuntuacion = { ",", ".", ":", ";", "!", "¡", "¿", "?", "(", ")", "/", "\"" };
        foreach (string item in signosPuntuacion)
        {
            textoLimpio = textoLimpio.Replace(item, "");
        }

        //Eliminar espacios dobles o mas
        while (textoLimpio.Contains("  "))
        {
            textoLimpio = textoLimpio.Replace("  ", " ");
        }
        //elimina los espacios al inicio y al final
        return textoLimpio.Trim();
    }

    //Procesa un texto para contar palabras, caracteres y vocales
    static void ProcesarTexto(string texto, out int palabras, out int caracteres, out int vocales)
    {
        string resultado = LimpiarTexto(texto); // resultado recibe todo lo que ya hizo el método de limpiarTexto

        //quita los espacios usando replace y luego mide la longitud que da la cantidad de letras, pero sin espacios
        caracteres = resultado.Replace(" ", "").Length;//El valor se guarda en la variable caracteres que se paso como out

        //Si el resultado esta vacío o solo tiene espacios, entonces la palabras =0, sino entonces dividelo por espacios Split(' ') y contar cuantas partes hay 
        palabras = string.IsNullOrWhiteSpace(resultado) ? 0 : resultado.Split(' ').Length;

        /*
        if (string.IsNullOrWhiteSpace(resultado))
        {
            palabras = 0;
        }
        else
        {
            palabras = resultado.Split(' ').Length;
        }
        */

        vocales = 0;
        string vocalesMinusculas = "aeiou";
        foreach (char item in resultado.ToLower())
        {
            if (vocalesMinusculas.Contains(item.ToString())) //Para cada letra del texto, si esa letra está en ‘aeiou’, entonces suma 1 al contador de vocales
            {
                vocales++;
            }
        }
    }

    static void BuscarPalabrasEnTextos()
    {
        if (totalTextos == 0)
        {
            Console.WriteLine("No hay textos almacenados para buscar");
            return;
        }

        Console.Write("\nIngrese la palabra a buscar: ");
        string palabra = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(palabra))
        {
            Console.WriteLine("La palabra no puede estar vacía");
            return;
        }

        int[] resultados = BuscarPalabra(textos, totalTextos, palabra);

        bool encontrada = false;
        Console.WriteLine($"\nResultados de búsqueda para {palabra}");

        for (int i = 0; i < totalTextos; i++)
        {
            if (resultados[i] > 0)
            {
                encontrada = true;
                Console.WriteLine($"- Texto {i + 1}: {resultados[i]} ocurrencia(s)");

                string textoCorto;
                if (textos[i].Length > 50)
                {
                    textoCorto = textos[i].Substring(0, 50) + "...";
                }
                else
                {
                    textoCorto = textos[i];
                }
                Console.WriteLine($" \"{textoCorto}\"");
            }
        }
        if (!encontrada)
        {
            Console.WriteLine($"La palabra \"{palabra}\" no se encontró en ningún texto");
        }

    }

    //Cuenta cuantas veces aparece la palabra en cada texto
    static int[] BuscarPalabra(string[] textos, int totalTextos, string palabra)
    {
        int[] contadores = new int[totalTextos];//Se crea un arreglo para guardar los resultados por cada texto guardado
        string palabraBuscar = palabra.ToLower();//Convertir la palabra a minusculas

        for (int i = 0; i < totalTextos; i++)//Se recorre todos los textos
        {
            string textoLimpio = LimpiarTexto(textos[i]);//Se llama al metodo para eliminar signos, poner todo en minusculas y eliminar espacios innecesarios.
            string[] palabras = textoLimpio.Split(' ');//Se divide el texto en un array de palabras

            //Contar las veces que aparece la palabra
            int contador = 0;
            foreach (string palabraTexto in palabras)//Se recorre cada palabra del texto
            {
                if (palabraTexto == palabraBuscar)//si son iguales a la palabra buscada
                {
                    contador++;//Se suma 1 al contador
                }
            }
            //Guarda cuantas veces aparecio la palabra en ese texto
            contadores[i] = contador;//Guarda el resultado en el arreglo
        }
        //Devolver todos los resultados
        return contadores;//Devuelve el arreglo completo, con los resultados por texto

    }

    static void MostrarAnalisisEspecifico()
    {
        if (totalTextos == 0)
        {
            Console.WriteLine("No hay textos almacenados para analizar");
            return; // Sale del metodo
        }

        //Muestra la lista de textos disponibles
        Console.WriteLine("\nTextos disponibles:");
        for (int i = 0; i < totalTextos; i++)
        {
            string vistaPrevia;
            if (textos[i].Length > 40)//Si el texto tiene mas de 40 letras
            {
                vistaPrevia = textos[i].Substring(0, 40) + "...";//Lo recorta y lo pone ... al final
            }
            else
            {
                vistaPrevia = textos[i];//Si tiene 40 o menos, lo muestra completo
            }
            Console.WriteLine($"{i + 1}.{vistaPrevia}"); //Muestra el numero y la vista previa
        }
        Console.WriteLine("Seleccione el número del texto a analizar: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= totalTextos)
        {
            AnalizarTextoEspecifico(indice - 1);
        }
        else
        {
            Console.WriteLine("Número de texto inválido.");
        }
    }
    static void AnalizarTextoEspecifico(int indice)
    {
        string texto = textos[indice];//Es el texto original de texto elegido por el usuario
        string textoLimpio = LimpiarTexto(texto);//textoLimpio es la vesion sin signos, minusculas, con espacios corregidos

        //Mostrar datos generales donde se usan arrays para mostrar los datos que ya se calcularn al guardar el texto
        Console.WriteLine($"\nAnálisis del texto {indice + 1}:");
        Console.WriteLine($"Texto original: \"{texto}\"");
        Console.WriteLine($"Palabras: {contadorPalabras[indice]}");
        Console.WriteLine($"Caracteres: {contadorCaracteres[indice]}");

        //Encontrar las 5 palabras mas largas
        string[] palabras = textoLimpio.Split(' ');//Se divide el texto e palabras usando Split(' ')

        //Ordenar por tamaño de mayor a menor
        for (int i = 0; i < palabras.Length - 1; i++)
        {
            for (int j = i + 1; j < palabras.Length; j++)
            {
                if (palabras[i].Length < palabras[j].Length)
                {
                    string temp = palabras[i];
                    palabras[i] = palabras[j];
                    palabras[j] = temp;
                }
            }

        }

        //Mostrar las 5 primeras palabras largas
        int contador = 0;
        for (int i = 0; i < palabras.Length && contador < 5; i++)
        {
            if (palabras[i].Length > 0)
            {
                contador++;
                Console.WriteLine($"{contador}.{palabras[i]} ({palabras[i].Length} letras)");
            }

        }

        ContarVocales(textoLimpio);
    }
    //Cuenta cuantas veces aparecen las vocales
    static void ContarVocales(string texto) // recibe como parámetro texto
    {
        //Se crea un arreglo para contar las vocales de 8posiciones, una para cada vocal
        int[] contadorVocales = new int[5]; // a, e, i, o, u
        string vocales = "aeiou"; //Sirve para saber cuales son las vocales que amos a buscar

        // recorre cada letra del texto y convierte el texto a minusculas para evitar errores con mayusculas
        foreach (char c in texto.ToLower())
        {
            //Comparar cada letra con las vocales
            for (int i = 0; i < vocales.Length; i++)
            {
                if (c == vocales[i])//compara la letra actual c con cada vocal
                {
                    contadorVocales[i]++;//Si hay coincidencia, suma 1 al contador
                    break;//sale del bucle y no sigue comparando
                }
            }
        }

        //Mostrar resultados, recorre el areglo contadoVocales y muestra cuantas veces apareció cada vocal
        Console.WriteLine("\nFrecuencia de vocales:");
        string[] nombresVocales = { "A", "E", "I", "O", "U" };
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"- {nombresVocales[i]}: {contadorVocales[i]} ocurrencias");//usa otro arreglo nombresVocales[] solo para imprimir las letras en mayúscula
        }
    }

    // Genera un reporte general de todos los textos analizados
    static void GenerarReporte(string[] textos, int[] contadorPalabras, int[] contadorCaracteres, int totalTextos)
    {
        if (totalTextos == 0)
        {
            Console.WriteLine("❌ No hay textos para generar reporte.");
            return;
        }

        StringBuilder reporte = new StringBuilder();
        reporte.AppendLine("\n=== REPORTE COMPLETO ===");

        int totalPalabras = 0;
        int totalCaracteresTodos = 0;

        for (int i = 0; i < totalTextos; i++)
        {
            totalPalabras += contadorPalabras[i];
            totalCaracteresTodos += contadorCaracteres[i];
        }

        double promedioPalabras = (double)totalPalabras / totalTextos;

        reporte.AppendLine("Estadísticas Generales:");
        reporte.AppendLine($"- Total de textos analizados: {totalTextos}");
        reporte.AppendLine($"- Promedio de palabras por texto: {promedioPalabras:F2}");
        reporte.AppendLine($"- Total de caracteres procesados: {totalCaracteresTodos}");

        // Buscar texto con más y menos palabras
        int indiceMasPalabras = 0;
        int indiceMenosPalabras = 0;

        for (int i = 1; i < totalTextos; i++)
        {
            if (contadorPalabras[i] > contadorPalabras[indiceMasPalabras])
                indiceMasPalabras = i;
            if (contadorPalabras[i] < contadorPalabras[indiceMenosPalabras])
                indiceMenosPalabras = i;
        }

        reporte.AppendLine("\n Récords:");
        string textoMas = textos[indiceMasPalabras].Length > 30 ?
            textos[indiceMasPalabras].Substring(0, 30) + "..." : textos[indiceMasPalabras];
        string textoMenos = textos[indiceMenosPalabras].Length > 30 ?
            textos[indiceMenosPalabras].Substring(0, 30) + "..." : textos[indiceMenosPalabras];

        reporte.AppendLine($"- Texto con más palabras: \"{textoMas}\" ({contadorPalabras[indiceMasPalabras]} palabras)");
        reporte.AppendLine($"- Texto con menos palabras: \"{textoMenos}\" ({contadorPalabras[indiceMenosPalabras]} palabras)");

        // Contar vocales en todos los textos
        int[] totalVocales = new int[5];
        string vocales = "aeiou";

        for (int i = 0; i < totalTextos; i++)
        {
            string textoLimpio = LimpiarTexto(textos[i]);
            foreach (char c in textoLimpio.ToLower())
            {
                for (int j = 0; j < 5; j++)
                {
                    if (c == vocales[j])
                    {
                        totalVocales[j]++;
                        break;
                    }
                }
            }
        }

        reporte.AppendLine("\nAnálisis de Vocales:");
        string[] nombres = { "A", "E", "I", "O", "U" };
        for (int i = 0; i < 5; i++)
            reporte.AppendLine($"- {nombres[i]}: {totalVocales[i]} ocurrencias");

        // Mostrar reporte completo
        Console.WriteLine(reporte.ToString());
    }
}
