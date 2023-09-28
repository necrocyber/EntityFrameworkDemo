using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace EntityFrameworkDemo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Usuarios user = new Usuarios();

            // Creamos un Usuario

            Console.WriteLine("Ingresa un nuevo Usuario");
            Console.WriteLine("Nombre");
            user.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido");
            user.Apellido = Console.ReadLine();
            Console.WriteLine("NombreUsuario");
            user.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Password");
            user.Password = Console.ReadLine();
            Console.WriteLine("Email");
            user.Mail = Console.ReadLine();

            UsuarioData.CrearUsuario(user);

            // Obtenemos un Usuario por su ID

            Console.WriteLine("Ingresa el ID del Usuario");
            int Id = Convert.ToInt32(Console.ReadLine());
            UsuarioData.ObtenerUsuario(Id);

            // Listamos todos los Usuarios

            UsuarioData.ListarUsuarios();

            // Modificamos un Usuario

            UsuarioData.ModificarUsuario(2, "Pedrito");

            // Eliminamos un registro

            UsuarioData.EliminarUsuario(2);

            Console.ReadKey();
        }
    }
}