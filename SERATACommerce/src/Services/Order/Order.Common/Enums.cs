using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common
{
    public class Enums
    {
        public enum OrderStatus 
        {
            pending,aproved,cancell
        
        }

        public enum OrderPayment
        {
            CrediCArd,Paypal,BankTransfer

        }
    }
}
