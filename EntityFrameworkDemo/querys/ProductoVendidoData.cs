using System;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class ProductoVendidoData
    {
        public static void ObtenerProductoVendido(int find_id) {
            using (var context = new ConectionContext())
            {
                var productoVendido = context.ProductoVendido.Where(prod => prod.Id == find_id).Single();
                var data = new StringBuilder();
                data.AppendLine($"ID: {productoVendido.IdProduct}");
                data.AppendLine($"Stock: {productoVendido.Stock}");
                data.AppendLine($"Id Venta: {productoVendido.IdSale}");
                Console.WriteLine(data.ToString());
            }
        }

        public static void ListarProductoVendido() {
            using (var context = new ConectionContext())
            {
                var productoVendido = context.ProductoVendido;
                foreach (var producto in productoVendido)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id Producto: {producto.IdProduct}");
                    data.AppendLine($"Stock: {producto.Stock}");
                    data.AppendLine($"Id Venta: {producto.IdSale}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido) {
            using (var context = new ConectionContext())
            {
                context.ProductoVendido.Add(productoVendido);
                context.SaveChanges();
            }
        }

        public static void ModificarProductoVendido(int find_id, int stock) {
            using (var context = new ConectionContext())
            {
                var result = context.ProductoVendido.SingleOrDefault(b => b.Id == find_id);
                if (result != null)
                {
                    result.Stock = stock;
                    context.SaveChanges();
                }
            }
        }

        public static void EliminarProductoVendido(int find_id) {
            using (var context = new ConectionContext())
            {
                var itemToRemove = context.ProductoVendido.SingleOrDefault(x => x.Id == find_id);

                if (itemToRemove != null)
                {
                    context.ProductoVendido.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
        }
    }
}