using System;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
	public class ConectionContext:DbContext
	{
		public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL("server=localhost;database=SistemaGestion;user=root;password=13483423");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error DataBase " , ex);
            }
            
        }

    }
}

