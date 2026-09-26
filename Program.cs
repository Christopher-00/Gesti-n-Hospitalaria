using System;

// ============================================================
// ARREGLOS GLOBALES
// ============================================================

const int MAX = 100;

// ============================================================
// 1. MÓDULO DE PACIENTES
// ============================================================

string[] pacNombres = new string[MAX];
string[] pacCedulas = new string[MAX];
int[] pacEdades = new int[MAX];
string[] pacSexos = new string[MAX];
string[] pacDirecciones = new string[MAX];
string[] pacTelefonos = new string[MAX];
string[] pacFechasIngreso = new string[MAX];

int totalPacientes = 0;


// ============================================================
// 2. MÓDULO DE MÉDICOS
// ============================================================

string[] medNombres = new string[MAX];
string[] medEspecialidades = new string[MAX];
string[] medCodigos = new string[MAX];
string[] medDisponibilidades = new string[MAX];
// Estados posibles:
// "Disponible"
// "Ocupado"
// "Fuera de turno"

int[] medPacientesAtendidos = new int[MAX];

int totalMedicos = 0;


// ============================================================
// 3. MÓDULO DE CITAS MÉDICAS
// ============================================================

string[] citaCedulaPac = new string[MAX];
string[] citaCodMed = new string[MAX];
string[] citaEspecialidad = new string[MAX];
string[] citaFecha = new string[MAX];
string[] citaHora = new string[MAX];
string[] citaMotivo = new string[MAX];

string[] citaEstado = new string[MAX];
// Estados:
// "Pendiente"
// "Confirmada"
// "Atendida"
// "Cancelada"

int totalCitas = 0;


// ============================================================
// 4. MÓDULO DE EMERGENCIAS
// ============================================================

string[] emeCedulaPac = new string[MAX];

int[] emePrioridad = new int[MAX];
// 1 = Crítico
// 2 = Urgente
// 3 = Moderado
// 4 = Leve

string[] emeEspecialidadRequerida = new string[MAX];
DateTime[] emeFechaHoraLlegada = new DateTime[MAX];

int[] emeTiempoEspera = new int[MAX];

string[] emeCodMedAsignado = new string[MAX];

string[] emeEstado = new string[MAX];
// "Pendiente"
// "Atendido"

int totalEmergencias = 0;


// ============================================================
// DATOS INICIALES
// ============================================================

PrecargarDatosHospitalarios();


// ============================================================
// MENÚ PRINCIPAL
// ============================================================

int opcionMenuPrincipal = 0;

do
{
    Console.Clear();

    Console.WriteLine("==========================================================");
    Console.WriteLine("       SISTEMA INTEGRAL DE GESTIÓN HOSPITALARIA");
    Console.WriteLine("==========================================================");
    Console.WriteLine(" 1. Módulo de Gestión de Pacientes");
    Console.WriteLine(" 2. Módulo de Médicos y Especialidades");
    Console.WriteLine(" 3. Módulo de Citas Médicas");
    Console.WriteLine(" 4. Módulo de Emergencias");
    Console.WriteLine(" 5. Registrar Atención");
    Console.WriteLine(" 6. Historial Médico");
    Console.WriteLine(" 7. Estadísticas");
    Console.WriteLine(" 8. Reportes");
    Console.WriteLine(" 9. Salir");
    Console.WriteLine("==========================================================");
    Console.Write("Seleccione una opción del menú (1-9): ");

    string entradaUsuario = Console.ReadLine();

    if (!int.TryParse(entradaUsuario, out opcionMenuPrincipal))
    {
        Console.WriteLine("\n[Error] Debe ingresar un número entero.");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        continue;
    }

    switch (opcionMenuPrincipal)
    {
        case 1:
            MenuPacientes();
            break;

        case 2:
            MenuMedicos();
            break;

        case 3:
            MenuCitas();
            break;

        case 4:
            MenuEmergencias();
            break;

        case 5:
            
            break;

        case 6:
            
            break;

        case 7:
            
            break;

        case 8:
            
            break;

        case 9:
            Console.WriteLine("\nCerrando sesión del sistema hospitalario...");
            break;

        default:
            Console.WriteLine("\n[Advertencia] Opción fuera del rango 1-9.");
            Console.ReadKey();
            break;
    }

} while (opcionMenuPrincipal != 9);


// ============================================================
// DATOS PREDETERMINADOS
// ============================================================

