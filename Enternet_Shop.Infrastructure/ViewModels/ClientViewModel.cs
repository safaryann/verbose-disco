using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.ViewModels
{
    public class ClientViewModel
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string post { get; set; }
        public string PostId { get; set; }
    }
}
