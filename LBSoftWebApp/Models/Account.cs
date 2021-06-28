using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBSoftWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public double Balance { get; set; }

        public bool PossibilityOfPayment { get; set; }
    }
}
