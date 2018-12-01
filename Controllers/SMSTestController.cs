using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.AspNetCore.Identity;
using MVC.Areas.Identity.Data;
using smsverifylibrary;

namespace MVC.Controllers
{
    public class SMSTestController : Controller
    {
        private readonly UserManager<PRPCUser> _manager;
        public SMSTestController(UserManager<PRPCUser> userManager){
            _manager = userManager;
        } 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PRPCUser user = await GetCurrentUserAsync();
            VerifySmS sms = new VerifySmS();
            ViewData["name"] = user.FName;
            string smsPhoneNumber = "+1" + user.PhoneNumber;
            ViewData["phoneNumber"] = smsPhoneNumber;
            ViewData["messageResult"] = sms.VerifyText(smsPhoneNumber);
           
            return View();
            //try async
        }

        private Task<PRPCUser> GetCurrentUserAsync() => _manager.GetUserAsync(HttpContext.User);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