void PrecargarDatosHospitalarios()
{
    // --------------------------------------------------------
    // MÉDICOS
    // --------------------------------------------------------

    medNombres[0] = "Dr. Alejandro Martinez";
    medEspecialidades[0] = "Medicina General";
    medCodigos[0] = "MED-01";
    medDisponibilidades[0] = "Disponible";
    medPacientesAtendidos[0] = 0;

    medNombres[1] = "Dra. Carmen Rivas";
    medEspecialidades[1] = "Pediatria";
    medCodigos[1] = "MED-02";
    medDisponibilidades[1] = "Disponible";
    medPacientesAtendidos[1] = 0;

    medNombres[2] = "Dr. Fernando Gonzalez";
    medEspecialidades[2] = "Traumatologia";
    medCodigos[2] = "MED-03";
    medDisponibilidades[2] = "Disponible";
    medPacientesAtendidos[2] = 0;

    totalMedicos = 3;


    // --------------------------------------------------------
    // PACIENTES
    // --------------------------------------------------------

    pacNombres[0] = "Mario Guevara";
    pacCedulas[0] = "05241234-5";
    pacEdades[0] = 34;
    pacSexos[0] = "M";
    pacDirecciones[0] = "Santa Ana Centro";
    pacTelefonos[0] = "7890-1234";
    pacFechasIngreso[0] = "2026-09-01 07:30";

    pacNombres[1] = "Lucia Beatriz";
    pacCedulas[1] = "04123987-1";
    pacEdades[1] = 28;
    pacSexos[1] = "F";
    pacDirecciones[1] = "Santa Ana Centro";
    pacTelefonos[1] = "7234-5678";
    pacFechasIngreso[1] = "2026-09-05 10:15";

    totalPacientes = 2;
}


// ============================================================
// 1. MÓDULO DE PACIENTES
// ============================================================

void MenuPacientes()
{
    int opcion = 0;

    do
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("       GESTIÓN DE PACIENTES");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Registrar nuevo paciente");
        Console.WriteLine("2. Buscar paciente por cédula");
        Console.WriteLine("3. Actualizar datos de paciente");
        Console.WriteLine("4. Listar pacientes");
        Console.WriteLine("5. Regresar al menú principal");
        Console.WriteLine("==============================================");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("\n[Error] Ingrese un número válido.");
            Console.ReadKey();
            continue;
        }

        switch (opcion)
        {
            case 1:
                RegistrarPaciente();
                break;

            case 2:
                BuscarPaciente();
                break;

            case 3:
                ActualizarPaciente();
                break;

            case 4:
                ListarPacientes();
                break;

            case 5:
                break;

            default:
                Console.WriteLine("\n[Error] Opción no válida.");
                Console.ReadKey();
                break;
        }

    } while (opcion != 5);
}


// ------------------------------------------------------------
// REGISTRAR PACIENTE
// ------------------------------------------------------------

void RegistrarPaciente()
{
    if (totalPacientes >= MAX)
    {
        Console.WriteLine("\n[Error] Se alcanzó la capacidad máxima de pacientes.");
        Console.ReadKey();
        return;
    }

    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          REGISTRO DE PACIENTE");
    Console.WriteLine("==============================================");

    string nombre;

    do
    {
        Console.Write("Nombre completo: ");
        nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("[Error] El nombre no puede estar vacío.");
        }

    } while (string.IsNullOrWhiteSpace(nombre));


    string cedula;

    do
    {
        Console.Write("Cédula / ID: ");
        cedula = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cedula))
        {
            Console.WriteLine("[Error] La cédula no puede estar vacía.");
            continue;
        }

        if (BuscarPacienteRecursivo(cedula, 0) != -1)
        {
            Console.WriteLine("[Error] Ya existe un paciente con esa cédula.");
            cedula = "";
        }

    } while (string.IsNullOrWhiteSpace(cedula));


    int edad;

    Console.Write("Edad: ");

    while (!int.TryParse(Console.ReadLine(), out edad) ||
           edad < 1 ||
           edad > 120)
    {
        Console.Write("Edad inválida. Ingrese una edad entre 1 y 120: ");
    }


    string sexo;

    do
    {
        Console.Write("Sexo (M/F): ");
        sexo = Console.ReadLine().ToUpper();

        if (sexo != "M" && sexo != "F")
        {
            Console.WriteLine("[Error] Debe ingresar M o F.");
        }

    } while (sexo != "M" && sexo != "F");


    string direccion;

    do
    {
        Console.Write("Dirección: ");
        direccion = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(direccion))
        {
            Console.WriteLine("[Error] La dirección no puede estar vacía.");
        }

    } while (string.IsNullOrWhiteSpace(direccion));


    string telefono;

    do
    {
        Console.Write("Teléfono: ");
        telefono = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(telefono))
        {
            Console.WriteLine("[Error] El teléfono no puede estar vacío.");
        }

    } while (string.IsNullOrWhiteSpace(telefono));


    // Guardar información

    pacNombres[totalPacientes] = nombre;
    pacCedulas[totalPacientes] = cedula;
    pacEdades[totalPacientes] = edad;
    pacSexos[totalPacientes] = sexo;
    pacDirecciones[totalPacientes] = direccion;
    pacTelefonos[totalPacientes] = telefono;
    pacFechasIngreso[totalPacientes] =
        DateTime.Now.ToString("yyyy-MM-dd HH:mm");

    totalPacientes++;

    Console.WriteLine("\n[OK] Paciente registrado correctamente.");
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
}


// ------------------------------------------------------------
// BUSCAR PACIENTE
// ------------------------------------------------------------

void BuscarPaciente()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("         BÚSQUEDA DE PACIENTE");
    Console.WriteLine("==============================================");

    Console.Write("Ingrese la cédula: ");
    string cedula = Console.ReadLine();

    int indice = BuscarPacienteRecursivo(cedula, 0);

    if (indice == -1)
    {
        Console.WriteLine("\n[Resultado] Paciente no encontrado.");
    }
    else
    {
        MostrarDatosPaciente(indice);
    }

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}


