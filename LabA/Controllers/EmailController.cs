using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LabA.Models;
using LabA.Services;

namespace LabA.Controllers
{
    public class EmailController : Controller
    {
        //  private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly EmailSettings _emailSettings;

        public EmailController(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Send Email Action
        public IActionResult Contact()
        {
            if (new EmailHelper(_emailSettings).SendMail("", "Hello from .NET !!"))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");

        }
    }
}