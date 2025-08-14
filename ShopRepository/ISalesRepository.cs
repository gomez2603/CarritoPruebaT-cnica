using ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository
{
    public interface ISalesRepository :IBaseRepository<Sales>
    {
        void Update(Sales sales);
    }
}
