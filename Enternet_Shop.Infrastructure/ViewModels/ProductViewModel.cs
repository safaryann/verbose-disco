using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.ViewModels
{
    public class ProductViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long Cost { get; set; }
        public long Quanity { get; set; }
    }
}
