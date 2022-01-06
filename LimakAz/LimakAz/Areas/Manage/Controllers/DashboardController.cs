using LimakAz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetData()
        {
            int inWarehouse = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Anbarda).Count();
            int done = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Tamamlanmış).Count();
            int onCourier = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Kuryerdə).Count();
            int pending = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Gözləmədə).Count();
            int rejected = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.İmtina).Count();


            Ratio ratio = new Ratio();
            ratio.InWareHouse = inWarehouse;
            ratio.Done = done;
            ratio.OnCourier = onCourier;
            ratio.Pending = pending;
            ratio.Rejected = rejected;

            return Json(ratio);
        }


        public class Ratio
        {
            public int InWareHouse { get; set; }
            public int Done { get; set; }
            public int OnCourier { get; set; }
            public int Pending { get; set; }
            public int Rejected { get; set; }
        }
    }
}
