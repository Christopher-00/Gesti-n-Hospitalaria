using System;

const int MAX = 100;

// =====================================================
// ARREGLOS PARALELOS
// =====================================================

// PACIENTES
string[] pacNombre = new string[MAX];
string[] pacCedula = new string[MAX];
int[] pacEdad = new int[MAX];
string[] pacSexo = new string[MAX];
string[] pacDireccion = new string[MAX];
string[] pacTelefono = new string[MAX];
string[] pacIngreso = new string[MAX];
int totalPacientes = 0;

// MEDICOS
string[] medNombre = new string[MAX];
string[] medEspecialidad = new string[MAX];
string[] medCodigo = new string[MAX];
string[] medEstado = new string[MAX];
int[] medAtendidos = new int[MAX];
int totalMedicos = 0;

// CITAS
string[] citaPaciente = new string[MAX];
string[] citaMedico = new string[MAX];
string[] citaFecha = new string[MAX];
string[] citaHora = new string[MAX];
string[] citaMotivo = new string[MAX];
string[] citaEstado = new string[MAX];
int totalCitas = 0;

// EMERGENCIAS
string[] emePaciente = new string[MAX];
string[] emeEspecialidad = new string[MAX];
int[] emePrioridad = new int[MAX];
string[] emeHora = new string[MAX];
int[] emeEspera = new int[MAX];
string[] emeMedico = new string[MAX];
string[] emeEstado = new string[MAX];
int totalEmergencias = 0;

// ATENCIONES (Punto 3.5)
string[] atenPaciente = new string[MAX];
string[] atenMedico = new string[MAX];
string[] atenFecha = new string[MAX];
string[] atenDiagnostico = new string[MAX];
string[] atenTratamiento = new string[MAX];
string[] atenMedicamentos = new string[MAX];
string[] atenEstadoPost = new string[MAX];
int totalAtenciones = 0;


// =====================================================
// PROGRAMA PRINCIPAL
// =====================================================

PrecargarDatos();

int opcion;

do
{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("       SISTEMA DE GESTION HOSPITALARIA");
    Console.WriteLine("==============================================");
    Console.WriteLine("1. Pacientes");
    Console.WriteLine("2. Medicos");
    Console.WriteLine("3. Citas");
    Console.WriteLine("4. Emergencias");
    Console.WriteLine("5. Registrar atencion");
    Console.WriteLine("6. Historial medico");
    Console.WriteLine("7. Estadisticas");
    Console.WriteLine("8. Reportes");
    Console.WriteLine("9. Salir");
    Console.WriteLine("==============================================");

    opcion = LeerEntero("Seleccione una opcion: ", 1, 9);

    switch (opcion)
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
            MenuAtenciones();
            break;
        case 6:
            MenuHistorial();
            break;
        case 7:
            MenuEstadisticas();
            break;
        case 8:
            MenuReportes();
            break;
        case 9:
            Console.WriteLine("Sistema finalizado.");
            break;
    }

} while (opcion != 9);


// =====================================================
// VALIDACIONES GENERALES
// =====================================================

int LeerEntero(string mensaje, int min, int max)
{
    int valor;

    do
    {
        Console.Write(mensaje);

        if (int.TryParse(Console.ReadLine(), out valor) &&
            valor >= min && valor <= max)
            return valor;

        Console.WriteLine("Valor invalido.");
    }
    while (true);
}

string LeerTexto(string mensaje)
{
    string texto;

    do
    {
        Console.Write(mensaje);
        texto = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(texto))
            Console.WriteLine("El dato no puede estar vacio.");

    } while (string.IsNullOrWhiteSpace(texto));

    return texto.Trim();
}


// =====================================================
// DATOS INICIALES
// =====================================================

void PrecargarDatos()
{
    medNombre[0] = "Dr. Alejandro Martinez";
    medEspecialidad[0] = "Medicina General";
    medCodigo[0] = "MED-01";
    medEstado[0] = "Disponible";
    medAtendidos[0] = 1;

    medNombre[1] = "Dra. Carmen Rivas";
    medEspecialidad[1] = "Pediatria";
    medCodigo[1] = "MED-02";
    medEstado[1] = "Disponible";
    medAtendidos[1] = 1;

    medNombre[2] = "Dr. Fernando Ceron";
    medEspecialidad[2] = "Traumatologia";
    medCodigo[2] = "MED-03";
    medEstado[2] = "Disponible";
    medAtendidos[2] = 0;

    totalMedicos = 3;

    pacNombre[0] = "Mario Guevara";
    pacCedula[0] = "05241234-5";
    pacEdad[0] = 34;
    pacSexo[0] = "M";
    pacDireccion[0] = "Santa Ana Centro";
    pacTelefono[0] = "7890-1234";
    pacIngreso[0] = "2026-09-01 07:30";

    pacNombre[1] = "Lucia Beatriz ";
    pacCedula[1] = "04123987-1";
    pacEdad[1] = 28;
    pacSexo[1] = "F";
    pacDireccion[1] = "Santa Ana Centro";
    pacTelefono[1] = "7234-5678";
    pacIngreso[1] = "2026-09-05 10:15";

    totalPacientes = 2;

    // Citas precargadas
    citaPaciente[0] = "05241234-5";
    citaMedico[0] = "MED-01";
    citaFecha[0] = DateTime.Now.ToString("yyyy-MM-dd");
    citaHora[0] = "09:00";
    citaMotivo[0] = "Control anual";
    citaEstado[0] = "Pendiente";
    totalCitas = 1;

    // Atenciones iniciales de prueba
    atenPaciente[0] = "05241234-5";
    atenMedico[0] = "MED-01";
    atenFecha[0] = "2026-09-02 08:30";
    atenDiagnostico[0] = "Gripe comun";
    atenTratamiento[0] = "Reposo e hidratacion";
    atenMedicamentos[0] = "Paracetamol 500mg";
    atenEstadoPost[0] = "Dado de alta";

    atenPaciente[1] = "04123987-1";
    atenMedico[1] = "MED-02";
    atenFecha[1] = "2026-09-06 11:00";
    atenDiagnostico[1] = "Faringitis";
    atenTratamiento[1] = "Antibiotico 7 dias";
    atenMedicamentos[1] = "Amoxicilina 500mg";
    atenEstadoPost[1] = "Estable";

    totalAtenciones = 2;
}


