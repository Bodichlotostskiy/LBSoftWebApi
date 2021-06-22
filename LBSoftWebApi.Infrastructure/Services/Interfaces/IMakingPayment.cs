using LBSoftWebApi.Data.Entities;
using LBSoftWebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApi.Infrastructure.Services.Interfaces
{
    public interface IMakingPayment
    {
        Task<Payment> MakePayment(PaymentModel payment);
    }
}
