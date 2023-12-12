using Enternet_Shop.Infrastructure.Mappers;
using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;

namespace Enternet_Shop.Infrastructure.Database
{
    public class ClientRepository
    {
        public List<ClientViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Clients.ToList();
                return ClientMapper.Map(items);
            }
        }
        public ClientViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Clients.FirstOrDefault(x => x.ID == id);
                return ClientMapper.Map(item);
            }
        }
        public ClientViewModel ValidateAndGetUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль должны быть заполнены.");
                return null;
            }

            if (login.Length > 15 || password.Length > 16)
            {
                MessageBox.Show("Логин и пароль не может быть длиннее 15 символов.");
                return null;
            }

            if (!login.All(char.IsLetterOrDigit) || !password.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Логин и пароль могут содержать только буквы и цифры.");
                return null;
            }

            using (var context = new Context())
            {
                var item = context.Clients
                    .Include(x => x.post)
                    .FirstOrDefault(e => e.Login == login && e.Password == password);

                if (item == null)
                {
                    MessageBox.Show("Пользователь не найден. Пожалуйста, проверьте логин и пароль.");
                    return null;
                }

                return ClientMapper.Map(item);
            }
        }
    }
}