// ------------------------------------------------------------
// FUNCIÓN RECURSIVA #1
// ------------------------------------------------------------

int BuscarPacienteRecursivo(string cedulaBuscada, int indiceActual)
{
    // Caso base
    if (indiceActual >= totalPacientes)
    {
        return -1;
    }

    // Caso encontrado
    if (pacCedulas[indiceActual] == cedulaBuscada)
    {
        return indiceActual;
    }

    // Llamada recursiva
    return BuscarPacienteRecursivo(
        cedulaBuscada,
        indiceActual + 1
    );
}


// ------------------------------------------------------------
// MOSTRAR DATOS DE PACIENTE
// ------------------------------------------------------------

void MostrarDatosPaciente(int indice)
{
    Console.WriteLine("\n----------------------------------------------");
    Console.WriteLine("PACIENTE ENCONTRADO");
    Console.WriteLine("----------------------------------------------");

    Console.WriteLine($"Nombre       : {pacNombres[indice]}");
    Console.WriteLine($"Cédula / ID  : {pacCedulas[indice]}");
    Console.WriteLine($"Edad         : {pacEdades[indice]} años");
    Console.WriteLine($"Sexo         : {pacSexos[indice]}");
    Console.WriteLine($"Dirección    : {pacDirecciones[indice]}");
    Console.WriteLine($"Teléfono     : {pacTelefonos[indice]}");
    Console.WriteLine($"Ingreso      : {pacFechasIngreso[indice]}");
}


// ------------------------------------------------------------
// ACTUALIZAR PACIENTE
// ------------------------------------------------------------

void ActualizarPaciente()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("       ACTUALIZACIÓN DE PACIENTE");
    Console.WriteLine("==============================================");

    Console.Write("Ingrese la cédula del paciente: ");
    string cedula = Console.ReadLine();

    int indice = BuscarPacienteRecursivo(cedula, 0);

    if (indice == -1)
    {
        Console.WriteLine("\n[Error] Paciente no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"\nPaciente: {pacNombres[indice]}");

    string nombre;

    do
    {
        Console.Write("Nuevo nombre: ");
        nombre = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(nombre));

    pacNombres[indice] = nombre;


    int edad;

    Console.Write("Nueva edad: ");

    while (!int.TryParse(Console.ReadLine(), out edad) ||
           edad < 1 ||
           edad > 120)
    {
        Console.Write("Edad inválida. Ingrese una edad entre 1 y 120: ");
    }

    pacEdades[indice] = edad;


    string direccion;

    do
    {
        Console.Write("Nueva dirección: ");
        direccion = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(direccion));

    pacDirecciones[indice] = direccion;


    string telefono;

    do
    {
        Console.Write("Nuevo teléfono: ");
        telefono = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(telefono));

    pacTelefonos[indice] = telefono;


    Console.WriteLine("\n[OK] Datos actualizados correctamente.");
    Console.ReadKey();
}


// ------------------------------------------------------------
// LISTAR PACIENTES
// ------------------------------------------------------------

void ListarPacientes()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          LISTADO DE PACIENTES");
    Console.WriteLine("==============================================");

    if (totalPacientes == 0)
    {
        Console.WriteLine("No existen pacientes registrados.");
    }
    else
    {
        for (int i = 0; i < totalPacientes; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {pacNombres[i]} | " +
                $"Cédula: {pacCedulas[i]} | " +
                $"Edad: {pacEdades[i]} | " +
                $"Tel: {pacTelefonos[i]}"
            );
        }
    }

    Console.WriteLine("\nPresione una tecla...");
    Console.ReadKey();
}


// ============================================================
// 2. MÓDULO DE MÉDICOS
// ============================================================

void MenuMedicos()
{
    int opcion = 0;

    do
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("        GESTIÓN DE MÉDICOS");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Registrar nuevo médico");
        Console.WriteLine("2. Modificar disponibilidad");
        Console.WriteLine("3. Ver listado de médicos");
        Console.WriteLine("4. Regresar al menú principal");
        Console.WriteLine("==============================================");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("\n[Error] Ingrese un número válido.");
            Console.ReadKey();
            continue;
        }

        switch (opcion)
        {
            case 1:
                RegistrarMedico();
                break;

            case 2:
                CambiarDisponibilidadMedico();
                break;

            case 3:
                ListarMedicos();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("\n[Error] Opción no válida.");
                Console.ReadKey();
                break;
        }

    } while (opcion != 4);
}


// ------------------------------------------------------------
// REGISTRAR MÉDICO
// ------------------------------------------------------------

