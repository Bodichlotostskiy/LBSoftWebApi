using LBSoftWebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApi.Infrastructure.Services.Interfaces
{
    public interface ICheckPayment
    {
        Task<bool> PushCheckPaymentAsync(int paymentNumber);
    }
}
