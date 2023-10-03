using System;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class VentaData
    {
        public static void ObtenerVenta(int find_id) {
            using (var context = new ConectionContext())
            {
                var venta = context.Venta.Where(vnt => vnt.Id == find_id).Single();
                var data = new StringBuilder();
                data.AppendLine($"ID User: {venta.IdUser}");
                data.AppendLine($"Comentario: {venta.Comment}");
                data.AppendLine($"Id Venta: {venta.Id}");
                Console.WriteLine(data.ToString());
            }
        }

        public static void ListarVentas() {
            using (var context = new ConectionContext())
            {
                var venta = context.Venta;
                foreach (var vnt in venta)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ID User: {vnt.IdUser}");
                    data.AppendLine($"Comentario: {vnt.Comment}");
                    data.AppendLine($"Id Venta: {vnt.Id}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        public static void CrearVenta(Venta venta) {
            using (var context = new ConectionContext())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
            }
        }

        public static void ModificarVenta(int find_id, string comment) {
            using (var context = new ConectionContext())
            {
                var result = context.Venta.SingleOrDefault(b => b.Id == find_id);
                if (result != null)
                {
                    result.Comment = comment;
                    context.SaveChanges();
                }
            }
        }

        public static void EliminarVenta(int find_id) {
            using (var context = new ConectionContext())
            {
                var itemToRemove = context.Venta.SingleOrDefault(x => x.Id == find_id);

                if (itemToRemove != null)
                {
                    context.Venta.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
        }
    }
}