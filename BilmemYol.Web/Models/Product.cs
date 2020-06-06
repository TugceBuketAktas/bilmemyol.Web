using System;
namespace BilmemYol.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Brand { get; set; }
        public byte[] Image { get; set; }
        public int? CategoryId { get; set; }

    }
}