// =====================================================
// 1. MODULO DE PACIENTES
// =====================================================

void MenuPacientes()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== PACIENTES =====");
        Console.WriteLine("1. Registrar paciente");
        Console.WriteLine("2. Buscar paciente");
        Console.WriteLine("3. Actualizar paciente");
        Console.WriteLine("4. Listar pacientes");
        Console.WriteLine("5. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 5);

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
        }

    } while (opcion != 5);
}

void RegistrarPaciente()
{
    if (totalPacientes >= MAX)
    {
        Console.WriteLine("No hay espacio disponible.");
        Console.ReadKey();
        return;
    }

    Console.Clear();

    string cedula = LeerTexto("Cedula/ID: ");

    if (BuscarPacienteRecursivo(cedula, 0) != -1)
    {
        Console.WriteLine("La cedula ya existe.");
        Console.ReadKey();
        return;
    }

    pacCedula[totalPacientes] = cedula;
    pacNombre[totalPacientes] = LeerTexto("Nombre: ");
    pacEdad[totalPacientes] = LeerEntero("Edad: ", 1, 120);

    do
    {
        pacSexo[totalPacientes] =
            LeerTexto("Sexo (M/F): ").ToUpper();

        if (pacSexo[totalPacientes] != "M" &&
            pacSexo[totalPacientes] != "F")
            Console.WriteLine("Ingrese M o F.");

    } while (pacSexo[totalPacientes] != "M" &&
             pacSexo[totalPacientes] != "F");

    pacDireccion[totalPacientes] =
        LeerTexto("Direccion: ");

    pacTelefono[totalPacientes] =
        LeerTexto("Telefono: ");

    pacIngreso[totalPacientes] =
        DateTime.Now.ToString("yyyy-MM-dd HH:mm");

    totalPacientes++;

    Console.WriteLine("Paciente registrado correctamente.");
    Console.ReadKey();
}

int BuscarPacienteRecursivo(string cedula, int posicion)
{
    if (posicion >= totalPacientes)
        return -1;

    if (pacCedula[posicion] == cedula)
        return posicion;

    return BuscarPacienteRecursivo(cedula, posicion + 1);
}

void BuscarPaciente()
{
    Console.Clear();

    string dato = LeerTexto("Cedula del paciente: ");

    int pos = BuscarPacienteRecursivo(dato, 0);

    if (pos == -1)
        Console.WriteLine("Paciente no encontrado.");
    else
        MostrarPaciente(pos);

    Console.ReadKey();
}

void MostrarPaciente(int pos)
{
    Console.WriteLine("\n===== DATOS DEL PACIENTE =====");
    Console.WriteLine($"Nombre: {pacNombre[pos]}");
    Console.WriteLine($"Cedula: {pacCedula[pos]}");
    Console.WriteLine($"Edad: {pacEdad[pos]}");
    Console.WriteLine($"Sexo: {pacSexo[pos]}");
    Console.WriteLine($"Direccion: {pacDireccion[pos]}");
    Console.WriteLine($"Telefono: {pacTelefono[pos]}");
    Console.WriteLine($"Ingreso: {pacIngreso[pos]}");
}

