using Enternet_Shop.Infrastructure.Mappers;
using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Enternet_Shop.Infrastructure.Database
{
    public class ProductRepository
    {
        public List<ProductViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Products.ToList();
                return ProductMapper.Map(items);
            }
        }
        public ProductViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Products.FirstOrDefault(x => x.ID == id);
                return ProductMapper.Map(item);
            }
        }
        public ProductViewModel Add(ProductViewModel entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Cost = entity.Cost;
            entity.Quanity = entity.Quanity;
            using (var context = new Context())
            {
                var item = ProductMapper.Map(entity);
                context.Products.Add(item);
                if (item != null)
                {
                    item.Name = entity.Name;
                    item.Cost = entity.Cost;
                    item.Quanity = entity.Quanity;
                    context.Products.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProductMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Products.FirstOrDefault(x => x.ID == id);
                if (user != null)
                {
                    context.Products.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public ProductViewModel Update(ProductViewModel entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Cost = entity.Cost;
            entity.Quanity = entity.Quanity;
            if (string.IsNullOrEmpty(entity.Name))
                throw new Exception("Поля не могут быть пустыми");

            using (var context = new Context())
            {
                var item = context.Products.FirstOrDefault(x => x.ID == entity.ID);
                if (item != null)
                {
                    item.Name = entity.Name;
                    item.Cost = entity.Cost;
                    item.Quanity = entity.Quanity;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProductMapper.Map(item);
            }
        }
        public List<ProductViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Products
                    .Where(x => x.Name.ToLower().Contains(search))
                    .ToList();

                return ProductMapper.Map(result);
            }
        }
    }
}
