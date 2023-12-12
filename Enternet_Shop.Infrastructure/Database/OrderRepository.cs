using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class OrderRepository
    {
        public List<OrderEntity> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Orders.ToList();
                return items;
            }
        }
        public OrderEntity GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Orders.FirstOrDefault(x => x.ID == id);
                return item;
            }
        }

    }
}