void RegistrarMedico()
{
    if (totalMedicos >= MAX)
    {
        Console.WriteLine("\n[Error] Capacidad máxima de médicos alcanzada.");
        Console.ReadKey();
        return;
    }

    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          REGISTRO DE MÉDICO");
    Console.WriteLine("==============================================");

    string nombre;

    do
    {
        Console.Write("Nombre completo: ");
        nombre = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(nombre));


    string especialidad;

    do
    {
        Console.Write("Especialidad: ");
        especialidad = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(especialidad));


    string codigo;

    do
    {
        Console.Write("Código institucional: ");
        codigo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("[Error] El código no puede estar vacío.");
            continue;
        }

        if (BuscarMedicoPorCodigo(codigo) != -1)
        {
            Console.WriteLine("[Error] Ese código ya está registrado.");
            codigo = "";
        }

    } while (string.IsNullOrWhiteSpace(codigo));


    medNombres[totalMedicos] = nombre;
    medEspecialidades[totalMedicos] = especialidad;
    medCodigos[totalMedicos] = codigo;
    medDisponibilidades[totalMedicos] = "Disponible";
    medPacientesAtendidos[totalMedicos] = 0;

    totalMedicos++;

    Console.WriteLine("\n[OK] Médico registrado correctamente.");
    Console.ReadKey();
}


// ------------------------------------------------------------
// BUSCAR MÉDICO POR CÓDIGO
// ------------------------------------------------------------

int BuscarMedicoPorCodigo(string codigo)
{
    for (int i = 0; i < totalMedicos; i++)
    {
        if (medCodigos[i] == codigo)
        {
            return i;
        }
    }

    return -1;
}


// ------------------------------------------------------------
// MODIFICAR DISPONIBILIDAD
// ------------------------------------------------------------

void CambiarDisponibilidadMedico()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("       DISPONIBILIDAD DEL MÉDICO");
    Console.WriteLine("==============================================");

    Console.Write("Código del médico: ");
    string codigo = Console.ReadLine();

    int indice = BuscarMedicoPorCodigo(codigo);

    if (indice == -1)
    {
        Console.WriteLine("\n[Error] Médico no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"\nMédico: {medNombres[indice]}");
    Console.WriteLine($"Especialidad: {medEspecialidades[indice]}");
    Console.WriteLine($"Estado actual: {medDisponibilidades[indice]}");

    Console.WriteLine("\nSeleccione nuevo estado:");
    Console.WriteLine("1. Disponible");
    Console.WriteLine("2. Ocupado");
    Console.WriteLine("3. Fuera de turno");

    Console.Write("Opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            medDisponibilidades[indice] = "Disponible";
            break;

        case "2":
            medDisponibilidades[indice] = "Ocupado";
            break;

        case "3":
            medDisponibilidades[indice] = "Fuera de turno";
            break;

        default:
            Console.WriteLine("\n[Error] Opción inválida.");
            Console.ReadKey();
            return;
    }

    Console.WriteLine("\n[OK] Disponibilidad actualizada.");
    Console.ReadKey();
}


// ------------------------------------------------------------
// LISTAR MÉDICOS
// ------------------------------------------------------------

void ListarMedicos()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("            LISTADO DE MÉDICOS");
    Console.WriteLine("==============================================");

    if (totalMedicos == 0)
    {
        Console.WriteLine("No existen médicos registrados.");
    }
    else
    {
        for (int i = 0; i < totalMedicos; i++)
        {
            Console.WriteLine(
                $"{i + 1}. [{medCodigos[i]}] " +
                $"{medNombres[i]} | " +
                $"Especialidad: {medEspecialidades[i]} | " +
                $"Estado: {medDisponibilidades[i]} | " +
                $"Atendidos: {medPacientesAtendidos[i]}"
            );
        }
    }

    Console.WriteLine("\nPresione una tecla...");
    Console.ReadKey();
}


// ============================================================
// 3. MÓDULO DE CITAS MÉDICAS
// ============================================================

void MenuCitas()
{
    int opcion = 0;

    do
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("          GESTIÓN DE CITAS MÉDICAS");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Registrar nueva cita");
        Console.WriteLine("2. Consultar citas por paciente");
        Console.WriteLine("3. Consultar citas por médico");
        Console.WriteLine("4. Consultar citas por fecha");
        Console.WriteLine("5. Modificar estado de cita");
        Console.WriteLine("6. Mostrar todas las citas");
        Console.WriteLine("7. Regresar al menú principal");
        Console.WriteLine("==============================================");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("\n[Error] Ingrese un número válido.");
            Console.ReadKey();
            continue;
        }

        switch (opcion)
        {
            case 1:
                RegistrarCita();
                break;

            case 2:
                ConsultarCitasPorPaciente();
                break;

            case 3:
                ConsultarCitasPorMedico();
                break;

            case 4:
                ConsultarCitasPorFecha();
                break;

            case 5:
                ModificarEstadoCita();
                break;

            case 6:
                ConsultarTodasLasCitas();
                break;

            case 7:
                break;

            default:
                Console.WriteLine("\n[Error] Opción no válida.");
                Console.ReadKey();
                break;
        }

    } while (opcion != 7);
}


// ------------------------------------------------------------
// REGISTRAR CITA
// ------------------------------------------------------------

