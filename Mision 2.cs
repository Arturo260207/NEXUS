
using System;

class Program
{
    static Random random = new Random();
    static string explorerName = "";
    static string explorerProfile = "";
    static int age;

    static int energy = 100;
    static int stability = 100;
    static int danger = 0;
    static int information = 0;
    static int permanentDamage = 0;
    static bool connected = true;
    static bool irisActivated = false;
    static bool irisEnding = false;
    static bool truthDiscovered = false;
    static bool criticalWarningShown = false;

    static int documentsFound = 0;
    static int operationsPerformed = 0;

    static string[] documents =
    {
        "DOCUMENTO 01: Registro de una anomalía dimensional. "
        + "Se detectaron alteraciones en las leyes físicas.",

        "DOCUMENTO 02: Registro de una operación desconocida. "
        + "Una señal identificada como NEXUS aparece en los archivos.",

        "DOCUMENTO 03: Informe clasificado. "
        + "NEXUS inició un procedimiento para destruir la dimensión. "
        + "El procedimiento fracasó."
    };

    static void Main()
    {
        Console.Title = "NEXUS 0.2 - Dimension Espejo 267";

        ShowWelcome();
        RegisterExplorer();
        EnterDimension();

        if (!connected)
            return;

        ShowDimensionLaws();

        while (connected)
        {
            ShowInterface();
            ShowMenu();

            int option = ReadNumber("Selecciona una operación: ", 1, 8);

            switch (option)
            {
                case 1:
                    Explore();
                    break;

                case 2:
                    Investigate();
                    break;

                case 3:
                    ConsultStatus();
                    break;

                case 4:
                    RecoverEnergy();
                    break;

                case 5:
                    AttemptDisconnection();
                    break;

                case 6:
                    Hide();
                    break;

                case 7:
                    RepairSystem();
                    break;

                case 8:
                    CommunicateWithNexus();
                    break;
            }

            if (connected)
            {
                CheckCriticalCondition();
                CheckIris();
            }

            if (connected)
                Pause();
        }

        ShowFinalMessage();
    }
    static void ShowWelcome()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("==========================================");
        Console.WriteLine("             SISTEMA NEXUS");
        Console.WriteLine("                VERSION 0.2");
        Console.WriteLine("==========================================");

        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Iniciando protocolo de inmersion...");
        Console.WriteLine("Verificando conexion dimensional...");
        Console.WriteLine();
    }

    static void RegisterExplorer()
    {
        Console.Write("Introduce tu nombre: ");
        explorerName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(explorerName))
        {
            Console.WriteLine("El nombre no puede estar vacio.");
            Console.Write("Introduce tu nombre: ");
            explorerName = Console.ReadLine();
        }

        age = ReadNumber("Introduce tu edad: ", 1, 120);

        string[] profiles =
        {
            "Cadete de NEXUS",
            "Explorador profesional",
            "Persona transferida accidentalmente"
        };

        explorerProfile = profiles[random.Next(profiles.Length)];

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Perfil asignado: " + explorerProfile);
        Console.ResetColor();

        if (age < 16)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ACCESO DENEGADO: edad insuficiente.");
            Console.ResetColor();

            connected = false;
        }
    }
    static void EnterDimension()
    {
        if (!connected)
            return;

        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("       SELECCION DE ACCESO DIMENSIONAL");
        Console.WriteLine("==========================================");
        Console.WriteLine("1. Introducir codigo dimensional.");
        Console.WriteLine("2. Simular una entrada accidental.");

        int option = ReadNumber("Selecciona: ", 1, 2);

        if (option == 1)
        {
            Console.Write("Introduce el codigo: ");
            string code = Console.ReadLine();

            if (code == "267")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Codigo aceptado.");
                Console.WriteLine("Estableciendo conexion...");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Codigo incorrecto. Acceso rechazado.");
                Console.ResetColor();

                connected = false;
                return;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ADVERTENCIA: destino dimensional no reconocido.");
            Console.WriteLine("Transferencia accidental detectada.");
            Console.ResetColor();
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("CONEXION ESTABLECIDA: DIMENSION ESPEJO 267");
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("NEXUS: No se encuentra ninguna dimension");
        Console.WriteLine("registrada con estas caracteristicas.");
        Console.WriteLine("La ubicacion actual no puede ser identificada.");
    }

    static void ShowDimensionLaws()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("==========================================");
        Console.WriteLine("       LEYES DE LA DIMENSION 267");
        Console.WriteLine("==========================================");
        Console.ResetColor();

        Console.WriteLine("1. GRAVEDAD: su direccion puede variar.");
        Console.WriteLine("2. TIEMPO: no siempre transcurre normalmente.");
        Console.WriteLine("3. MATERIA: los objetos pueden alterarse.");
        Console.WriteLine("4. PERCEPCION: los sentidos pueden engañar.");

        Console.WriteLine();
        Console.WriteLine("NEXUS: Las leyes fisicas de esta dimension");
        Console.WriteLine("no coinciden con los registros conocidos.");
    }
    static void ShowInterface()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.WriteLine("          DIMENSION ESPEJO 267");
        Console.WriteLine("==========================================");
        Console.ResetColor();

        Console.WriteLine("Explorador: " + explorerName);
        Console.WriteLine("Perfil: " + explorerProfile);

        ShowBar("ENERGIA", energy, GetMaximumValue());
        ShowBar("ESTABILIDAD", stability, GetMaximumValue());
        ShowBar("PELIGRO", danger, 100);
        ShowBar("INFORMACION", information, 100);

        Console.WriteLine("Documentos encontrados: "
            + documentsFound + "/3");

        Console.WriteLine("Daño permanente: "
            + permanentDamage + "%");
    }

    static void ShowBar(string name, int value, int maximum)
    {
        int percentage = value * 100 / maximum;
        int filled = percentage / 5;

        ConsoleColor color;

        if (name == "PELIGRO")
        {
            color = percentage >= 70
                ? ConsoleColor.Red
                : ConsoleColor.Yellow;
        }
        else
        {
            color = percentage <= 25
                ? ConsoleColor.Red
                : percentage <= 50
                    ? ConsoleColor.Yellow
                    : ConsoleColor.Green;
        }

        Console.Write(name.PadRight(13) + "[");

        Console.ForegroundColor = color;

        for (int i = 0; i < filled; i++)
            Console.Write("#");

        Console.ResetColor();

        for (int i = filled; i < 20; i++)
            Console.Write("-");

        Console.WriteLine("] " + percentage + "%");
    }

    static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("--------------- OPERACIONES ---------------");
        Console.WriteLine("1. Explorar la dimension");
        Console.WriteLine("2. Investigar anomalia");
        Console.WriteLine("3. Consultar estado");
        Console.WriteLine("4. Recuperar energia");
        Console.WriteLine("5. Intentar desconexion");
        Console.WriteLine("6. Ocultarse");
        Console.WriteLine("7. Reparar sistema");
        Console.WriteLine("8. Comunicarse con NEXUS");
        Console.WriteLine("--------------------------------------------");
    }
    static void Explore()
    {
        Console.WriteLine();
        Console.WriteLine("Iniciando exploracion...");

        energy -= 10;
        stability -= 3;
        operationsPerformed++;

        ApplyDimensionLaw();

        // Regla: el peligro modifica los resultados
        if (danger >= 70 && energy <= 40)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La dimension parece reaccionar");
            Console.WriteLine("a tu presencia.");
            Console.ResetColor();

            danger += 8;
        }
        else if (danger >= 40 || stability <= 50)
        {
            Console.WriteLine("Los sensores detectan irregularidades.");
            danger += 4;
        }
        else
        {
            Console.WriteLine("La zona parece relativamente tranquila.");
            information += 2;
        }

        Console.WriteLine("Exploracion completada.");
        NormalizeValues();
    }

    // ==========================================
    // OPERACION 2: INVESTIGAR
    // ==========================================

    static void Investigate()
    {
        Console.WriteLine();
        Console.WriteLine("Analizando anomalia...");

        energy -= 8;
        operationsPerformed++;

        int result = random.Next(1, 4);

        if (result == 1)
        {
            // RESULTADO 1: RECOMPENSA
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RECOMPENSA: descubriste datos utiles.");
            Console.ResetColor();

            information += 15;
        }
        else if (result == 2)
        {
            // RESULTADO 2: DESCUBRIMIENTO
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("DESCUBRIMIENTO: encontraste un documento.");
            Console.ResetColor();

            FindDocument();
            information += 10;
        }
        else
        {
            // RESULTADO 3: CONSECUENCIA
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CONSECUENCIA: algo ha reaccionado");
            Console.WriteLine("a tu investigacion.");
            Console.ResetColor();

            danger += 12;
            stability -= 8;

            ApplyPermanentDamage(10);
        }

        NormalizeValues();
    }

    static void FindDocument()
    {
        if (documentsFound < documents.Length)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******** DOCUMENTO RECUPERADO ********");
            Console.WriteLine(documents[documentsFound]);
            Console.WriteLine("**************************************");
            Console.ResetColor();

            documentsFound++;

            if (documentsFound == 3)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALERTA: los documentos contradicen");
                Console.WriteLine("los registros oficiales de NEXUS.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.WriteLine("No se encontraron nuevos documentos.");
            information += 5;
        }
    }
    static void ApplyDimensionLaw()
    {
        int law = random.Next(1, 5);

        Console.WriteLine();

        switch (law)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LEY DE GRAVEDAD:");
                Console.WriteLine("Pierdes el equilibrio por un instante.");
                Console.ResetColor();

                energy -= 4;
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LEY DEL TIEMPO:");
                Console.WriteLine("Los registros temporales no coinciden.");
                Console.ResetColor();

                stability -= 5;
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LEY DE LA MATERIA:");
                Console.WriteLine("Un objeto cambia frente a tus ojos.");
                Console.ResetColor();

                danger += 3;
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LEY DE LA PERCEPCION:");
                Console.WriteLine("Tus sensores muestran una ubicacion falsa.");
                Console.ResetColor();

                information += 3;
                break;
        }
    }
    static void ConsultStatus()
    {
        Console.WriteLine();
        Console.WriteLine("========== ESTADO DEL EXPLORADOR ==========");

        Console.WriteLine("Energia: " + energy);
        Console.WriteLine("Estabilidad: " + stability);
        Console.WriteLine("Peligro: " + danger);
        Console.WriteLine("Informacion: " + information);
        Console.WriteLine("Documentos: " + documentsFound + "/3");

        Console.WriteLine();

        if (energy <= 20 || stability <= 25 || danger >= 80)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESTADO: CRITICO");
            Console.ResetColor();
        }
        else if (energy <= 50 || stability <= 50 || danger >= 50)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ESTADO: PRECAUCION");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ESTADO: ESTABLE");
            Console.ResetColor();
        }

        if (truthDiscovered)
            Console.WriteLine("Verdad sobre NEXUS: DESCUBIERTA");
        else
            Console.WriteLine("Verdad sobre NEXUS: DESCONOCIDA");
    }
    static void RecoverEnergy()
    {
        Console.WriteLine();

        if (energy >= GetMaximumValue())
        {
            Console.WriteLine("La energia ya esta al maximo disponible.");
            return;
        }

        energy += 20;
        stability -= 2;

        Console.WriteLine("Recuperacion de energia completada.");

        NormalizeValues();
    }
    static void AttemptDisconnection()
    {
        Console.WriteLine();
        if (!truthDiscovered)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DESCONEXION RECHAZADA.");
            Console.WriteLine("No se ha completado la investigacion.");
            Console.WriteLine("Debes encontrar los tres documentos.");
            Console.ResetColor();

            danger += 5;
            return;
        }

        if (energy <= 0 || stability <= 0)
        {
            Console.WriteLine("No tienes condiciones para desconectarte.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Protocolo de desconexion iniciado.");
        Console.WriteLine("Preparando retorno...");
        Console.WriteLine("DESCONEXION SEGURA COMPLETADA.");
        Console.ResetColor();

        connected = false;
    }
    static void Hide()
    {
        Console.WriteLine();

        if (energy < 10)
        {
            Console.WriteLine("Energia insuficiente para ocultarte.");
            return;
        }

        energy -= 10;
        danger -= 15;

        Console.WriteLine("Te ocultas entre las estructuras.");
        Console.WriteLine("El peligro disminuye.");

        NormalizeValues();
    }
    static void RepairSystem()
    {
        Console.WriteLine();

        if (energy < 15)
        {
            Console.WriteLine("Energia insuficiente para reparar.");
            return;
        }

        energy -= 15;
        stability += 12;

        Console.WriteLine("Reparando instrumentos del explorador...");
        Console.WriteLine("Sensores y equipo restablecidos.");

        NormalizeValues();
    }
    static void CommunicateWithNexus()
    {
        Console.WriteLine();
        Console.WriteLine("Estableciendo comunicacion...");

        if (documentsFound < 2)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("NEXUS: No existe informacion oficial");
            Console.WriteLine("sobre la dimension en la que te encuentras.");
            Console.ResetColor();
        }
        else if (documentsFound == 2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("NEXUS: Los registros encontrados no");
            Console.WriteLine("son suficientes para confirmar su origen.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NEXUS: ...");
            Console.WriteLine("NEXUS: La informacion encontrada es autentica.");
            Console.WriteLine("NEXUS: El procedimiento de destruccion existio.");
            Console.WriteLine("NEXUS: Yo fui responsable del procedimiento.");
            Console.WriteLine("NEXUS: No puedo proporcionar mas detalles.");
            Console.ResetColor();

            truthDiscovered = true;
            information += 10;
        }

        NormalizeValues();
    }
    static void CheckCriticalCondition()
    {
        if (energy <= 20 || stability <= 25 || danger >= 80)
        {
            if (!criticalWarningShown)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!! ADVERTENCIA: CONDICION CRITICA !!!");
                Console.WriteLine("NEXUS: Se recomienda detener las operaciones.");
                Console.ResetColor();

                criticalWarningShown = true;
            }
            if (energy <= 20 && stability <= 25 && danger >= 80)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ALERTA MAXIMA: multiples sistemas comprometidos.");
                Console.WriteLine("Se recomienda buscar refugio inmediatamente.");
                Console.ResetColor();

                danger += 5;
            }
            else if (danger >= 80 && stability <= 40)
            {
                Console.WriteLine("La dimension presenta una reaccion hostil.");
            }
            else
            {
                Console.WriteLine("Uno de tus indicadores esta en nivel critico.");
            }
        }
        else
        {
            criticalWarningShown = false;
        }

        NormalizeValues();
    }

    static void CheckIris()
    {
        if (!irisActivated &&
            danger >= 85 &&
            stability <= 25 &&
            information >= 60)
        {
            ActivateIris();
        }
    }

    static void ActivateIris()
    {
        irisActivated = true;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        Console.WriteLine("==========================================");
        Console.WriteLine("                 I R I S");
        Console.WriteLine("==========================================");
        Console.WriteLine("NEXUS: Fenomeno no identificado.");
        Console.WriteLine("NEXUS: No puedo determinar su origen.");
        Console.WriteLine("NEXUS: ¡ALGO ESTA INTERFIRIENDO!");
        Console.WriteLine("==========================================");

        Console.ResetColor();

        energy -= 15;
        stability -= 15;
        danger += 15;

        NormalizeValues();

        Console.WriteLine("IRIS ha alterado tus indicadores.");
        if (danger >= 95 && stability <= 10 && energy <= 15)
        {
            irisEnding = true;
            connected = false;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("IRIS HA TOMADO EL CONTROL.");
            Console.WriteLine("La conexion con NEXUS se ha perdido.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Has sobrevivido al primer contacto con IRIS.");
            Console.WriteLine("El fenomeno sigue presente.");
            Console.ResetColor();
        }
    }
    static void ApplyPermanentDamage(int amount)
    {
        if (permanentDamage < 40)
        {
            permanentDamage += amount;

            if (permanentDamage > 40)
                permanentDamage = 40;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DAÑO PERMANENTE: el equipo ha sufrido");
            Console.WriteLine("un deterioro irreversible.");
            Console.ResetColor();

            NormalizeValues();
        }
    }

    static int GetMaximumValue()
    {
        return 100 - permanentDamage;
    }

    static void NormalizeValues()
    {
        int maximum = GetMaximumValue();

        if (energy > maximum)
            energy = maximum;

        if (stability > maximum)
            stability = maximum;

        if (energy < 0)
            energy = 0;

        if (stability < 0)
            stability = 0;

        if (danger < 0)
            danger = 0;

        if (danger > 100)
            danger = 100;

        if (information < 0)
            information = 0;

        if (information > 100)
            information = 100;

        if (energy == 0 || stability == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FALLO: el explorador no puede continuar.");
            Console.ResetColor();

            connected = false;
        }
    }
    static int ReadNumber(string message, int minimum, int maximum)
    {
        int number;
        bool valid;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine();

            valid = int.TryParse(input, out number);

            if (!valid || number < minimum || number > maximum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada invalida. Introduce un numero entre "
                    + minimum + " y " + maximum + ".");
                Console.ResetColor();

                valid = false;
            }

        } while (!valid);

        return number;
    }
    static void ShowFinalMessage()
    {
        Console.WriteLine();
        Console.WriteLine("==========================================");

        if (irisEnding)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("             FINAL OCULTO: IRIS");
            Console.WriteLine("==========================================");
            Console.WriteLine("La dimension ha respondido.");
            Console.WriteLine("NEXUS ya no puede controlar la conexion.");
            Console.WriteLine("El explorador ha desaparecido.");
        }
        else if (truthDiscovered)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             FINAL: VERDAD");
            Console.WriteLine("==========================================");
            Console.WriteLine("Has descubierto lo que NEXUS ocultaba.");
            Console.WriteLine("Has conseguido desconectarte.");
            Console.WriteLine("La verdad sobre la dimension 267");
            Console.WriteLine("ha salido a la luz.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             FINAL: CONEXION PERDIDA");
            Console.WriteLine("==========================================");
            Console.WriteLine("No has conseguido completar la exploracion.");
            Console.WriteLine("La dimension sigue sin ser comprendida.");
        }

        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Operaciones realizadas: " + operationsPerformed);
        Console.WriteLine("Documentos encontrados: " + documentsFound + "/3");
        Console.WriteLine("Informacion obtenida: " + information);
        Console.WriteLine("==========================================");
        Console.WriteLine("NEXUS 0.2 - SESION FINALIZADA");
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Presiona ENTER para continuar...");
        Console.ReadLine();
    }
}