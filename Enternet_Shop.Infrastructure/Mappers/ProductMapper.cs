using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel Map(ProductEntity entity)
        {
            var viewModel = new ProductViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
                Cost = entity.Cost,
                Quanity = entity.Quanity
            };
            return viewModel;
        }
        public static List<ProductViewModel> Map(List<ProductEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static ProductEntity Map(ProductViewModel viewModel)
        {
            var entity = new ProductEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                Cost = viewModel.Cost,
                Quanity = viewModel.Quanity
            };
            return entity;
        }
    }
}