void RegistrarCita()
{
    if (totalCitas >= MAX)
    {
        Console.WriteLine("\n[Error] Capacidad máxima de citas alcanzada.");
        Console.ReadKey();
        return;
    }

    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          REGISTRO DE CITA MÉDICA");
    Console.WriteLine("==============================================");

    Console.Write("Cédula del paciente: ");
    string cedula = Console.ReadLine();

    int indicePaciente = BuscarPacienteRecursivo(cedula, 0);

    if (indicePaciente == -1)
    {
        Console.WriteLine("\n[Error] El paciente no está registrado.");
        Console.ReadKey();
        return;
    }


    // --------------------------------------------------------
    // Selección de especialidad
    // --------------------------------------------------------

    string especialidad;

    do
    {
        Console.Write("Especialidad requerida: ");
        especialidad = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(especialidad))
        {
            Console.WriteLine("[Error] La especialidad no puede estar vacía.");
        }

    } while (string.IsNullOrWhiteSpace(especialidad));


    // --------------------------------------------------------
    // Buscar automáticamente un médico disponible
    // --------------------------------------------------------

    int indiceMedico =
        BuscarMedicoDisponiblePorEspecialidad(especialidad);

    if (indiceMedico == -1)
    {
        Console.WriteLine(
            "\n[Error] No existe un médico disponible " +
            "para esa especialidad."
        );

        Console.ReadKey();
        return;
    }

    Console.WriteLine(
        $"\nMédico asignado automáticamente: " +
        $"{medNombres[indiceMedico]} " +
        $"[{medCodigos[indiceMedico]}]"
    );


    // --------------------------------------------------------
    // Fecha
    // --------------------------------------------------------

    string fecha;

    do
    {
        Console.Write("Fecha de la cita (YYYY-MM-DD): ");
        fecha = Console.ReadLine();

        if (!DateTime.TryParseExact(
                fecha,
                "yyyy-MM-dd",
                null,
                System.Globalization.DateTimeStyles.None,
                out _))
        {
            Console.WriteLine(
                "[Error] Formato inválido. Utilice YYYY-MM-DD."
            );

            fecha = "";
        }

    } while (string.IsNullOrWhiteSpace(fecha));


    // --------------------------------------------------------
    // Hora
    // --------------------------------------------------------

    string hora;

    do
    {
        Console.Write("Hora de la cita (HH:MM): ");
        hora = Console.ReadLine();

        if (!DateTime.TryParseExact(
                hora,
                "HH:mm",
                null,
                System.Globalization.DateTimeStyles.None,
                out _))
        {
            Console.WriteLine(
                "[Error] Formato inválido. Utilice HH:MM."
            );

            hora = "";
        }

    } while (string.IsNullOrWhiteSpace(hora));


    // --------------------------------------------------------
    // Motivo
    // --------------------------------------------------------

    string motivo;

    do
    {
        Console.Write("Motivo de consulta: ");
        motivo = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(motivo));


    // --------------------------------------------------------
    // Guardar cita
    // --------------------------------------------------------

    citaCedulaPac[totalCitas] = cedula;
    citaCodMed[totalCitas] = medCodigos[indiceMedico];
    citaEspecialidad[totalCitas] = especialidad;
    citaFecha[totalCitas] = fecha;
    citaHora[totalCitas] = hora;
    citaMotivo[totalCitas] = motivo;
    citaEstado[totalCitas] = "Pendiente";

    totalCitas++;

    Console.WriteLine(
        "\n[OK] Cita registrada correctamente."
    );

    Console.ReadKey();
}


// ------------------------------------------------------------
// BUSCAR MÉDICO DISPONIBLE SEGÚN ESPECIALIDAD
// ------------------------------------------------------------

int BuscarMedicoDisponiblePorEspecialidad(
    string especialidadBuscada)
{
    for (int i = 0; i < totalMedicos; i++)
    {
        if (medEspecialidades[i].Equals(
                especialidadBuscada,
                StringComparison.OrdinalIgnoreCase)
            &&
            medDisponibilidades[i] == "Disponible")
        {
            return i;
        }
    }

    return -1;
}


// ------------------------------------------------------------
// CONSULTAR CITAS POR PACIENTE
// ------------------------------------------------------------

void ConsultarCitasPorPaciente()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("       CITAS POR PACIENTE");
    Console.WriteLine("==============================================");

    Console.Write("Cédula del paciente: ");
    string cedula = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaCedulaPac[i] == cedula)
        {
            MostrarCita(i);
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("\nNo existen citas para este paciente.");
    }

    Console.ReadKey();
}


// ------------------------------------------------------------
// CONSULTAR CITAS POR MÉDICO
// ------------------------------------------------------------

void ConsultarCitasPorMedico()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("         CITAS POR MÉDICO");
    Console.WriteLine("==============================================");

    Console.Write("Código del médico: ");
    string codigo = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaCodMed[i] == codigo)
        {
            MostrarCita(i);
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("\nNo existen citas para este médico.");
    }

    Console.ReadKey();
}


// ------------------------------------------------------------
// CONSULTAR CITAS POR FECHA
// ------------------------------------------------------------

void ConsultarCitasPorFecha()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          CITAS POR FECHA");
    Console.WriteLine("==============================================");

    Console.Write("Fecha (YYYY-MM-DD): ");
    string fecha = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaFecha[i] == fecha)
        {
            MostrarCita(i);
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("\nNo existen citas para esa fecha.");
    }

    Console.ReadKey();
}


// ------------------------------------------------------------
// MOSTRAR UNA CITA
// ------------------------------------------------------------

