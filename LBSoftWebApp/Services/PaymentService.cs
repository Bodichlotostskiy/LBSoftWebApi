using LBSoftWebApi.Data.Core;
using LBSoftWebApi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LBSoftWebApp.Services
{
    public static class PaymentServiceExtensions
    {
        public static void AddAccointService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IPaymentService, PaymentService>();
        }
    }

    public class PaymentService : IPaymentService
    {


        private readonly HttpClient httpClient;
        private readonly string accountBaseAddress = string.Empty;

        public PaymentService( HttpClient httpClient, string accountBaseAddress= "https://localhost:44349")
        {
            this.accountBaseAddress = accountBaseAddress;
            this.httpClient = httpClient;
        }

        public async Task<Payment> CreateAsync(int accountNumber, int Amount)
        {
            Payment newPayment = new Payment() { Amount = Amount, Status = Status.in_work, Recipient = accountNumber };

            var stringContent = new StringContent(JsonConvert.SerializeObject(newPayment), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{accountBaseAddress}", stringContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                Payment payment = JsonConvert.DeserializeObject<Payment>(content);
                return payment;
            }
            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        }

        public async Task<Account> GetAsync(int accountNumber)
        {

            var response = await httpClient.GetAsync($"{accountBaseAddress}/{accountNumber}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                Account account = JsonConvert.DeserializeObject<Account>(content);

                return account;
            }

            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        }

        public async Task<Payment> GetPaymentAsync(int paymentNumber)
        {
            var stringContent = new StringContent(paymentNumber.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{accountBaseAddress}/{paymentNumber}", stringContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                Payment payment = JsonConvert.DeserializeObject<Payment>(content);

                return payment;
            }

            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        }

        
    }
}
