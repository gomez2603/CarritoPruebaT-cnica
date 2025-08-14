using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId  { get; set; }  
        public virtual Clientes cliente { get; set; }
        [ForeignKey("ArticuloId")]
        public int ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}
