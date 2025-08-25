using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestión_de_Biblioteca
{
    public class Biblioteca
    {
        private MaterialBase[] inventario;
        private Usuario[] usuarios;
        private int totalMateriales;
        private int totalUsuarios;

        //constructor
        public Biblioteca(int capacidadUsuarios = 2)
        {
            inventario = new MaterialBase[100];
            usuarios = new Usuario[capacidadUsuarios]; //configurable, lo puse para 2 usuarios
            totalMateriales = 0;
            totalUsuarios = 0;

        }
        //Agregar material al inventario
        public void AgregarMaterial(MaterialBase materialBase)
        {
            if (totalMateriales >= inventario.Length)
            {
                Console.WriteLine("Inventario lleno. No se puede agregar mas material.");
                return;
            }
            inventario[totalMateriales] = materialBase;
            totalMateriales++;
            Console.WriteLine($"Material agregado: {materialBase.Titulo}");
        }
        //Agregar usuario
        public void AgregarUsuario(Usuario usuario)
        {
            if (totalUsuarios >= usuarios.Length)
            {
                Console.WriteLine("Capacidad maxima de usuarios alcanzada.");
                return;
            }
            usuarios[totalUsuarios] = usuario;
            totalUsuarios++;
            Console.WriteLine($"Usuario registrado: {usuario.Nombre}");
        }
        //Eliminar material por título
        public bool EliminarMaterial(string titulo)
        {
            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null && inventario[i].Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    // Compactamos el array para no dejar huecos
                    for (int j = i; j < totalMateriales - 1; j++)
                    {
                        inventario[j] = inventario[j + 1];
                    }

                    inventario[totalMateriales - 1] = null;
                    totalMateriales--;

                    Console.WriteLine($"Material '{titulo}' eliminado correctamente.");
                    return true;
                }
            }
            Console.WriteLine($"No se encontró material con el título '{titulo}'.");
            return false;
        }



        //Buscar materiales por titulo
        public MaterialBase BuscarMaterial(string criterio)
        {
            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null && inventario[i].Titulo.Equals(criterio, StringComparison.OrdinalIgnoreCase))
                {
                    return inventario[i];
                }
            }
            return null;
        }
        //Buscar materiales por autor
        public MaterialBase[] BuscarMateriales(string autor)
        {
            MaterialBase[] resultados = new MaterialBase[totalMateriales];
            int contador = 0;

            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null && inventario[i].Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
                {
                    resultados[contador] = inventario[i];
                    contador++;
                }
            }

            MaterialBase[] final = new MaterialBase[contador];
            for (int j = 0; j < contador; j++)
            {
                final[j] = resultados[j];
            }
            return final;
        }
        //Reporte: materiales más prestados
        public void ReporteMaterialesMasPrestados()
        {
            if (totalMateriales == 0)
            {
                Console.WriteLine("No hay materiales en el inventario.");
                return;
            }

            // Encontrar el máximo
            int maxPrestamos = 0;
            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null && inventario[i].VecesPrestado > maxPrestamos)
                {
                    maxPrestamos = inventario[i].VecesPrestado;
                }
            }

            if (maxPrestamos == 0)
            {
                Console.WriteLine("Ningún material ha sido prestado todavía.");
                return;
            }

            Console.WriteLine($"\nMateriales más prestados (con {maxPrestamos} préstamos):");
            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null && inventario[i].VecesPrestado == maxPrestamos)
                {
                    Console.WriteLine($" - {inventario[i].Titulo} ({inventario[i].VecesPrestado} veces)");
                }
            }
        }
        //Buscar usuario por ID
        public Usuario BuscarUsuario(int id)
        {
            for (int i = 0; i < totalUsuarios; i++)
            {
                if (usuarios[i] != null && usuarios[i].NumeroIdentificacion == id)
                {

                }
            }
            return null;
        }
        //Reporte: usuarios con mas prestamos
        public void ReporteUsuariosMasPrestamos()
        {
            if (totalUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            // Buscar el máximo de prestamos
            int maxPrestamos = 0;
            for (int i = 0; i < totalUsuarios; i++)
            {
                if (usuarios[i] != null && usuarios[i].CantidadPrestamos > maxPrestamos)
                {
                    maxPrestamos = usuarios[i].CantidadPrestamos;
                }
            }

            if (maxPrestamos == 0)
            {
                Console.WriteLine("Ningún usuario ha realizado préstamos todavía.");
                return;
            }

            Console.WriteLine($"\nUsuarios con más préstamos (con {maxPrestamos} préstamos):");
            for (int i = 0; i < totalUsuarios; i++)
            {
                if (usuarios[i] != null && usuarios[i].CantidadPrestamos == maxPrestamos)
                {
                    Console.WriteLine($" - {usuarios[i].Nombre} (ID: {usuarios[i].NumeroIdentificacion})");
                }
            }
        }
        // Reporte: multas pendientes
        public void ReporteMultasPendientes()
        {
            if (totalUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            foreach (Usuario u in usuarios)
            {
                if (u != null)
                {
                    u.CalcularMultas();  //ejecuta el método de cada usuario
                }
            }
        }
        //Reporte: estadísticas generales
        public void ReporteEstadisticasGenerales()
        {
            Console.WriteLine("\n Estadísticas generales de la biblioteca:");

            Console.WriteLine($" - Total de materiales en inventario: {totalMateriales}");
            Console.WriteLine($" - Total de usuarios registrados: {totalUsuarios}");

            int disponibles = 0;
            int prestados = 0;
            int prestamosAcumulados = 0;

            for (int i = 0; i < totalMateriales; i++)
            {
                if (inventario[i] != null)
                {
                    if (inventario[i].Disponible)
                        disponibles++;
                    else
                        prestados++;

                    prestamosAcumulados += inventario[i].VecesPrestado;
                }
            }

            Console.WriteLine($" - Materiales disponibles: {disponibles}");
            Console.WriteLine($" - Materiales prestados: {prestados}");
            Console.WriteLine($" - Préstamos acumulados realizados: {prestamosAcumulados}");
        }

        //Generar reporte completo
        public void GenerarReporte()
        {
            Console.WriteLine("\n Reporte de Biblioteca:");
            Console.WriteLine("Materiales en inventario:");
            for (int i = 0; i < totalMateriales; i++)
            {
                Console.WriteLine(inventario[i].ObtenerInformacion());
            }

            Console.WriteLine("\nUsuarios registrados: ");
            for (int j = 0; j < totalUsuarios; j++)
            {
                Console.WriteLine($"- {usuarios[j].Nombre} (ID: {usuarios[j].NumeroIdentificacion})");
            }
        }
        //Demostracion de polimorfismo
        public void ProcesarTodosLosMateriales()
        {
            Console.WriteLine("\nProcesando todos los materiales...");
            foreach (MaterialBase materialBase in inventario)
            {
                if (materialBase != null)
                {
                    Console.WriteLine(materialBase.ObtenerInformacion());
                    //Polimorfismo: cada tipo ejecuta su propia version
                }
            }
        }
    }
}
