using GenericContext.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Data;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(
            ILogger<HomeController> logger,
            CustomDbContext dbContext,
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            _logger.LogInformation(DateTime.Now.ToString("F"));

            //Templates entity = new Templates
            //{
            //    TemplateTitle = "New Patient Has Been Created",
            //    TemplateBody = "Doctor Mohammed has created a new patient with DMD disease for more information visit: www.link.com"
            //};

            //dbContext.Add(entity);
            //dbContext.SaveChanges();

            //Events events = new Events
            //{
            //    EventName = "",
            //    CreationDate = DateTime.Now,
            //    Template = new Templates
            //    {
            //        TemplateTitle = "New Patient Has Been Created",
            //        TemplateBody = "Doctor Mohammed has created a new patient with DMD disease for more information visit: www.link.com"
            //    },
            //    EventRecipient = new List<EventRecipient>() {
            //        new EventRecipient{ UserId = (userManager.GetUserId(User)), CreationDate = DateTime.Now }
            //    }
            //};
            //dbContext.Events.Add(events);
            //dbContext.SaveChanges();

            var values = dbContext.Events.Include(e => e.EventRecipient).Include(e => e.Template).ToList();
            var customers = dbContext.Customer.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
