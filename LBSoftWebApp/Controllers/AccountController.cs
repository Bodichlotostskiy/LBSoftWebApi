
using LBSoftWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace LBSoftWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IPaymentService paymentService;
        public AccountController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Check(string AccountNumber)
        {
            
            int accountNumbertoint;
            Int32.TryParse(AccountNumber, out accountNumbertoint);
            if (accountNumbertoint!=0)
                return View(await paymentService.GetAsync(accountNumbertoint));
            else
                return null;

        }



        public int ParseStringtoInt(string text)
        {
            int temp;
            if (Int32.TryParse(text, out temp))
            {
                return temp;
            }
            else return 0;
        }
        
    }
}