void ActualizarPaciente()
{
    Console.Clear();

    string cedula = LeerTexto("Cedula del paciente: ");
    int pos = BuscarPacienteRecursivo(cedula, 0);

    if (pos == -1)
    {
        Console.WriteLine("Paciente no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"Paciente: {pacNombre[pos]}");

    pacNombre[pos] = LeerTexto("Nuevo nombre: ");
    pacEdad[pos] = LeerEntero("Nueva edad: ", 1, 120);
    pacDireccion[pos] = LeerTexto("Nueva direccion: ");
    pacTelefono[pos] = LeerTexto("Nuevo telefono: ");

    Console.WriteLine("Paciente actualizado.");
    Console.ReadKey();
}

void ListarPacientes()
{
    Console.Clear();
    Console.WriteLine("===== LISTADO DE PACIENTES =====");

    for (int i = 0; i < totalPacientes; i++)
    {
        Console.WriteLine(
            $"{i + 1}. {pacNombre[i]} | " +
            $"{pacCedula[i]} | Edad: {pacEdad[i]}");
    }

    Console.ReadKey();
}


// =====================================================
// 2. MODULO DE MEDICOS
// =====================================================

void MenuMedicos()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== MEDICOS =====");
        Console.WriteLine("1. Registrar medico");
        Console.WriteLine("2. Buscar medico");
        Console.WriteLine("3. Actualizar medico");
        Console.WriteLine("4. Cambiar disponibilidad");
        Console.WriteLine("5. Listar medicos");
        Console.WriteLine("6. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 6);

        switch (opcion)
        {
            case 1:
                RegistrarMedico();
                break;
            case 2:
                BuscarMedico();
                break;
            case 3:
                ActualizarMedico();
                break;
            case 4:
                CambiarEstadoMedico();
                break;
            case 5:
                ListarMedicos();
                break;
        }

    } while (opcion != 6);
}

void RegistrarMedico()
{
    if (totalMedicos >= MAX)
        return;

    Console.Clear();

    string codigo = LeerTexto("Codigo del medico: ");

    if (BuscarMedicoRecursivo(codigo, 0) != -1)
    {
        Console.WriteLine("El codigo ya existe.");
        Console.ReadKey();
        return;
    }

    medCodigo[totalMedicos] = codigo;
    medNombre[totalMedicos] =
        LeerTexto("Nombre: ");

    medEspecialidad[totalMedicos] =
        LeerTexto("Especialidad: ");

    medEstado[totalMedicos] = "Disponible";
    medAtendidos[totalMedicos] = 0;

    totalMedicos++;

    Console.WriteLine("Medico registrado.");
    Console.ReadKey();
}

int BuscarMedicoRecursivo(string codigo, int posicion)
{
    if (posicion >= totalMedicos)
        return -1;

    if (medCodigo[posicion] == codigo)
        return posicion;

    return BuscarMedicoRecursivo(codigo, posicion + 1);
}

void BuscarMedico()
{
    Console.Clear();

    string codigo = LeerTexto("Codigo del medico: ");
    int pos = BuscarMedicoRecursivo(codigo, 0);

    if (pos == -1)
        Console.WriteLine("Medico no encontrado.");
    else
        MostrarMedico(pos);

    Console.ReadKey();
}

void MostrarMedico(int pos)
{
    Console.WriteLine("\n===== DATOS DEL MEDICO =====");
    Console.WriteLine($"Codigo: {medCodigo[pos]}");
    Console.WriteLine($"Nombre: {medNombre[pos]}");
    Console.WriteLine($"Especialidad: {medEspecialidad[pos]}");
    Console.WriteLine($"Estado: {medEstado[pos]}");
    Console.WriteLine($"Pacientes atendidos: {medAtendidos[pos]}");
}

void ActualizarMedico()
{
    Console.Clear();

    string codigo = LeerTexto("Codigo del medico: ");
    int pos = BuscarMedicoRecursivo(codigo, 0);

    if (pos == -1)
    {
        Console.WriteLine("Medico no encontrado.");
        Console.ReadKey();
        return;
    }

    medNombre[pos] = LeerTexto("Nuevo nombre: ");
    medEspecialidad[pos] =
        LeerTexto("Nueva especialidad: ");

    Console.WriteLine("Datos del medico actualizados.");
    Console.ReadKey();
}

void CambiarEstadoMedico()
{
    Console.Clear();

    string codigo = LeerTexto("Codigo del medico: ");
    int pos = BuscarMedicoRecursivo(codigo, 0);

    if (pos == -1)
    {
        Console.WriteLine("Medico no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("1. Disponible");
    Console.WriteLine("2. Ocupado");
    Console.WriteLine("3. Fuera de turno");

    int opcion = LeerEntero("Nuevo estado: ", 1, 3);

    medEstado[pos] =
        opcion == 1 ? "Disponible" :
        opcion == 2 ? "Ocupado" :
        "Fuera de turno";

    Console.WriteLine("Estado actualizado.");
    Console.ReadKey();
}

void ListarMedicos()
{
    Console.Clear();
    Console.WriteLine("===== LISTADO DE MEDICOS =====");

    for (int i = 0; i < totalMedicos; i++)
    {
        Console.WriteLine(
            $"{medCodigo[i]} | {medNombre[i]} | " +
            $"{medEspecialidad[i]} | {medEstado[i]} | " +
            $"Atendidos: {medAtendidos[i]}");
    }

    Console.ReadKey();
}


// =====================================================
// 3. MODULO DE CITAS
// =====================================================

void MenuCitas()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== CITAS =====");
        Console.WriteLine("1. Registrar cita");
        Console.WriteLine("2. Consultar citas");
        Console.WriteLine("3. Cambiar estado");
        Console.WriteLine("4. Cancelar cita");
        Console.WriteLine("5. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 5);

        switch (opcion)
        {
            case 1:
                RegistrarCita();
                break;
            case 2:
                ConsultarCitas();
                break;
            case 3:
                CambiarEstadoCita();
                break;
            case 4:
                CancelarCita();
                break;
        }

    } while (opcion != 5);
}

void RegistrarCita()
{
    if (totalCitas >= MAX)
        return;

    Console.Clear();

    string cedula =
        LeerTexto("Cedula del paciente: ");

    if (BuscarPacienteRecursivo(cedula, 0) == -1)
    {
        Console.WriteLine("Paciente no registrado.");
        Console.ReadKey();
        return;
    }

    string especialidad =
        LeerTexto("Especialidad requerida: ");

    int medico = -1;

    for (int i = 0; i < totalMedicos; i++)
    {
        if (medEspecialidad[i].Equals(
                especialidad,
                StringComparison.OrdinalIgnoreCase)
            && medEstado[i] == "Disponible")
        {
            medico = i;
            break;
        }
    }

    if (medico == -1)
    {
        Console.WriteLine(
            "No existe un medico disponible " +
            "para esa especialidad.");
        Console.ReadKey();
        return;
    }

    citaPaciente[totalCitas] = cedula;
    citaMedico[totalCitas] = medCodigo[medico];
    citaFecha[totalCitas] =
        LeerTexto("Fecha (AAAA-MM-DD): ");
    citaHora[totalCitas] =
        LeerTexto("Hora (HH:MM): ");
    citaMotivo[totalCitas] =
        LeerTexto("Motivo: ");

    citaEstado[totalCitas] = "Pendiente";
    totalCitas++;

    Console.WriteLine(
        $"Cita asignada al medico {medNombre[medico]}.");

    Console.ReadKey();
}

void ConsultarCitas()
{
    Console.Clear();

    Console.WriteLine("===== CONSULTAR CITAS =====");
    Console.WriteLine("1. Por paciente");
    Console.WriteLine("2. Por medico");
    Console.WriteLine("3. Por fecha");

    int opcion = LeerEntero("Opcion: ", 1, 3);
    string dato = LeerTexto("Dato a buscar: ");

    bool encontrado = false;

    for (int i = 0; i < totalCitas; i++)
    {
        bool coincide =
            opcion == 1 ? citaPaciente[i] == dato :
            opcion == 2 ? citaMedico[i] == dato :
            citaFecha[i] == dato;

        if (coincide)
        {
            Console.WriteLine(
                $"{citaFecha[i]} {citaHora[i]} | " +
                $"Paciente: {citaPaciente[i]} | " +
                $"Medico: {citaMedico[i]} | " +
                $"Motivo: {citaMotivo[i]} | " +
                $"Estado: {citaEstado[i]}");

            encontrado = true;
        }
    }

    if (!encontrado)
        Console.WriteLine("No se encontraron citas.");

    Console.ReadKey();
}

void CambiarEstadoCita()
{
    Console.Clear();

    string cedula =
        LeerTexto("Cedula del paciente: ");

    int pos = -1;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaPaciente[i] == cedula &&
            citaEstado[i] != "Cancelada")
        {
            pos = i;
            break;
        }
    }

    if (pos == -1)
    {
        Console.WriteLine("No se encontro una cita.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. Confirmada");
    Console.WriteLine("3. Atendida");

    int opcion = LeerEntero("Nuevo estado: ", 1, 3);

    citaEstado[pos] =
        opcion == 1 ? "Pendiente" :
        opcion == 2 ? "Confirmada" :
        "Atendida";

    Console.WriteLine("Estado actualizado.");
    Console.ReadKey();
}

void CancelarCita()
{
    Console.Clear();

    string cedula =
        LeerTexto("Cedula del paciente: ");

    bool encontrada = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaPaciente[i] == cedula &&
            citaEstado[i] != "Cancelada" &&
            citaEstado[i] != "Atendida")
        {
            citaEstado[i] = "Cancelada";
            encontrada = true;
            break;
        }
    }

    Console.WriteLine(
        encontrada
        ? "Cita cancelada correctamente."
        : "No se encontro una cita cancelable.");

    Console.ReadKey();
}


