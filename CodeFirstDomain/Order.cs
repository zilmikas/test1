using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDomain
{
    public class Order :EntityBase
    {
        public int CustomerId { get; private set; }
        public string OrderNo { get; private set; }

        public decimal Amount { get; private set; }

        public Order()
        {
            
        }

        public Order(int customerId, string orderNo, decimal amount)
        {
            //CustomerId = customerId;
            OrderNo = orderNo;
            Amount = amount;
        }
    }
}
