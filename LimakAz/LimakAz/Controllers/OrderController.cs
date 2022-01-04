using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Authorize(Roles ="Member")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
