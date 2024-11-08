using InventarioGestions;
using InventarioGestions.InventarioGestions;
using System;

namespace InventarioGestions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            int opcion;
            bool opcionValida = false;
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Menú de Gestión de Inventario ===");
                Console.WriteLine("1. Agregar Productos");
                Console.WriteLine("2. Actualizar Precio de Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Filtrar y Ordenar Productos");
                Console.WriteLine("5. Ver Productos");
                Console.WriteLine("6. Salir");
                Console.Write("Elige una opción (1-6): ");

                string input = Console.ReadLine();
                opcionValida = int.TryParse(input, out opcion);

                if (!opcionValida || opcion < 1 || opcion > 6)
                {
                    Console.WriteLine("Opción inválida. Debes ingresar un número entre 1 y 6.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;  
                }

                switch (opcion)
                {
                    case 1:
                      
                        Console.WriteLine("\nCuántos productos deseas agregar al inventario?");
                        int cantidadProductos;

                        while (true)
                        {
                            string cantidadInput = Console.ReadLine();
                            bool cantidadValida = int.TryParse(cantidadInput, out cantidadProductos);

                            if (cantidadValida && cantidadProductos > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Por favor, ingresa un número válido mayor que 0.");
                            }
                        }

                        for (int i = 0; i < cantidadProductos; i++)
                        {
                            Console.WriteLine($"\nProducto {i + 1}:");

                            Console.Write("Ingrese el nombre del producto: ");
                            string nombre = Console.ReadLine();

                            double precio;
                            while (true)
                            {
                                Console.Write("Ingrese el precio del producto: ");
                                string precioInput = Console.ReadLine();

                                if (double.TryParse(precioInput, out precio) && precio > 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Por favor, ingresa un precio válido mayor que 0.");
                                }
                            }

                            Producto nuevoProducto = new Producto(nombre, precio);
                            inventario.AgregarProducto(nuevoProducto);
                            Console.WriteLine($"Producto '{nombre}' agregado con éxito al inventario.");
                        }
                        break;

                    case 2:
                        
                        Console.WriteLine("\nActualizar Precio de Producto:");
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombreActualizar = Console.ReadLine();
                        Console.Write("Ingrese el nuevo precio: ");
                        double nuevoPrecio = Convert.ToDouble(Console.ReadLine());
                        inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                        break;

                    case 3:
                        
                        Console.WriteLine("\nEliminar Producto:");
                        Console.Write("Ingrese el nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        inventario.EliminarProducto(nombreEliminar);
                        break;

                    case 4:
                        
                        inventario.FiltrarYOrdenarProducto();
                        break;

                    case 5:
                       
                        inventario.VerProductos();
                        break;

                    case 6:
                        
                        Console.WriteLine("¡Hasta luego!");
                        continuar = false;  
                        break;

                    default:
                       
                        Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\n¿Quieres continuar?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No");
                    Console.Write("Elige una opción (1-2): ");

                    string respuestaInput = Console.ReadLine();

                    if (respuestaInput == "1")
                    {
                        continuar = true; 
                    }
                    else if (respuestaInput == "2")
                    {
                        Console.WriteLine("¡Hasta luego!");
                        continuar = false;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Saliendo...");
                        continuar = false; 
                    }
                }
            }
        }
    }
}