void MostrarCita(int indice)
{
    Console.WriteLine("----------------------------------------------");

    Console.WriteLine(
        $"Paciente      : {citaCedulaPac[indice]}"
    );

    Console.WriteLine(
        $"Médico        : {citaCodMed[indice]}"
    );

    Console.WriteLine(
        $"Especialidad  : {citaEspecialidad[indice]}"
    );

    Console.WriteLine(
        $"Fecha         : {citaFecha[indice]}"
    );

    Console.WriteLine(
        $"Hora          : {citaHora[indice]}"
    );

    Console.WriteLine(
        $"Motivo        : {citaMotivo[indice]}"
    );

    Console.WriteLine(
        $"Estado        : {citaEstado[indice]}"
    );
}


// ------------------------------------------------------------
// MODIFICAR ESTADO DE CITA
// ------------------------------------------------------------

void ModificarEstadoCita()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          ESTADO DE CITA");
    Console.WriteLine("==============================================");

    Console.Write("Cédula del paciente: ");
    string cedula = Console.ReadLine();

    bool encontrada = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaCedulaPac[i] == cedula &&
            citaEstado[i] != "Cancelada" &&
            citaEstado[i] != "Atendida")
        {
            encontrada = true;

            Console.WriteLine("\nCita encontrada:");
            MostrarCita(i);

            Console.WriteLine("\nSeleccione nuevo estado:");
            Console.WriteLine("1. Confirmada");
            Console.WriteLine("2. Atendida");
            Console.WriteLine("3. Cancelada");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    citaEstado[i] = "Confirmada";
                    Console.WriteLine(
                        "\n[OK] Cita confirmada."
                    );
                    break;

                case "2":
                    citaEstado[i] = "Atendida";

                    // El médico queda disponible nuevamente
                    int indiceMedico =
                        BuscarMedicoPorCodigo(citaCodMed[i]);

                    if (indiceMedico != -1)
                    {
                        medDisponibilidades[indiceMedico] =
                            "Disponible";

                        medPacientesAtendidos[indiceMedico]++;
                    }

                    Console.WriteLine(
                        "\n[OK] Cita marcada como atendida."
                    );
                    break;

                case "3":
                    citaEstado[i] = "Cancelada";

                    Console.WriteLine(
                        "\n[OK] Cita cancelada."
                    );
                    break;

                default:
                    Console.WriteLine(
                        "\n[Error] Opción inválida."
                    );
                    break;
            }

            break;
        }
    }

    if (!encontrada)
    {
        Console.WriteLine(
            "\nNo se encontró una cita modificable para esa cédula."
        );
    }

    Console.ReadKey();
}


// ------------------------------------------------------------
// CONSULTAR TODAS LAS CITAS
// ------------------------------------------------------------

void ConsultarTodasLasCitas()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("            AGENDA GENERAL");
    Console.WriteLine("==============================================");

    if (totalCitas == 0)
    {
        Console.WriteLine("No hay citas registradas.");
    }
    else
    {
        for (int i = 0; i < totalCitas; i++)
        {
            MostrarCita(i);
        }
    }

    Console.ReadKey();
}


// ============================================================
// 4. MÓDULO DE EMERGENCIAS
// ============================================================

void MenuEmergencias()
{
    int opcion = 0;

    do
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("       SALA DE EMERGENCIAS Y TRIAGE");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Ingresar paciente por emergencia");
        Console.WriteLine("2. Atender paciente en cola");
        Console.WriteLine("3. Ver cola de emergencias");
        Console.WriteLine("4. Regresar al menú principal");
        Console.WriteLine("==============================================");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("\n[Error] Ingrese un número válido.");
            Console.ReadKey();
            continue;
        }

        switch (opcion)
        {
            case 1:
                IngresarEmergencia();
                break;

            case 2:
                AtenderEmergencia();
                break;

            case 3:
                VerColaEmergencias();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("\n[Error] Opción no válida.");
                Console.ReadKey();
                break;
        }

    } while (opcion != 4);
}


// ------------------------------------------------------------
// INGRESAR EMERGENCIA
// ------------------------------------------------------------

