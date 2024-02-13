using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System;

class Program
{
    static int[] numerofactura = new int[15];
    static int[] numeroplaca = new int[15];
    static DateTime[] fecha = new DateTime[15];
    static TimeSpan[] hora = new TimeSpan[15];
    static int[] tipovehiculo = new int[15];
    static int[] numerocaseta = new int[15];
    static int[] montopagar = new int[15];
    static int[] montopagacliente = new int[15];
    static int[] vuelto = new int[15];
    static int indice = 0;

    //menu principal
    static void Main()
    {
        int opcion;
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("===Peaje de Verano===");
            Console.WriteLine("===Menu principal===");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehiculo");
            Console.WriteLine("3. Consultar numro de placa");
            Console.WriteLine("4. Modificar Datos del vehiculo por numero de placa");
            Console.WriteLine("5. Reporte datos de los vectores");
            Console.WriteLine("6. Salir");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    Ingresarpasovehiculo();
                    break;
                case 3:
                    Consultarnumeroplaca();
                    break;
                case 4:
                    Modificardatosporplaca();
                    break;
                case 5:
                    Reportedatos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 6.");
                    break;
            }
        } while (opcion != 6);
    }

    //Inicar vectores
    static void InicializarVectores()
    {
        for (int i = 0; i < 15; i++)
        {
            numerofactura[i] = 0;
            numeroplaca[i] = 0;
            fecha[i] = DateTime.MinValue;
            hora[i] = TimeSpan.MinValue;
            tipovehiculo[i] = 0;
            numerocaseta[i] = 0;
            montopagar[i] = 0;
            montopagacliente[i] = 0;
            vuelto[i] = 0;
        }
        indice = 0;
        Console.WriteLine("Vectores inicializados correctamente. Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    //Ingresar los datos del pago
    static void Ingresarpasovehiculo()
    {
        if (indice < 15)
        {
            Random rnd = new Random();
            Console.WriteLine("Digite los datos del vehículo:");

            Console.Write("Número de Factura: ");
            numerofactura[indice] = int.Parse(Console.ReadLine());

            Console.Write("Número de Placa: ");
            numeroplaca[indice] = int.Parse(Console.ReadLine());

            fecha[indice] = ObtenerFecha("Fecha (YYYY-MM-DD): ");
            hora[indice] = Obtenerhora("Hora (HH:MM): ");

            Console.Write("Tipo de Vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
            tipovehiculo[indice] = int.Parse(Console.ReadLine());

            Console.Write("Número de Caseta (1, 2, 3): ");
            numerocaseta[indice] = int.Parse(Console.ReadLine());

            // Calcular montos
            switch (tipovehiculo[indice])
            {
                case 1:
                    montopagar[indice] = 500;
                    break;
                case 2:
                    montopagar[indice] = 700;
                    break;
                case 3:
                    montopagar[indice] = 2700;
                    break;
                case 4:
                    montopagar[indice] = 3700;
                    break;
                default:
                    Console.WriteLine("Tipo de vehículo no válido.");
                    break;
            }

            Console.Write("Monto a Pagar: ");
            montopagar[indice] = int.Parse(Console.ReadLine());

            Console.Write("Monto Paga Cliente: ");
            montopagacliente[indice] = int.Parse(Console.ReadLine());

            Console.Write("Vuelto: ");
            vuelto[indice] = int.Parse(Console.ReadLine());

           
        }
    }

    //Consultar placa
    static void Consultarnumeroplaca()
    {
        Console.Write("Ingrese el número de placa a buscar: ");
        int placaBuscar = int.Parse(Console.ReadLine());
        bool encontrado = false;
        for (int i = 0; i < 15; i++)
        {
            if (numeroplaca[indice] == placaBuscar)
            {
                Console.WriteLine("Datos del vehículo:");
                Console.WriteLine($"Número de Factura:   |{numerofactura[i]}");
                Console.WriteLine($"Número de Placa:     |{numeroplaca[i]}");
                Console.WriteLine($"Fecha:               |{fecha[i]}");
                Console.WriteLine($"Hora:                |{hora[i]}");
                Console.WriteLine($"Tipo de Vehículo:    |{tipovehiculo[i]}");
                Console.WriteLine($"Número de Caseta:    |{numerocaseta[i]}");
                Console.WriteLine($"Monto a Pagar:       |{montopagar[i]}");
                Console.WriteLine($"Monto paga cliente:  |{montopagacliente[i]}");
                Console.WriteLine($"Vuelto:              |{vuelto[i]}");

                encontrado = true;
                break;
            }
        }
        if (!encontrado)
            Console.WriteLine("No se encontraron datos para la placa ingresada.");
    }

    //Modificar Datos
    static void Modificardatosporplaca()
    {
        Console.Write("Ingrese el número de placa a modificar: ");
        int placamodificar = int.Parse(Console.ReadLine());
        bool encontrado = false;

        for (int i = 0; i < 15; i++)
        {
            if (numeroplaca[indice] == placamodificar)
            {
                Console.WriteLine("Modificando datos del vehículo:");
                Console.WriteLine($"Número de Factura:  |{numerofactura[i]}");
                Console.WriteLine($"Número de Placa:    |{numeroplaca[i]}");
                Console.WriteLine($"Fecha:              |{fecha[i]}");
                Console.WriteLine($"Hora:               |{hora[i]}");
                Console.WriteLine($"Tipo de Vehículo:   |{tipovehiculo[i]}");
                Console.WriteLine($"Número de Caseta:   |{numerocaseta[i]}");
                Console.WriteLine($"Monto a Pagar:      |{montopagar[i]}");
                Console.WriteLine($"Monto paga cliente: |{montopagacliente[i]}");
                Console.WriteLine($"Vuelto:             |{vuelto[i]}");

                Console.WriteLine("Seleccione qué datos desea modificar:");
                Console.WriteLine("1. Número de Factura");
                Console.WriteLine("2. Número de Placa");
                Console.WriteLine("3. Fecha");
                Console.WriteLine("4. Hora");
                Console.WriteLine("5. Tipo de Vehículo");
                Console.WriteLine("6. Número de Caseta");
                Console.WriteLine("7. Monto a pagar");
                Console.WriteLine("8. Vuelto");
                Console.Write("Ingrese su opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nuevo Número de Factura: ");
                        numerofactura[i] = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Nuevo Número de Placa: ");
                        numeroplaca[i] = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        fecha[i] = ObtenerFecha("Nueva Fecha (YYYY-MM-DD): ");
                        break;
                    case 4:
                        hora[i] = Obtenerhora("Nueva Hora (HH:MM): ");
                        break;
                    case 5:
                        Console.Write("Nuevo Tipo de Vehículo: ");
                        tipovehiculo[i] = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Nuevo Número de Caseta: ");
                        numerocaseta[i] = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Nuevo Monto a Pagar: ");
                        montopagar[i] = int.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.Write("Nuevo Vuelto: ");
                        vuelto[i] = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("Datos modificados correctamente.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
            Console.WriteLine("No se encontraron datos para la placa ingresada.");
    }

    //Reporte de los datos
    static void Reportedatos()
    {
        Console.WriteLine("Reporte de Todos los Datos:");

        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine($"Vehículo             |{i + 1}:");
            Console.WriteLine($"Número de Factura:   |{numerofactura[i]}");
            Console.WriteLine($"Número de Placa:     |{numeroplaca[i]}");
            Console.WriteLine($"Fecha:               |{fecha[i]}");
            Console.WriteLine($"Hora:                |{hora[i]}");
            Console.WriteLine($"Tipo de Vehículo:    |{tipovehiculo[i]}");
            Console.WriteLine($"Número de Caseta:    |{numerocaseta[i]}");
            Console.WriteLine($"Monto a Pagar:       |{montopagar[i]}");
            Console.WriteLine($"Monto paga cliente:  |{montopagacliente[i]}");
            Console.WriteLine($"Vuelto:              |{vuelto[i]}");
            Console.WriteLine();
        }
    }

    static DateTime ObtenerFecha(string mensaje)
    {
        DateTime fecha;
        do
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (!DateTime.TryParse(entrada, out fecha))
            {
                Console.WriteLine("Fecha inválida. Por favor, ingrese una fecha en formato YYYY-MM-DD.");
                Console.WriteLine("Entrada recibida: '{entrada}'");
            }
            else
            {
                break;
            }
        } while (true);

        return fecha;
    }

    static TimeSpan Obtenerhora(string mensaje)
    {
        TimeSpan hora;
        do
        {
            Console.Write(mensaje);
            if (!TimeSpan.TryParse(Console.ReadLine(), out hora))
            {
                Console.WriteLine("Hora inválida.Por favor, ingrese una hora en formato hh:mm.");
                Console.Clear();
            }
            else
            {
                break;
            }
        } while (true);

        return hora;
    }
}
