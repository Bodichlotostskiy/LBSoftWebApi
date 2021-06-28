using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using LBSoftWebApp.Services;

namespace LBSoftWebApp.Controllers
{
    public class PaymentController : Controller
    {

        public IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        //
        // GET: /Payment/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPut]
        public async Task<ActionResult> MakePayment(string AccountNumber, int Amount)
        {
            int accountNumbertoint=0;
            Int32.TryParse(AccountNumber, out accountNumbertoint);
            if (accountNumbertoint!=0)
                return View(await paymentService.CreateAsync(accountNumbertoint,Amount));
            else
                return null;

        }

        [HttpGet("/{paymentNumber}")]
        public async Task<ActionResult> CheckStatus(string paymentNumber)
        {
            int PaymentNumbertoint=0;
            Int32.TryParse(paymentNumber, out PaymentNumbertoint);
            if (PaymentNumbertoint != 0)
                return View(await paymentService.GetPaymentAsync(PaymentNumbertoint));
            else
                return null;
        }

        

    }
}
