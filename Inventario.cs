using InventarioGestions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventarioGestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace InventarioGestions
    {
        public class Inventario
        {
            private List<Producto> productos = new List<Producto>();

            public void AgregarProducto(Producto producto)
            {
                productos.Add(producto);
                Console.WriteLine("Producto agregado correctamente.");
            }

            public void ActualizarPrecio(string nombre, double nuevoPrecio)
            {
                var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (producto != null)
                {
                    producto.Precio = nuevoPrecio;
                    Console.WriteLine($"Precio de '{nombre}' actualizado a {nuevoPrecio:C}");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }

            public void EliminarProducto(string nombre)
            {
                var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (producto != null)
                {
                    productos.Remove(producto);
                    Console.WriteLine($"Producto '{nombre}' eliminado.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }

            public void FiltrarYOrdenarProducto()
            {
                Console.WriteLine("\nIngrese el precio mínimo para filtrar los productos:");
                double precioMinimo = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el precio máximo para filtrar los productos:");
                double precioMaximo = Convert.ToDouble(Console.ReadLine());

                if (precioMaximo < precioMinimo)
                {
                    Console.WriteLine("El precio máximo no puede ser menor que el precio mínimo. Intenta de nuevo.");
                    return;
                }

                var productosFiltrados = productos
                    .Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo)
                    .OrderBy(p => p.Precio);

                if (!productosFiltrados.Any())
                {
                    Console.WriteLine($"No se encontraron productos con precios entre {precioMinimo:C} y {precioMaximo:C}.");
                }
                else
                {
                    Console.WriteLine("\nProductos filtrados y ordenados por precio:");
                    foreach (var producto in productosFiltrados)
                    {
                        producto.MostrarInformacion();
                    }
                }
            }

            public void VerProductos()
            {
                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos en el inventario.");
                }
                else
                {
                    Console.WriteLine("\nLista de productos en el inventario:");
                    foreach (var producto in productos)
                    {
                        producto.MostrarInformacion();
                    }
                }
            }
        }
    }

}
