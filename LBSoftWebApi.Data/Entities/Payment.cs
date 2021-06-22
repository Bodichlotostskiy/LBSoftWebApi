using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LBSoftWebApi.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        
        public int PaymentNumber { get; set; }

        public int Recipient { get; set; }

        public Account AccountRecipient { get; set; }

        public double Amount { get; set; }

        public Status Status { get; set; }
    }
}
