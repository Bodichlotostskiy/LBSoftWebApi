using LBSoftWebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Infrastructure.Models
{
    public class PaymentModel
    {

        public int Id { get; set; }

        public int PaymentNumber { get; set; }

        public int Recipient { get; set; }

        public double Amount { get; set; }

        public Status Status { get; set; }
    }
}
