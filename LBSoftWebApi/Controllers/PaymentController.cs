using LBSoftWebApi.Data.Entities;
using LBSoftWebApi.Infrastructure.Models;
using LBSoftWebApi.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LBSoftWebApi.Controllers
{
    [Route("Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICheckPayment checkPayment;
        private readonly IMakingPayment makingPayment;
        private readonly IСheckAccount checkAccount;

        public PaymentController(ICheckPayment checkPayment, IMakingPayment makingPayment, IСheckAccount checkAccount)
        {
            this.checkPayment = checkPayment;
            this.makingPayment = makingPayment;
            this.checkAccount = checkAccount;
        }
        /// <summary>
        /// Check for account availability 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>check of account</returns>
        [HttpGet("/{accountNumber}")]
        public async Task<bool> CheckAccount(int accountNumber)
        {
            return await checkAccount.PushCheckAccountAsync(accountNumber);
        }
        /// <summary>
        /// create payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>new Payments model</returns>
        [HttpPut]
        public async Task<Payment> MakingPayment(PaymentModel payment)
        {
            return await makingPayment.MakePayment(payment);
        }
        /// <summary>
        /// check for payment and, if available, returns the Status or if non avaible - null
        /// </summary>
        /// <param name="paymentNumber"></param>
        /// <returns>Status of Payment</returns>
        [HttpGet("/{paymentNumber}")]
        public async Task<Status> CheckPayment(int paymentNumber)
        {
            return (await checkPayment.PushCheckPaymentAsync(paymentNumber)).Status;
        }

    }
}
