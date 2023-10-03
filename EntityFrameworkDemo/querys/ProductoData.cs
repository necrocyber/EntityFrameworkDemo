using System;
using System.Text;
using System.Xml.Linq;

namespace EntityFrameworkDemo
{
	public class ProductoData
	{
        public static void ObtenerProducto(int find_id) {
            using (var context = new ConectionContext())
            {
                var producto = context.Productos.Where(prod => prod.Id == find_id).Single();
                var data = new StringBuilder();
                data.AppendLine($"Descripciones: {producto.Descripciones}");
                data.AppendLine($"Costo: {producto.Costo}");
                data.AppendLine($"Stock: {producto.Stock}");
                Console.WriteLine(data.ToString());
            }
        }

        public static void ListarProductos() {
            using (var context = new ConectionContext())
            {
                var productos = context.Productos;
                foreach (var producto in productos)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Descripciones: {producto.Descripciones}");
                    data.AppendLine($"Costo: {producto.Costo}");
                    data.AppendLine($"Stock: {producto.Stock}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        public static void CrearProducto(Productos producto) {
            using (var context = new ConectionContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }

        public static void ModificarProducto(int find_id, string description) {
            using (var context = new ConectionContext())
            {
                var result = context.Productos.SingleOrDefault(b => b.Id == find_id);
                if (result != null)
                {
                    result.Descripciones = description;
                    context.SaveChanges();
                }
            }
        }
        public static void EliminarProducto(int find_id) {
            using (var context = new ConectionContext())
            {
                var itemToRemove = context.Productos.SingleOrDefault(x => x.Id == find_id);

                if (itemToRemove != null)
                {
                    context.Productos.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
        }

    }
}

