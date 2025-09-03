using Sistema_de_Notificaciones_Empresariales.Bases_y_Derivadas;
using Sistema_de_Notificaciones_Empresariales.Canales;
using Sistema_de_Notificaciones_Empresariales.Gestos_y_Reportes;
using Sistema_de_Notificaciones_Empresariales.Interfaces;
using System.Text;

var gestor = new GestorNotificaciones(100);
var canalEMail = new CanalEmail();
var canalSMS = new CanalSMS();
gestor.RegistrarCanal(canalEMail);
gestor.RegistrarCanal(canalSMS);

Console.WriteLine("=== SISTEMA DE NOTIFICACIONES EMPRESARIALES ===");
bool continuar = true;
while (continuar)
{
    MostrarMenu();
    continuar = ProcesarOpcionMenu(gestor);
}
Console.WriteLine("Sistema finalizado.");
Console.ReadKey();
static void MostrarMenu()
{
    Console.WriteLine("\n --- MENÚ PRINCIPAL ---");
    Console.WriteLine("1. Gestion de Notificaciones");
    Console.WriteLine(" 1.1 Crear notificación Email");
    Console.WriteLine(" 1.2 Crear notificación SMS");
    Console.WriteLine(" 1.3 Crear notificación Push");
    Console.WriteLine(" 1.4 Listar todas las notificaciones");
    Console.WriteLine("2. Gestión de Canales");
    Console.WriteLine(" 2.1 Configurar canal Email");
    Console.WriteLine(" 2.2 Configurar canal SMS");
    Console.WriteLine(" 2.3 Ver estado de canales");
    Console.WriteLine("3. Operaciones Masivas");
    Console.WriteLine(" 3.1 Enviar todas las notificaciones pendientes");
    Console.WriteLine(" 3.2 Procesar textos de notificaciones");
    Console.WriteLine(" 3.3 Calcular costos de envio");
    Console.WriteLine("4. Reportes y Estadísticas");
    Console.WriteLine(" 4.1 Reporte detallado por tipo");
    Console.WriteLine(" 4.2 Estadísticas de canales");
    Console.WriteLine(" 4.3 Análisis de texto completo");
    Console.WriteLine(" 4.4 Exportar repore completo");
    Console.WriteLine("5. Demostración de Polimorfismo");
    Console.WriteLine(" 5.1 mostrar polimorfismo con interfaces");
    Console.WriteLine(" 5.2 Verificar implementaciones múltiples");
    Console.WriteLine(" 5.3 Ejemplo de casting e interfaces");
    Console.WriteLine();
    Console.WriteLine("6. Salir");
    Console.Write("Selecciona una opción (ejemplo: 1.1): ");
}
static bool ProcesarOpcionMenu(GestorNotificaciones gestor)
{
    string opcion = (Console.ReadLine() ?? "").Trim();
    switch (opcion)
    {
        //Gestion de notificciones
        case "1.1":
            CrearEmail(gestor);
            break;
        case "1.2":
            CrearSMS(gestor);
            break;
        case "1.3":
            CrearPush(gestor);
            break;
        case "1.4":
            ListarNotificaciones(gestor);
            break;

        //Gestion de Canales
        case "2.1":
            ConfigurarCanal(gestor, "Email");
            break;
        case "2.2":
            ConfigurarCanal(gestor, "SMS");
            break;
        case "2.3":
            VerCanales(gestor);
            break;

        //Operaciones Masivas
        case "3.1":
            Console.WriteLine("Enviando todas la notificaciones pendientes....");
            gestor.ProcesarTodasLasNotificaciones();
            break;
        case "3.2":
            Console.WriteLine("Procesando textos de notificaciones...");
            gestor.ProcesarTexto();
            break;
        case "3.3":
            double costo = gestor.CalcularCostoEstimado();
            Console.WriteLine($"Costo estimado de envío: {costo: 0.00:C}");
            break;

        //Reportes y Estadísticas
        case "4.1":
            ReportePorTipo(gestor);
            break;
        case "4.2":
            VerCanales(gestor);
            break;
        case "4.3":
            AnalisisTextoCompleto(gestor);
            break;
        case "4.4":
            ExportarReporteCompleto(gestor);
            break;

        //Demostracion de Polimorfismo
        case "5.1":
            DemostrarPolimorfismo(gestor);
            break;
        case "5.2":
            VerificarImplementacionesMultiples(gestor);
            break;
        case "5.3":
            EjemploCastingInterfaces(gestor);
            break;

        case "6":
            return false;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
    return true;
}
//Metodos de creacion
static void CrearEmail(GestorNotificaciones gestor)
{
    string titulo = Solicitar("Título:");
    string contendo = Solicitar("Contenido: ");
    string email = Solicitar("Email destinatario: ");
    string asunto = Solicitar("Asunto (Enter para usar titulo): ");
    var n = new NotificacionEmail(titulo, contendo, email, asunto, esHTML: true);
    gestor.AgregarNotificacion(n);
    Console.WriteLine("notificacion Email creada.");
}
static void CrearSMS(GestorNotificaciones gestor)
{
    string titulo = Solicitar("Título: ");
    string contenido = Solicitar("Contenido: ");
    string numero = Solicitar("Número (ej. +51999999999): ");
    var n = new NotificacionSMS(titulo, contenido, numero);
    gestor.AgregarNotificacion(n);
    Console.WriteLine("Notificación SMS creada.");
}
static void CrearPush(GestorNotificaciones gestor)
{
    string titulo = Solicitar("Título: ");
    string contenido = Solicitar("Contenido: ");
    string token = Solicitar("Device Token: ");
    string icono = Solicitar("Icono (ej. 🔔): ");
    var n = new NotificacionPush(titulo, contenido, token, string.IsNullOrWhiteSpace(icono) ? "🔔" : icono);
    gestor.AgregarNotificacion(n);
    Console.WriteLine("Notificación Push creada.");
}

// Listados
static void ListarNotificaciones(GestorNotificaciones gestor)
{
    var arr = gestor.ObtenerNotificaciones();
    bool vacio = true;
    foreach (var noti in arr)
    {
        if (noti == null) continue;
        vacio = false;
        Console.WriteLine(noti.GenerarReporte());
    }
    if (vacio) Console.WriteLine("No hay notificaciones registradas.");
}
static void VerCanales(GestorNotificaciones gestor)
{
    var cs = gestor.ObtenerCanales();
    bool vacio = true;
    foreach (var c in cs)
    {
        if (c == null) continue;
        vacio = false;
        Console.WriteLine($"{c.NombreCanal} | Activo: {c.EstadoActivo} | Costo: ${c.CostoEnvio:0.00}");
        Console.WriteLine($"Estadísticas: {c.ObtenerEstadistica()}");
        Console.WriteLine();
    }
    if (vacio) Console.WriteLine("No hay canales registrados.");
}

//Configuracion de canales
static void ConfigurarCanal(GestorNotificaciones gestor, string nombreCanal)
{
    var canales = gestor.ObtenerCanales();
    ICanalComunicacion encontrado = null;
    foreach (var c in canales)
    {
        if (c == null) continue;
        if (c.NombreCanal.Equals(nombreCanal, StringComparison.OrdinalIgnoreCase))
        {
            encontrado = c;
            break;
        }
    }

    if (encontrado == null)
    {
        Console.WriteLine($"Canal {nombreCanal} no encontrado.");
        return;
    }

    Console.WriteLine($"{encontrado.NombreCanal} actualmente {(encontrado.EstadoActivo ? "ACTIVO" : "INACTIVO")}");
    string resp = Solicitar("Desea activar/desactivar? (a = activar / d = desactivar / enter = cancelar): ");
    if (resp.Equals("a", StringComparison.OrdinalIgnoreCase))
    {
        encontrado.EstadoActivo = true;
        Console.WriteLine("Canal activado.");
    }
    else if (resp.Equals("d", StringComparison.OrdinalIgnoreCase))
    {
        encontrado.EstadoActivo = false;
        Console.WriteLine("Canal desactivado.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}

//Reportes
static void ReportePorTipo(GestorNotificaciones gestor)
{
    var arr = gestor.ObtenerNotificaciones();
    bool any = false;
    Console.WriteLine("=== Reporte detallado por tipo ===");

    Console.WriteLine("-- Emails --");
    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is NotificacionEmail) { any = true; Console.WriteLine(n.GenerarReporte()); }
    }
    if (!any) Console.WriteLine("Sin notificaciones Email.");
    any = false;

    Console.WriteLine("-- SMS --");
    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is NotificacionSMS) { any = true; Console.WriteLine(n.GenerarReporte()); }
    }
    if (!any) Console.WriteLine("Sin notificaciones SMS.");
    any = false;

    Console.WriteLine("-- Push --");
    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is NotificacionPush) { any = true; Console.WriteLine(n.GenerarReporte()); }
    }
    if (!any) Console.WriteLine("Sin notificaciones Push.");
}
static void AnalisisTextoCompleto(GestorNotificaciones gestor)
{
    var arr = gestor.ObtenerNotificaciones();
    int totalPalabras = 0;
    int notificacionesConTexto = 0;

    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is IProcesadorTexto p)
        {
            string procesado = p.ProcesarTexto(n.Contenido);
            totalPalabras += p.ContarPalabras(procesado);
            notificacionesConTexto++;
        }
    }

    Console.WriteLine($"Notificaciones con texto procesable: {notificacionesConTexto}");
    Console.WriteLine($"Total de palabras (procesadas): {totalPalabras}");
}
static void ExportarReporteCompleto(GestorNotificaciones gestor)
{
    var generador = new GeneradorReportes();
    string reporte = generador.GenerarReporteCompleto(gestor);
    string ruta = Solicitar("Nombre de archivo para exportar (ej. reporte.txt): ").Trim();
    if (string.IsNullOrWhiteSpace(ruta))
    {
        Console.WriteLine("Nombre inválido. Operación cancelada.");
        return;
    }

    // Guardar archivo (sin manejo explícito de excepciones por módulo)
    File.WriteAllText(ruta, reporte, Encoding.UTF8);
    Console.WriteLine($"Reporte exportado a: {ruta}");
}

