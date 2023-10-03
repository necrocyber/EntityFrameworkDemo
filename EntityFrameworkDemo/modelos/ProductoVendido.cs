using System;
namespace EntityFrameworkDemo
{
	public class ProductoVendido
	{
		public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Stock { get; set; }
        public int IdSale { get; set; }
    }
}