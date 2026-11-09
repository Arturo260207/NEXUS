# NEXUS 0.2 — Dimensión Espejo 267

## 1. Descripción del proyecto
NEXUS 0.2 es una experiencia interactiva de exploración y supervivencia desarrollada en C# para consola. El jugador registra un explorador y llega a una dimensión desconocida mediante el código 267 o por una transferencia accidental.

La dimensión no fue creada por NEXUS. Los registros recuperables revelan que NEXUS intentó destruirla mediante un procedimiento que fracasó. La historia se descubre gradualmente a través de documentos, anomalías y comunicaciones con el sistema.

## 2. Objetivo
Desarrollar una aplicación de consola que permita explorar la Dimensión 267, tomar decisiones para mantener al explorador con vida, reunir pruebas y descubrir los secretos relacionados con NEXUS e IRIS.

Como ejercicio académico, el código permite estudiar variables, tipos de datos, métodos, arreglos, condicionales, ciclos, selección múltiple, validación de entradas y números aleatorios.

## 3. Funcionalidades principales
- Registro del explorador: solicita nombre y edad y asigna aleatoriamente uno de tres perfiles.
- Acceso dimensional: permite introducir el código 267 o simular una transferencia accidental.
- Dimensión Espejo 267: presenta cuatro leyes anómalas: gravedad, tiempo, materia y percepción.
- Exploración: consume energía y estabilidad, aplica una ley aleatoria y modifica los indicadores.
- Investigación: puede producir información, revelar documentos o provocar consecuencias perjudiciales.
- Documentos: tres registros revelan progresivamente la anomalía y el intento fallido de NEXUS de destruir la dimensión.
- Gestión de indicadores: energía, estabilidad, peligro, información y daño permanente.
- Supervivencia: recuperar energía, ocultarse para reducir el peligro y reparar el equipo.
- Comunicación con NEXUS: sus respuestas cambian según los documentos encontrados.
- IRIS: puede activarse cuando coinciden determinados valores de peligro, estabilidad e información.
- Finales: conexión perdida, verdad y final oculto de IRIS.

## 4. Indicadores
| Indicador | Función |
|---|---|
| Energía | Recurso necesario para continuar. |
| Estabilidad | Capacidad del explorador para soportar la dimensión. |
| Peligro | Nivel de amenaza de la dimensión. |
| Información | Conocimiento obtenido durante la exploración. |
| Daño permanente | Reduce el máximo posible de energía y estabilidad. |
| Documentos | Cuenta los tres registros recuperables. |

### Costos y efectos principales
| Acción | Efecto |
|---|---|
| Explorar | Energía −10 y estabilidad −3; aplica una ley dimensional aleatoria. |
| Investigar | Energía −8; puede aumentar información o peligro, reducir estabilidad y causar daño permanente. |
| Recuperar energía | Energía +20 y estabilidad −2, respetando el máximo permitido. |
| Ocultarse | Energía −10 y peligro −15. |
| Reparar sistema | Energía −15 y estabilidad +12. |
| Intentar desconexión | Requiere descubrir la verdad y conservar energía y estabilidad por encima de cero. |

El daño permanente tiene un límite de 40. El máximo de energía y estabilidad se calcula como 100 menos el daño permanente.

## 5. Tecnologías y requisitos
- Lenguaje: C#.
- Tipo de aplicación: consola.
- Framework configurado: .NET 10 (net10.0).
- Dependencias externas: no se requieren paquetes NuGet adicionales.
- Entorno recomendado: .NET 10 SDK o Visual Studio compatible.

## 6. Instalación y ejecución
1. Clona o descarga el repositorio.
2. Instala el SDK de .NET 10.
3. Abre una terminal en la carpeta raíz.
4. Ejecuta:

```bash
dotnet restore NEXUS.csproj
dotnet build NEXUS.csproj
dotnet run --project NEXUS.csproj
```

También puedes abrir NEXUS.csproj desde Visual Studio.

**Mision 2.cs es el archivo fuente principal.** El proyecto compila ese archivo directamente; no se renombra a Program.cs.

## 7. Menú de operaciones
| Opción | Operación |
|---|---|
| 1 | Explorar la dimensión |
| 2 | Investigar anomalía |
| 3 | Consultar estado |
| 4 | Recuperar energía |
| 5 | Intentar desconexión |
| 6 | Ocultarse |
| 7 | Reparar sistema |
| 8 | Comunicarse con NEXUS |

## 8. Organización del código
Todo el código de la versión actual está concentrado en Mision 2.cs. La clase Program contiene el punto de entrada Main(), los datos compartidos y los métodos de la aplicación.

| Método | Responsabilidad |
|---|---|
| Main() | Coordina el inicio, el ciclo de operaciones y el cierre. |
| RegisterExplorer() | Registra nombre y edad y asigna un perfil. |
| EnterDimension() | Gestiona el acceso mediante el código 267 o por accidente. |
| Explore() | Aplica costos de exploración y leyes dimensionales. |
| Investigate() | Ejecuta uno de los resultados aleatorios de investigación. |
| FindDocument() | Muestra el siguiente documento disponible. |
| ApplyDimensionLaw() | Aplica una de las cuatro leyes. |
| RecoverEnergy(), Hide(), RepairSystem() | Administran acciones de supervivencia. |
| CommunicateWithNexus() | Muestra respuestas según el avance documental. |
| CheckCriticalCondition(), CheckIris() | Comprueban condiciones especiales. |
| NormalizeValues() | Mantiene los indicadores dentro de sus límites. |
| ShowFinalMessage() | Presenta el desenlace y las estadísticas. |

La explicación detallada se encuentra en [la guía técnica](docs/Guia-tecnica-NEXUS-0.2.md).

## 9. Flujo general
1. Bienvenida y registro del explorador.
2. Elección del acceso dimensional.
3. Presentación de las leyes de la Dimensión 267.
4. Ciclo de interfaz, menú y ejecución de operaciones.
5. Comprobación de condiciones críticas y posible activación de IRIS.
6. Cierre de la conexión y presentación del final correspondiente.

## 10. Conceptos de programación presentes
La versión actual utiliza principalmente programación estructurada dentro de una clase contenedora:
- Variables y campos estáticos para representar el estado de la sesión.
- Métodos estáticos para dividir el programa en operaciones.
- if, else if y else para tomar decisiones.
- switch para procesar el menú y las leyes.
- while y do-while para mantener la sesión y validar entradas.
- Arreglos para almacenar perfiles y documentos.
- Random para seleccionar perfiles, resultados y leyes.

**Esta versión no implementa todavía** una arquitectura de clases de dominio, herencia, polimorfismo, interfaces, inventario orientado a objetos ni LINQ. Son posibles temas de evolución, no funcionalidades existentes.

## 11. Aspectos técnicos por revisar
- La clase Program concentra el estado y la lógica. Separar responsabilidades en clases podría facilitar el mantenimiento.
- La asignación de perfil es aleatoria y no depende de la edad ni de la forma de entrada.
- La exploración y la investigación tienen resultados aleatorios.
- La desconexión segura requiere descubrir la verdad mediante los tres documentos y la comunicación con NEXUS.
- El final oculto depende de la activación de IRIS y de las condiciones extremas posteriores.

## 12. Archivos principales
- Mision 2.cs: código fuente principal.
- NEXUS.csproj: configuración para compilar con .NET 10.
- README.md: presentación e instrucciones.
- docs/Guia-tecnica-NEXUS-0.2.md: guía técnica y material de estudio.
