using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LBSoftWebApi.Data.Entities
{
    public class Account
    {
        [Required]
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public double Balance { get; set; }

        public bool PossibilityOfPayment { get; set; }
    }
}
