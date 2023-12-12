using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class PostRepository
    {
        public List<PostEntity> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Posts.ToList();
                return items;
            }
        }
        public PostEntity GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Posts.FirstOrDefault(x => x.PostID == id);
                return item;
            }
        }

    }
}
