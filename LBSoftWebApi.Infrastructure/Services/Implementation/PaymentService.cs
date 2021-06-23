using LBSoftWebApi.Data.Core;
using LBSoftWebApi.Data.Entities;
using LBSoftWebApi.Infrastructure.Models;
using LBSoftWebApi.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApi.Infrastructure.Services.Implementation
{
    public class PaymentService : IСheckAccount, IMakingPayment, ICheckPayment
    {
        private readonly IGenericRepository<Account> accounts;
        private readonly IGenericRepository<Payment> payments;


        private readonly IDatabaseTransaction transaction;

        public PaymentService(IGenericRepository<Account> account,
                              IGenericRepository<Payment> payment,
                              IDatabaseTransaction transaction)
        {
            this.accounts = account;
            this.payments = payment;
            this.transaction = transaction;
        }

        public async Task<Payment> MakePayment(PaymentModel payment)
        {
            transaction.Begin();

            var newPayment = await BuildPaymentModelAsync(payment);

            if (await payments.CreateAsync(newPayment) == null)
            {
                transaction.Rollback();

                return null;
            }

            transaction.Commit();

            return newPayment;

        }

        private async Task<Payment> BuildPaymentModelAsync(PaymentModel payment)
        {
            var accountRecipient = accounts.FindAsync(payment.Recipient).Result;
            if (accountRecipient == null)
            {
                accountRecipient = await accounts.CreateAsync(new Account() {AccountNumber=payment.Recipient,
                                                                             PossibilityOfPayment=true,
                                                                             Balance=0 });
            }

            var newPayment = new Payment
            {
                Status = Status.in_work,
                PaymentNumber = payment.PaymentNumber,
                Amount = payment.Amount,
                Recipient = payment.Recipient,
                AccountRecipient = accountRecipient,
            };
            return newPayment;
        }

        public Task<bool> PushCheckAccountAsync(int AccountNumber)
        {

            if (accounts.FindAsync(AccountNumber).Result != null)
            {
                if (accounts.FindAsync(AccountNumber).Result.PossibilityOfPayment)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
            else
                return Task.FromResult(false);
        }

        public async Task<Payment> PushCheckPaymentAsync(int paymentNumber)
        {
            var payment = payments.FindAsync(paymentNumber).Result;
            if (payment != null)
            {

                return (Payment)await payments.GetWithIncludeAsync(d => d.PaymentNumber.Equals(paymentNumber), d => d.Status);
            }
            else
                return null;
        }

       
    }
}