//DEmostraciones de polimorfirmos
static void DemostrarPolimorfismo(GestorNotificaciones gestor)
{
    Console.WriteLine("Demostración simple de polimorfismo (generando ejemplos):");
    INotificacion[] demo = new INotificacion[]
    {
                new NotificacionEmail("Bienvenida","Contenido email de prueba","user@test.com"),
                new NotificacionSMS("Alerta","Mensaje corto","1234567890"),
                new NotificacionPush("Recordatorio","Contenido push","device-xyz","")
    };
    foreach (var d in demo)
    {
        Console.WriteLine(d.GenerarReporte());
        if (d is IProcesadorTexto p)
        {
            Console.WriteLine($"-> Palabras procesadas: {p.ContarPalabras(p.ProcesarTexto(d.Contenido))}");
        }
        Console.WriteLine("---");
    }
}
static void VerificarImplementacionesMultiples(GestorNotificaciones gestor)
{
    Console.WriteLine("Verificando notificaciones que implementan múltiples interfaces:");
    var arr = gestor.ObtenerNotificaciones();
    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is IProcesadorTexto && n is INotificacion)
        {
            Console.WriteLine($"Notificación '{n.Titulo}' implementa IProcesadorTexto e INotificacion.");
        }
    }
}
static void EjemploCastingInterfaces(GestorNotificaciones gestor)
{
    Console.WriteLine("Ejemplo de casting: Buscando primera notificación que sea IProcesadorTexto...");
    var arr = gestor.ObtenerNotificaciones();
    foreach (var n in arr)
    {
        if (n == null) continue;
        if (n is IProcesadorTexto)
        {
            var p = (IProcesadorTexto)n;
            Console.WriteLine($"Casting exitoso para '{n.Titulo}'. Palabras: {p.ContarPalabras(p.ProcesarTexto(n.Contenido))}");
            return;
        }
    }
    Console.WriteLine("No se encontró ninguna notificación que implemente IProcesadorTexto.");
}

// util
static string Solicitar(string solicitar)
{
    Console.Write(solicitar);
    return Console.ReadLine() ?? "";
}
