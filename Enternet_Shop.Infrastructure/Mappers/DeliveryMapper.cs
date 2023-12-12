using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Mappers
{
    public static class DeliveryMapper
    {
        public static DeliveryViewModel Map(DeliveryEntity entity)
        {
            var viewModel = new DeliveryViewModel
            {
                ID = entity.ID,
                Adress = entity.Adress
            };
            return viewModel;
        }
        public static List<DeliveryViewModel> Map(List<DeliveryEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static DeliveryEntity Map(DeliveryViewModel viewModel)
        {
            var entity = new DeliveryEntity
            {
                ID = viewModel.ID,
                Adress = viewModel.Adress
            };
            return entity;
        }
    }
}
