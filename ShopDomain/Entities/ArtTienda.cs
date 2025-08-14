using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Entities
{
    public class ArtTienda
    {
        public int Id { get; set; } 
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Tiendas Tiendas { get; set; }
        [ForeignKey("ArticuloId")]
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public DateTime Fecha { get; set; }  = DateTime.Now;
    }
}
