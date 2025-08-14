using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ShopDomain.Dtos
{
    public class CreateUpdateArticulo
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile? Image { get; set; } = null;
        public int Stock { get; set; }
    }
}
