using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Entities
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; } = null;
        public int Stock { get; set; }
        public virtual ICollection<ArtTienda>? ArtTienda { get; set; }
        public virtual ICollection<Sales>? Sales { get; set; }

    }
}
