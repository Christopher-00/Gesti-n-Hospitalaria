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

        case 6:

        case 7:

        case 8:

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
    medAtendidos[0] = 0;

    medNombre[1] = "Dra. Carmen Rivas";
    medEspecialidad[1] = "Pediatria";
    medCodigo[1] = "MED-02";
    medEstado[1] = "Disponible";
    medAtendidos[1] = 0;

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
    // Prioridad 1 primero.
    // Si dos pacientes tienen la misma prioridad,
    // no se intercambian y conservan orden de llegada.

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

// RECORRIDO RECURSIVO DE LA COLA
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