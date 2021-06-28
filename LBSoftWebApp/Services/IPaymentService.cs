using LBSoftWebApi.Data.Entities;
using LBSoftWebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBSoftWebApp.Services
{
    public interface IPaymentService
    {
        Task<Account> GetAsync(int accountNumber);
        Task<Payment> CreateAsync(int accountNumber, int Amount);
        Task<Payment> GetPaymentAsync(int paymentNumber);
    }
}