// =====================================================
// 4. MODULO DE EMERGENCIAS
// =====================================================

void MenuEmergencias()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== EMERGENCIAS Y TRIAGE =====");
        Console.WriteLine("1. Ingresar emergencia");
        Console.WriteLine("2. Atender siguiente");
        Console.WriteLine("3. Ver cola");
        Console.WriteLine("4. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 4);

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
        }

    } while (opcion != 4);
}

void IngresarEmergencia()
{
    if (totalEmergencias >= MAX)
        return;

    Console.Clear();

    string cedula =
        LeerTexto("Cedula del paciente: ");

    if (BuscarPacienteRecursivo(cedula, 0) == -1)
    {
        Console.WriteLine("Paciente no registrado.");
        Console.ReadKey();
        return;
    }

    string especialidad =
        LeerTexto("Especialidad requerida: ");

    int prioridad = LeerEntero(
        "Prioridad (1 Critico - 4 Leve): ", 1, 4);

    int medico = -1;

    for (int i = 0; i < totalMedicos; i++)
    {
        if (medEspecialidad[i].Equals(
                especialidad,
                StringComparison.OrdinalIgnoreCase)
            && medEstado[i] == "Disponible")
        {
            medico = i;
            break;
        }
    }

    string codigoMedico = "Sin asignar";

    if (medico != -1)
    {
        codigoMedico = medCodigo[medico];
        medEstado[medico] = "Ocupado";
    }

    emePaciente[totalEmergencias] = cedula;
    emeEspecialidad[totalEmergencias] = especialidad;
    emePrioridad[totalEmergencias] = prioridad;
    emeHora[totalEmergencias] =
        DateTime.Now.ToString("HH:mm:ss");

    emeEspera[totalEmergencias] = 0;
    emeMedico[totalEmergencias] = codigoMedico;
    emeEstado[totalEmergencias] = "Pendiente";

    totalEmergencias++;

    OrdenarEmergencias();

    Console.WriteLine(
        $"Emergencia registrada. Medico: {codigoMedico}");

    Console.ReadKey();
}

