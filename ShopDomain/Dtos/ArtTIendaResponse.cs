using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDomain.Dtos
{
    public class ArtTIendaResponse
    {
        
        public int Id { get; set; }
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public string TiendasBranch  { get; set; }
        public int ArticuloId { get; set; }
        public string  ArticuloCode { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
