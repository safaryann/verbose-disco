using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class StatusRepository
    {
        public List<StatusEntity> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Status.ToList();
                return items;
            }
        }
        public StatusEntity GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Status.FirstOrDefault(x => x.ID == id);
                return item;
            }
        }

    }
}