void IngresarEmergencia()
{
    if (totalEmergencias >= MAX)
    {
        Console.WriteLine(
            "\n[Error] Capacidad máxima de emergencias alcanzada."
        );

        Console.ReadKey();
        return;
    }

    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("       INGRESO A SALA DE EMERGENCIAS");
    Console.WriteLine("==============================================");

    Console.Write("Cédula del paciente: ");
    string cedula = Console.ReadLine();

    int indicePaciente =
        BuscarPacienteRecursivo(cedula, 0);

    if (indicePaciente == -1)
    {
        Console.WriteLine(
            "\n[Error] El paciente no está registrado."
        );

        Console.ReadKey();
        return;
    }


    // --------------------------------------------------------
    // Verificar que no tenga otra emergencia pendiente
    // --------------------------------------------------------

    if (PacienteTieneEmergenciaPendiente(cedula))
    {
        Console.WriteLine(
            "\n[Error] El paciente ya tiene una emergencia pendiente."
        );

        Console.ReadKey();
        return;
    }


    // --------------------------------------------------------
    // Prioridad
    // --------------------------------------------------------

    int prioridad;

    Console.WriteLine("\nNIVEL DE PRIORIDAD");
    Console.WriteLine("1. Crítico");
    Console.WriteLine("2. Urgente");
    Console.WriteLine("3. Moderado");
    Console.WriteLine("4. Leve");

    Console.Write("Seleccione prioridad (1-4): ");

    while (!int.TryParse(Console.ReadLine(), out prioridad) ||
           prioridad < 1 ||
           prioridad > 4)
    {
        Console.Write(
            "Prioridad inválida. Ingrese un valor de 1 a 4: "
        );
    }


    // --------------------------------------------------------
    // Especialidad requerida
    // --------------------------------------------------------

    string especialidad;

    do
    {
        Console.Write("Especialidad requerida: ");
        especialidad = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(especialidad))
        {
            Console.WriteLine(
                "[Error] Debe indicar una especialidad."
            );
        }

    } while (string.IsNullOrWhiteSpace(especialidad));


    // --------------------------------------------------------
    // Buscar médico disponible
    // --------------------------------------------------------

    int indiceMedico =
        BuscarMedicoDisponiblePorEspecialidad(
            especialidad
        );

    string codigoMedico = "Sin asignar";

    if (indiceMedico != -1)
    {
        codigoMedico = medCodigos[indiceMedico];

        medDisponibilidades[indiceMedico] = "Ocupado";

        Console.WriteLine(
            $"\nMédico asignado: " +
            $"{medNombres[indiceMedico]} " +
            $"[{codigoMedico}]"
        );
    }
    else
    {
        Console.WriteLine(
            "\n[Advertencia] No hay médico disponible " +
            "para esta especialidad en este momento."
        );

        Console.WriteLine(
            "El paciente quedará pendiente hasta que exista disponibilidad."
        );
    }


    // --------------------------------------------------------
    // Registrar emergencia
    // --------------------------------------------------------

    emeCedulaPac[totalEmergencias] = cedula;

    emePrioridad[totalEmergencias] = prioridad;

    emeEspecialidadRequerida[totalEmergencias] =
        especialidad;

    emeFechaHoraLlegada[totalEmergencias] =
        DateTime.Now;

    emeTiempoEspera[totalEmergencias] = 0;

    emeCodMedAsignado[totalEmergencias] =
        codigoMedico;

    emeEstado[totalEmergencias] = "Pendiente";

    totalEmergencias++;


    // --------------------------------------------------------
    // Ordenar automáticamente
    // --------------------------------------------------------

    OrdenarColaEmergenciasPorPrioridad();

    Console.WriteLine(
        "\n[OK] Paciente ingresado correctamente a emergencias."
    );

    Console.ReadKey();
}


// ------------------------------------------------------------
// VERIFICAR EMERGENCIA PENDIENTE
// ------------------------------------------------------------

bool PacienteTieneEmergenciaPendiente(string cedula)
{
    for (int i = 0; i < totalEmergencias; i++)
    {
        if (emeCedulaPac[i] == cedula &&
            emeEstado[i] == "Pendiente")
        {
            return true;
        }
    }

    return false;
}


// ------------------------------------------------------------
// ORDENAR COLA DE EMERGENCIAS
// ------------------------------------------------------------

void OrdenarColaEmergenciasPorPrioridad()
{
    for (int i = 0;
         i < totalEmergencias - 1;
         i++)
    {
        for (int j = 0;
             j < totalEmergencias - i - 1;
             j++)
        {
            // Solo intercambiamos si la prioridad siguiente
            // es más alta.
            //
            // Si son iguales NO intercambiamos.
            // Esto conserva el orden de llegada.

            if (emePrioridad[j] > emePrioridad[j + 1])
            {
                IntercambiarTexto(
                    ref emeCedulaPac[j],
                    ref emeCedulaPac[j + 1]
                );

                IntercambiarEnteros(
                    ref emePrioridad[j],
                    ref emePrioridad[j + 1]
                );

                IntercambiarTexto(
                    ref emeEspecialidadRequerida[j],
                    ref emeEspecialidadRequerida[j + 1]
                );

                IntercambiarDateTime(
                    ref emeFechaHoraLlegada[j],
                    ref emeFechaHoraLlegada[j + 1]
                );

                IntercambiarEnteros(
                    ref emeTiempoEspera[j],
                    ref emeTiempoEspera[j + 1]
                );

                IntercambiarTexto(
                    ref emeCodMedAsignado[j],
                    ref emeCodMedAsignado[j + 1]
                );

                IntercambiarTexto(
                    ref emeEstado[j],
                    ref emeEstado[j + 1]
                );
            }
        }
    }
}


// ------------------------------------------------------------
// FUNCIONES AUXILIARES DE INTERCAMBIO
// ------------------------------------------------------------

void IntercambiarTexto(ref string a, ref string b)
{
    string temporal = a;
    a = b;
    b = temporal;
}


void IntercambiarEnteros(ref int a, ref int b)
{
    int temporal = a;
    a = b;
    b = temporal;
}


void IntercambiarDateTime(
    ref DateTime a,
    ref DateTime b)
{
    DateTime temporal = a;
    a = b;
    b = temporal;
}