void OrdenarEmergencias()
{
    for (int i = 0; i < totalEmergencias - 1; i++)
    {
        for (int j = 0;
             j < totalEmergencias - i - 1;
             j++)
        {
            if (emePrioridad[j] > emePrioridad[j + 1])
            {
                Intercambiar(ref emePaciente[j],
                             ref emePaciente[j + 1]);

                Intercambiar(ref emeEspecialidad[j],
                             ref emeEspecialidad[j + 1]);

                Intercambiar(ref emePrioridad[j],
                             ref emePrioridad[j + 1]);

                Intercambiar(ref emeHora[j],
                             ref emeHora[j + 1]);

                Intercambiar(ref emeEspera[j],
                             ref emeEspera[j + 1]);

                Intercambiar(ref emeMedico[j],
                             ref emeMedico[j + 1]);

                Intercambiar(ref emeEstado[j],
                             ref emeEstado[j + 1]);
            }
        }
    }
}

void Intercambiar<T>(ref T a, ref T b)
{
    T temporal = a;
    a = b;
    b = temporal;
}

void AtenderEmergencia()
{
    Console.Clear();

    int pos = BuscarEmergenciaRecursivo(0);

    if (pos == -1)
    {
        Console.WriteLine("No hay pacientes pendientes.");
        Console.ReadKey();
        return;
    }

    DateTime llegada;

    if (DateTime.TryParse(emeHora[pos], out llegada))
        emeEspera[pos] =
            (int)(DateTime.Now - llegada).TotalMinutes;

    emeEstado[pos] = "Atendido";

    int medico = BuscarMedicoRecursivo(
        emeMedico[pos], 0);

    if (medico != -1)
    {
        medEstado[medico] = "Disponible";
        medAtendidos[medico]++;
    }

    Console.WriteLine("===== ATENCION DE EMERGENCIA =====");
    Console.WriteLine($"Paciente: {emePaciente[pos]}");
    Console.WriteLine($"Prioridad: {emePrioridad[pos]}");
    Console.WriteLine($"Especialidad: {emeEspecialidad[pos]}");
    Console.WriteLine($"Medico: {emeMedico[pos]}");
    Console.WriteLine($"Tiempo de espera: {emeEspera[pos]} minutos");

    Console.ReadKey();
}

int BuscarEmergenciaRecursivo(int posicion)
{
    if (posicion >= totalEmergencias)
        return -1;

    if (emeEstado[posicion] == "Pendiente")
        return posicion;

    return BuscarEmergenciaRecursivo(posicion + 1);
}

void VerColaEmergencias()
{
    Console.Clear();
    Console.WriteLine("===== COLA DE EMERGENCIAS =====");

    MostrarEmergenciasRecursivo(0);

    Console.ReadKey();
}

void MostrarEmergenciasRecursivo(int posicion)
{
    if (posicion >= totalEmergencias)
        return;

    Console.WriteLine(
        $"{posicion + 1}. " +
        $"Paciente: {emePaciente[posicion]} | " +
        $"Prioridad: {emePrioridad[posicion]} | " +
        $"Especialidad: {emeEspecialidad[posicion]} | " +
        $"Medico: {emeMedico[posicion]} | " +
        $"Estado: {emeEstado[posicion]} | " +
        $"Espera: {emeEspera[posicion]} min");

    MostrarEmergenciasRecursivo(posicion + 1);
}


// =====================================================
// 5. MODULO DE ATENCIONES
// =====================================================

void MenuAtenciones()
{
    Console.Clear();
    Console.WriteLine("===== REGISTRAR ATENCION MEDICA =====");

    if (totalAtenciones >= MAX)
    {
        Console.WriteLine("Capacidad maxima de atenciones alcanzada.");
        Console.ReadKey();
        return;
    }

    string cedula = LeerTexto("Cedula del paciente: ");
    int posPac = BuscarPacienteRecursivo(cedula, 0);

    if (posPac == -1)
    {
        Console.WriteLine("Paciente no encontrado en el sistema.");
        Console.ReadKey();
        return;
    }

    string codMedico = LeerTexto("Codigo del medico que atendio: ");
    int posMed = BuscarMedicoRecursivo(codMedico, 0);

    if (posMed == -1)
    {
        Console.WriteLine("Medico no encontrado.");
        Console.ReadKey();
        return;
    }

    atenPaciente[totalAtenciones] = cedula;
    atenMedico[totalAtenciones] = codMedico;
    atenFecha[totalAtenciones] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    atenDiagnostico[totalAtenciones] = LeerTexto("Diagnostico: ");
    atenTratamiento[totalAtenciones] = LeerTexto("Tratamiento indicado: ");
    atenMedicamentos[totalAtenciones] = LeerTexto("Medicamentos recetados: ");

    Console.WriteLine("Estado tras la atencion:");
    Console.WriteLine("1. Estable");
    Console.WriteLine("2. En observacion");
    Console.WriteLine("3. Dado de alta");
    Console.WriteLine("4. Remitido");
    int opcEstado = LeerEntero("Seleccione opcion: ", 1, 4);

    atenEstadoPost[totalAtenciones] =
        opcEstado == 1 ? "Estable" :
        opcEstado == 2 ? "En observacion" :
        opcEstado == 3 ? "Dado de alta" : "Remitido";

    // Actualiza contador de pacientes atendidos por el médico
    medAtendidos[posMed]++;
    totalAtenciones++;

    // Si el paciente tenía una cita pendiente o confirmada, se marca atendida
    for (int i = 0; i < totalCitas; i++)
    {
        if (citaPaciente[i] == cedula && (citaEstado[i] == "Pendiente" || citaEstado[i] == "Confirmada"))
        {
            citaEstado[i] = "Atendida";
            break;
        }
    }

    Console.WriteLine("\nAtencion medica registrada exitosamente.");
    Console.ReadKey();
}


