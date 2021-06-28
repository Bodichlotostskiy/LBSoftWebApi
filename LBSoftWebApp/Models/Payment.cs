using LBSoftWebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBSoftWebApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int PaymentNumber { get; set; }

        public int Recipient { get; set; }

        public double Amount { get; set; }

        public Status Status { get; set; }
    }
}
