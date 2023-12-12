using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class InternetShopRepository
    {
        public List<InternetShopEntity> GetList()
        {
            using (var context = new Context())
            {
                var items = context.InternetShops.ToList();
                return items;
            }
        }
        public InternetShopEntity GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.InternetShops.FirstOrDefault(x => x.ID == id);
                return item;
            }
        }

    }
}