// =====================================================
// 6. MODULO DE HISTORIAL MEDICO (Punto 3.6)
// =====================================================

void MenuHistorial()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== HISTORIAL MEDICO =====");
        Console.WriteLine("1. Consultar atenciones de un paciente");
        Console.WriteLine("2. Buscar diagnosticos especificos");
        Console.WriteLine("3. Ver tratamientos previos de un paciente");
        Console.WriteLine("4. Total de consultas de un paciente");
        Console.WriteLine("5. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 5);

        switch (opcion)
        {
            case 1:
                ConsultarAtencionesPaciente();
                break;
            case 2:
                BuscarDiagnosticosHistorial();
                break;
            case 3:
                MostrarTratamientosPaciente();
                break;
            case 4:
                ContarConsultasPaciente();
                break;
        }

    } while (opcion != 5);
}

void ConsultarAtencionesPaciente()
{
    Console.Clear();
    string cedula = LeerTexto("Cedula del paciente: ");

    if (BuscarPacienteRecursivo(cedula, 0) == -1)
    {
        Console.WriteLine("El paciente no existe en el sistema.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"\n--- HISTORIAL DE ATENCIONES PARA: {cedula} ---");
    bool encontrado = false;
    RecorrerHistorialRecursivo(cedula, 0, ref encontrado);

    if (!encontrado)
        Console.WriteLine("No se encontraron registros medicos para este paciente.");

    Console.ReadKey();
}

// Recorrido recursivo del historial médico de un paciente
void RecorrerHistorialRecursivo(string cedula, int posicion, ref bool encontrado)
{
    if (posicion >= totalAtenciones)
        return;

    if (atenPaciente[posicion].Equals(cedula, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"\nRegistro #{posicion + 1}");
        Console.WriteLine($"Fecha: {atenFecha[posicion]}");
        Console.WriteLine($"Medico: {atenMedico[posicion]}");
        Console.WriteLine($"Diagnostico: {atenDiagnostico[posicion]}");
        Console.WriteLine($"Tratamiento: {atenTratamiento[posicion]}");
        Console.WriteLine($"Medicamentos: {atenMedicamentos[posicion]}");
        Console.WriteLine($"Estado: {atenEstadoPost[posicion]}");
        encontrado = true;
    }

    RecorrerHistorialRecursivo(cedula, posicion + 1, ref encontrado);
}

void BuscarDiagnosticosHistorial()
{
    Console.Clear();
    string termino = LeerTexto("Termino de diagnostico a buscar: ");
    bool encontrado = false;

    Console.WriteLine($"\n--- RESULTADOS PARA EL DIAGNOSTICO: '{termino}' ---");
    for (int i = 0; i < totalAtenciones; i++)
    {
        if (atenDiagnostico[i].IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            Console.WriteLine($"Paciente: {atenPaciente[i]} | Fecha: {atenFecha[i]} | Diagnostico: {atenDiagnostico[i]} | Medico: {atenMedico[i]}");
            encontrado = true;
        }
    }

    if (!encontrado)
        Console.WriteLine("No se hallaron coincidencias en los diagnosticos.");

    Console.ReadKey();
}

void MostrarTratamientosPaciente()
{
    Console.Clear();
    string cedula = LeerTexto("Cedula del paciente: ");
    bool encontrado = false;

    Console.WriteLine($"\n--- TRATAMIENTOS PREVIOS ({cedula}) ---");
    for (int i = 0; i < totalAtenciones; i++)
    {
        if (atenPaciente[i].Equals(cedula, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Fecha: {atenFecha[i]} | Diagnostico: {atenDiagnostico[i]}");
            Console.WriteLine($"Tratamiento: {atenTratamiento[i]}");
            Console.WriteLine($"Medicamentos: {atenMedicamentos[i]}");
            Console.WriteLine("---------------------------------------------");
            encontrado = true;
        }
    }

    if (!encontrado)
        Console.WriteLine("No se encontraron tratamientos previos.");

    Console.ReadKey();
}

void ContarConsultasPaciente()
{
    Console.Clear();
    string cedula = LeerTexto("Cedula del paciente: ");
    int consultas = ContarConsultasRecursivo(cedula, 0);

    Console.WriteLine($"\nEl paciente con cedula {cedula} ha tenido {consultas} consulta(s) en total.");
    Console.ReadKey();
}

// Función recursiva para contar consultas de un paciente
int ContarConsultasRecursivo(string cedula, int posicion)
{
    if (posicion >= totalAtenciones)
        return 0;

    int coincide = atenPaciente[posicion].Equals(cedula, StringComparison.OrdinalIgnoreCase) ? 1 : 0;
    return coincide + ContarConsultasRecursivo(cedula, posicion + 1);
}


// =====================================================
// 7. MODULO DE ESTADISTICAS (Punto 3.7)
// =====================================================

void MenuEstadisticas()
{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("           ESTADISTICAS DEL HOSPITAL");
    Console.WriteLine("==============================================");

    MostrarMedicoMasAtenciones();
    MostrarEspecialidadMayorDemanda();
    MostrarPromedioEdadPacientes();
    MostrarPacientesAtendidosPorDia();
    MostrarPromedioEsperaEmergencias();
    MostrarDiagnosticoMasFrecuente();

    Console.WriteLine("==============================================");
    Console.ReadKey();
}

void MostrarMedicoMasAtenciones()
{
    if (totalMedicos == 0)
    {
        Console.WriteLine("1. Medico con mayor pacientes: No hay datos.");
        return;
    }

    int mayorIndex = 0;
    for (int i = 1; i < totalMedicos; i++)
    {
        if (medAtendidos[i] > medAtendidos[mayorIndex])
            mayorIndex = i;
    }

    Console.WriteLine($"1. Medico con mayor pacientes atendidos: {medNombre[mayorIndex]} ({medAtendidos[mayorIndex]} pacientes)");
}

void MostrarEspecialidadMayorDemanda()
{
    if (totalCitas == 0 && totalEmergencias == 0)
    {
        Console.WriteLine("2. Especialidad con mayor demanda: Sin registros suficientes.");
        return;
    }

    // Tomar especialidades de médicos disponibles como catálogo base
    string mejorEsp = "No determinada";
    int maxDemanda = -1;

    for (int i = 0; i < totalMedicos; i++)
    {
        string esp = medEspecialidad[i];
        int conteo = 0;

        for (int c = 0; c < totalCitas; c++)
        {
            int posMed = BuscarMedicoRecursivo(citaMedico[c], 0);
            if (posMed != -1 && medEspecialidad[posMed].Equals(esp, StringComparison.OrdinalIgnoreCase))
                conteo++;
        }

        for (int e = 0; e < totalEmergencias; e++)
        {
            if (emeEspecialidad[e].Equals(esp, StringComparison.OrdinalIgnoreCase))
                conteo++;
        }

        if (conteo > maxDemanda)
        {
            maxDemanda = conteo;
            mejorEsp = esp;
        }
    }

    Console.WriteLine($"2. Especialidad con mayor demanda: {mejorEsp} ({maxDemanda} solicitudes entre citas/emergencias)");
}

void MostrarPromedioEdadPacientes()
{
    if (totalPacientes == 0)
    {
        Console.WriteLine("3. Promedio de edad: Sin pacientes.");
        return;
    }

    double suma = 0;
    for (int i = 0; i < totalPacientes; i++)
        suma += pacEdad[i];

    double promedio = suma / totalPacientes;
    Console.WriteLine($"3. Promedio de edad de pacientes registrados: {promedio:F1} anios");
}

void MostrarPacientesAtendidosPorDia()
{
    Console.WriteLine("4. Cantidad de atenciones por dia:");
    if (totalAtenciones == 0)
    {
        Console.WriteLine("   Sin atenciones registradas.");
        return;
    }

    string[] fechasUnicas = new string[MAX];
    int[] conteoFechas = new int[MAX];
    int totalFechas = 0;

    for (int i = 0; i < totalAtenciones; i++)
    {
        string fechaDia = atenFecha[i].Length >= 10 ? atenFecha[i].Substring(0, 10) : atenFecha[i];
        int pos = -1;

        for (int j = 0; j < totalFechas; j++)
        {
            if (fechasUnicas[j] == fechaDia)
            {
                pos = j;
                break;
            }
        }

        if (pos != -1)
            conteoFechas[pos]++;
        else
        {
            fechasUnicas[totalFechas] = fechaDia;
            conteoFechas[totalFechas] = 1;
            totalFechas++;
        }
    }

    for (int i = 0; i < totalFechas; i++)
        Console.WriteLine($"   * {fechasUnicas[i]}: {conteoFechas[i]} paciente(s)");
}

void MostrarPromedioEsperaEmergencias()
{
    int atendidas = 0;
    double sumaEspera = 0;

    for (int i = 0; i < totalEmergencias; i++)
    {
        if (emeEstado[i] == "Atendido")
        {
            sumaEspera += emeEspera[i];
            atendidas++;
        }
    }

    if (atendidas == 0)
        Console.WriteLine("5. Tiempo promedio de espera en emergencias: No hay emergencias atendidas aun.");
    else
        Console.WriteLine($"5. Tiempo promedio de espera en emergencias: {(sumaEspera / atendidas):F1} minutos");
}

void MostrarDiagnosticoMasFrecuente()
{
    if (totalAtenciones == 0)
    {
        Console.WriteLine("6. Diagnostico mas frecuente: No hay datos.");
        return;
    }

    string masFrecuente = atenDiagnostico[0];
    int maxOcurrencias = 0;

    for (int i = 0; i < totalAtenciones; i++)
    {
        int cuenta = 0;
        for (int j = 0; j < totalAtenciones; j++)
        {
            if (atenDiagnostico[i].Equals(atenDiagnostico[j], StringComparison.OrdinalIgnoreCase))
                cuenta++;
        }

        if (cuenta > maxOcurrencias)
        {
            maxOcurrencias = cuenta;
            masFrecuente = atenDiagnostico[i];
        }
    }

    Console.WriteLine($"6. Diagnostico mas frecuente: {masFrecuente} ({maxOcurrencias} veces)");
}


// =====================================================
// 8. MODULO DE REPORTES (Punto 3.8)
// =====================================================

void MenuReportes()
{
    int opcion;

    do
    {
        Console.Clear();
        Console.WriteLine("===== REPORTES GENERALES =====");
        Console.WriteLine("1. Pacientes pendientes por atender");
        Console.WriteLine("2. Emergencias pendientes por prioridad (Recursivo)");
        Console.WriteLine("3. Citas programadas para el dia de hoy");
        Console.WriteLine("4. Medicos disponibles");
        Console.WriteLine("5. Resumen general del hospital");
        Console.WriteLine("6. Regresar");

        opcion = LeerEntero("Opcion: ", 1, 6);

        switch (opcion)
        {
            case 1:
                ReportePacientesPendientes();
                break;
            case 2:
                ReporteEmergenciasPendientes();
                break;
            case 3:
                ReporteCitasDelDia();
                break;
            case 4:
                ReporteMedicosDisponibles();
                break;
            case 5:
                ReporteResumenHospital();
                break;
        }

    } while (opcion != 6);
}

void ReportePacientesPendientes()
{
    Console.Clear();
    Console.WriteLine("===== PACIENTES PENDIENTES (CITAS Y EMERGENCIAS) =====");
    bool hayPendientes = false;

    Console.WriteLine("\n-- Citas Pendientes/Confirmadas --");
    for (int i = 0; i < totalCitas; i++)
    {
        if (citaEstado[i] == "Pendiente" || citaEstado[i] == "Confirmada")
        {
            Console.WriteLine($"Cita Fecha: {citaFecha[i]} {citaHora[i]} | Paciente ID: {citaPaciente[i]} | Doctor: {citaMedico[i]} | Estado: {citaEstado[i]}");
            hayPendientes = true;
        }
    }

    Console.WriteLine("\n-- Emergencias en Espera --");
    for (int i = 0; i < totalEmergencias; i++)
    {
        if (emeEstado[i] == "Pendiente")
        {
            Console.WriteLine($"Prioridad {emePrioridad[i]} | Paciente ID: {emePaciente[i]} | Hora llegada: {emeHora[i]} | Especialidad: {emeEspecialidad[i]}");
            hayPendientes = true;
        }
    }

    if (!hayPendientes)
        Console.WriteLine("No hay pacientes en cola de atencion.");

    Console.ReadKey();
}

void ReporteEmergenciasPendientes()
{
    Console.Clear();
    Console.WriteLine("===== EMERGENCIAS PENDIENTES POR PRIORIDAD (RECURSIVO) =====");
    MostrarEmergenciasPendientesRecursivo(1);
    Console.ReadKey();
}

// Función recursiva por niveles de prioridad (1 al 4)
void MostrarEmergenciasPendientesRecursivo(int nivelPrioridad)
{
    if (nivelPrioridad > 4)
        return;

    string etiqueta = nivelPrioridad switch
    {
        1 => "Nivel 1 - Critico",
        2 => "Nivel 2 - Urgente",
        3 => "Nivel 3 - Moderado",
        _ => "Nivel 4 - Leve"
    };

    Console.WriteLine($"\n>>> {etiqueta} <<<");
    bool hay = false;

    for (int i = 0; i < totalEmergencias; i++)
    {
        if (emePrioridad[i] == nivelPrioridad && emeEstado[i] == "Pendiente")
        {
            Console.WriteLine($"   Paciente: {emePaciente[i]} | Especialidad: {emeEspecialidad[i]} | Hora de entrada: {emeHora[i]} | Medico: {emeMedico[i]}");
            hay = true;
        }
    }

    if (!hay)
        Console.WriteLine("   (Sin emergencias en este nivel)");

    MostrarEmergenciasPendientesRecursivo(nivelPrioridad + 1);
}

void ReporteCitasDelDia()
{
    Console.Clear();
    string hoy = DateTime.Now.ToString("yyyy-MM-dd");
    Console.WriteLine($"===== CITAS DEL DIA ({hoy}) =====");
    bool hay = false;

    for (int i = 0; i < totalCitas; i++)
    {
        if (citaFecha[i] == hoy)
        {
            Console.WriteLine($"Hora: {citaHora[i]} | Paciente: {citaPaciente[i]} | Medico: {citaMedico[i]} | Motivo: {citaMotivo[i]} | Estado: {citaEstado[i]}");
            hay = true;
        }
    }

    if (!hay)
        Console.WriteLine("No hay citas registradas para la fecha de hoy.");

    Console.ReadKey();
}

void ReporteMedicosDisponibles()
{
    Console.Clear();
    Console.WriteLine("===== MEDICOS DISPONIBLES EN TURNO =====");
    bool hay = false;

    for (int i = 0; i < totalMedicos; i++)
    {
        if (medEstado[i].Equals("Disponible", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Codigo: {medCodigo[i]} | Nombre: {medNombre[i]} | Especialidad: {medEspecialidad[i]} | Pacientes atendidos: {medAtendidos[i]}");
            hay = true;
        }
    }

    if (!hay)
        Console.WriteLine("No hay medicos en estado 'Disponible' en este momento.");

    Console.ReadKey();
}

void ReporteResumenHospital()
{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("          RESUMEN GENERAL DEL HOSPITAL");
    Console.WriteLine("==============================================");
    Console.WriteLine($"Total de pacientes registrados : {totalPacientes}");
    Console.WriteLine($"Total de medicos registrados    : {totalMedicos}");
    Console.WriteLine($"Total de citas gestionadas      : {totalCitas}");
    Console.WriteLine($"Total de emergencias ingresadas : {totalEmergencias}");
    Console.WriteLine($"Total de atenciones realizadas  : {totalAtenciones}");
    Console.WriteLine("==============================================");
    Console.ReadKey();
}
