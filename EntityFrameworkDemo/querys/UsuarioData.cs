using System;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
	public class UsuarioData
	{
		public static void ObtenerUsuario(int find_id)
		{
            using (var context = new ConectionContext())
            {
                var usuario = context.Usuarios.Where(user => user.Id == find_id).Single();
                var data = new StringBuilder();
                data.AppendLine($"Nombre: {usuario.Nombre}");
                data.AppendLine($"Apellido: {usuario.Apellido}");
                data.AppendLine($"NombreUsuario: {usuario.NombreUsuario}");
                Console.WriteLine(data.ToString());
            }
		}

		public static void ListarUsuarios()
		{
            using (var context = new ConectionContext())
            {
				var usuarios = context.Usuarios;
                foreach (var usuario in usuarios)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Nombre: {usuario.Nombre}");
                    data.AppendLine($"Apellido: {usuario.Apellido}");
                    data.AppendLine($"NombreUsuario: {usuario.NombreUsuario}");
                    Console.WriteLine(data.ToString());
                }
            }
		}

		public static void CrearUsuario(Usuarios usuario)
		{
			using (var context = new ConectionContext())
			{
				context.Usuarios.Add(usuario);
				context.SaveChanges();
			}
		}

		public static void ModificarUsuario(int find_id, string name)
		{
            using (var context = new ConectionContext())
            {
                var result = context.Usuarios.SingleOrDefault(b => b.Id == find_id);
                if (result != null)
                {
                    result.Nombre = name;
                    context.SaveChanges();
                }
            }
        }

        public static void EliminarUsuario(int find_id)
        {
            using (var context = new ConectionContext())
            {
                var itemToRemove = context.Usuarios.SingleOrDefault(x => x.Id == find_id);

                if (itemToRemove != null)
                {
                    context.Usuarios.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
            
        }
	}
}

