using ListaLigadaLib;
using System;

namespace AppConsolaListas
{
    internal class Program
    {
        static ListaDobleLigada<string> lista = new ListaDobleLigada<string>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar modas");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Digite un dato: ");
                        lista.AdicionarOrdenado(Console.ReadLine());
                        break;

                    case 2:
                        foreach (var item in lista.MostrarAdelante())
                            Console.WriteLine(item);
                        Console.ReadKey();
                        break;

                    case 3:
                        foreach (var item in lista.MostrarAtras())
                            Console.WriteLine(item);
                        Console.ReadKey();
                        break;

                    case 4:
                        lista.OrdenarDesc();
                        Console.WriteLine("Ordenado descendentemente!");
                        Console.ReadKey();
                        break;

                    case 5:
                        var modas = lista.Modas();
                        Console.WriteLine("Moda(s):");
                        modas.ForEach(Console.WriteLine);
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("Grafico:");
                        foreach (var item in lista.Grafico())
                            Console.WriteLine($"{item.Key} {"".PadRight(item.Value, '*')}");
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.Write("Dato a buscar: ");
                        Console.WriteLine(lista.Existe(Console.ReadLine())
                            ? "¡Existe!" : "No existe.");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Write("Dato a eliminar: ");
                        Console.WriteLine(lista.EliminarUna(Console.ReadLine())
                            ? "Eliminado" : "No existe.");
                        Console.ReadKey();
                        break;

                    case 9:
                        Console.Write("Dato a eliminar: ");
                        int c = lista.EliminarTodas(Console.ReadLine());
                        Console.WriteLine($"Eliminadas: {c}");
                        Console.ReadKey();
                        break;

                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }
    }
}
