using Enternet_Shop.Infrastructure.Mappers;
using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class DeliveryRepository
    {
        public List<DeliveryViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Deliverys.ToList();
                return DeliveryMapper.Map(items);
            }
        }
        public DeliveryViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Deliverys.FirstOrDefault(x => x.ID == id);
                return DeliveryMapper.Map(item);
            }
        }
    }
}