// ------------------------------------------------------------
// ATENDER EMERGENCIA
// ------------------------------------------------------------

void AtenderEmergencia()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("           ATENCIÓN DE EMERGENCIAS");
    Console.WriteLine("==============================================");


    // --------------------------------------------------------
    // Buscar al primer paciente pendiente.
    // Como la cola está ordenada, será el de mayor prioridad.
    // --------------------------------------------------------

    int indiceAtender = -1;

    for (int i = 0; i < totalEmergencias; i++)
    {
        if (emeEstado[i] == "Pendiente")
        {
            indiceAtender = i;
            break;
        }
    }


    if (indiceAtender == -1)
    {
        Console.WriteLine(
            "No hay pacientes pendientes."
        );

        Console.ReadKey();
        return;
    }


    // --------------------------------------------------------
    // Calcular tiempo de espera real
    // --------------------------------------------------------

    TimeSpan diferencia =
        DateTime.Now -
        emeFechaHoraLlegada[indiceAtender];

    int minutosEspera =
        (int)diferencia.TotalMinutes;

    emeTiempoEspera[indiceAtender] =
        minutosEspera;


    Console.WriteLine(
        $"\nPaciente atendido: " +
        $"{emeCedulaPac[indiceAtender]}"
    );

    Console.WriteLine(
        $"Prioridad: Nivel {emePrioridad[indiceAtender]}"
    );

    Console.WriteLine(
        $"Especialidad: " +
        $"{emeEspecialidadRequerida[indiceAtender]}"
    );

    Console.WriteLine(
        $"Médico: " +
        $"{emeCodMedAsignado[indiceAtender]}"
    );

    Console.WriteLine(
        $"Tiempo de espera: " +
        $"{emeTiempoEspera[indiceAtender]} minutos"
    );


    // --------------------------------------------------------
    // Liberar médico
    // --------------------------------------------------------

    if (emeCodMedAsignado[indiceAtender] != "Sin asignar")
    {
        int indiceMedico =
            BuscarMedicoPorCodigo(
                emeCodMedAsignado[indiceAtender]
            );

        if (indiceMedico != -1)
        {
            medDisponibilidades[indiceMedico] =
                "Disponible";

            medPacientesAtendidos[indiceMedico]++;
        }
    }


    // --------------------------------------------------------
    // Marcar como atendido
    // --------------------------------------------------------

    emeEstado[indiceAtender] = "Atendido";


    Console.WriteLine(
        "\n[OK] Emergencia atendida correctamente."
    );


    // --------------------------------------------------------
    // RETIRAR DE LA COLA
    // --------------------------------------------------------

    EliminarEmergenciaDeCola(indiceAtender);

    Console.WriteLine(
        "\nLa cola de emergencias ha sido actualizada."
    );

    Console.ReadKey();
}


// ------------------------------------------------------------
// ELIMINAR EMERGENCIA ATENDIDA
// ------------------------------------------------------------

void EliminarEmergenciaDeCola(int indiceEliminar)
{
    for (int i = indiceEliminar;
         i < totalEmergencias - 1;
         i++)
    {
        emeCedulaPac[i] =
            emeCedulaPac[i + 1];

        emePrioridad[i] =
            emePrioridad[i + 1];

        emeEspecialidadRequerida[i] =
            emeEspecialidadRequerida[i + 1];

        emeFechaHoraLlegada[i] =
            emeFechaHoraLlegada[i + 1];

        emeTiempoEspera[i] =
            emeTiempoEspera[i + 1];

        emeCodMedAsignado[i] =
            emeCodMedAsignado[i + 1];

        emeEstado[i] =
            emeEstado[i + 1];
    }

    totalEmergencias--;

    // Limpiar última posición
    int ultimo = totalEmergencias;

    emeCedulaPac[ultimo] = null;
    emePrioridad[ultimo] = 0;
    emeEspecialidadRequerida[ultimo] = null;
    emeFechaHoraLlegada[ultimo] = default;
    emeTiempoEspera[ultimo] = 0;
    emeCodMedAsignado[ultimo] = null;
    emeEstado[ultimo] = null;
}


// ------------------------------------------------------------
// VER COLA DE EMERGENCIAS
// ------------------------------------------------------------

void VerColaEmergencias()
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("          COLA DE EMERGENCIAS");
    Console.WriteLine("==============================================");

    if (totalEmergencias == 0)
    {
        Console.WriteLine(
            "No existen pacientes pendientes."
        );
    }
    else
    {
        for (int i = 0; i < totalEmergencias; i++)
        {
            Console.WriteLine(
                $"{i + 1}. " +
                $"Paciente: {emeCedulaPac[i]} | " +
                $"Prioridad: {emePrioridad[i]} | " +
                $"Especialidad: {emeEspecialidadRequerida[i]} | " +
                $"Llegada: {emeFechaHoraLlegada[i]:HH:mm:ss} | " +
                $"Médico: {emeCodMedAsignado[i]} | " +
                $"Estado: {emeEstado[i]}"
            );
        }
    }

    Console.WriteLine("\nPresione una tecla...");
    Console.ReadKey();
}