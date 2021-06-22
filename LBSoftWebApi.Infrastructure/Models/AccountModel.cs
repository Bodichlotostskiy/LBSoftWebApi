using System;
using System.Collections.Generic;
using System.Text;

namespace LBSoftWebApi.Infrastructure.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public double Balance { get; set; }

        public bool PossibilityOfPayment { get; set; }
    }
}
