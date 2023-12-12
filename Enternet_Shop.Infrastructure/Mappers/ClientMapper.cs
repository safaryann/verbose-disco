using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Mappers
{
    public static class ClientMapper
    {
        public static ClientViewModel Map(ClientEntity entity)
        {
            var viewModel = new ClientViewModel
            {
                ID = entity.ID,
                Login = entity.Login,
                Password = entity.Password,
                post = entity.post.Name,
                PostId = entity.PostId.ToString()
            };
            return viewModel;
        }
        public static List<ClientViewModel> Map(List<ClientEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static ClientEntity Map(ClientViewModel viewModel)
        {
            var entity = new ClientEntity
            {
                ID = viewModel.ID,
                Login = viewModel.Login,
                Password = viewModel.Password
            };
            return entity;
        }
    }
}
