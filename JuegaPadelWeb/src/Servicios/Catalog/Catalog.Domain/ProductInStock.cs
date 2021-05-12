using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain
{
    public class ProductInStock
    {
        public int ProductoEnStockId { get; set; }
        public int ProductoId { get; set; }
        public int Stock { get; set; }
        public object ProductInStockId { get; set; }
        public int ProductId { get; set; }
    }
}
