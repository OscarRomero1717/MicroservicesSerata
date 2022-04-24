using System;
using System.Collections.Generic;
using System.Text;
using static Order.Common.Enums;

namespace Product.QueryService.Dtos
{
    public class OrderClientDto
    {

        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public int ClientId { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Total { get; set; }

        public OrderPayment Payment { get; set; }

        public IEnumerable<OrderDetailDto> Items { get; set; }
    }
}
