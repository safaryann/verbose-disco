using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class WarehouseRepository
    {
        public List<WarehouseEntity> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Warehouses.ToList();
                return items;
            }
        }
        public WarehouseEntity GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Warehouses.FirstOrDefault(x => x.ID == id);
                return item;
            }
        }

    }
}
