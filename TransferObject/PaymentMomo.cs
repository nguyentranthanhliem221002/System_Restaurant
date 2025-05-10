using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class PaymentMomo
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string RequestId { get; set; }
        public string Amount { get; set; } 
        public string PayUrl { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public enum PaymentStatus
    {
        Success,
        Pending, 
        Cancel,  
        Failed  
    }

}
