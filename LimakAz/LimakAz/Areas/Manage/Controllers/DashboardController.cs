using LimakAz.Areas.Manage.ViewModels;
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
            DashboardViewModel dashboardVM = new DashboardViewModel
            {
                Orders = _context.Orders.ToList(),
                Couriers = _context.Couriers.ToList()
            };


            return View(dashboardVM);
        }


        public IActionResult GetData()
        {
            int inWarehouse = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Anbarda).Count();
            int done = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Tamamlanmış).Count();
            int onCourier = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Kuryerdə).Count();
            int pending = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Gözləmədə).Count();
            int rejected = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.İmtina).Count();

            int sumgayit = _context.Couriers.Where(x => x.WareHouseId == 3).Count();
            int zaqatala = _context.Couriers.Where(x => x.WareHouseId == 4).Count();
            int xirdalan = _context.Couriers.Where(x => x.WareHouseId == 6).Count();
            int ganja = _context.Couriers.Where(x => x.WareHouseId == 2).Count();
            int iceriseher = _context.Couriers.Where(x => x.WareHouseId == 1).Count();
            int xalqlar = _context.Couriers.Where(x => x.WareHouseId == 5).Count();


            Ratio ratio = new Ratio();
            ratio.InWareHouse = inWarehouse;
            ratio.Done = done;
            ratio.OnCourier = onCourier;
            ratio.Pending = pending;
            ratio.Rejected = rejected;

            ratio.Khalglar = xalqlar;
            ratio.Sumgayit = sumgayit;
            ratio.Zaqatala = zaqatala;
            ratio.Xirdalan = xirdalan;
            ratio.Iceriseher = iceriseher;
            ratio.Ganja = ganja;

            return Json(ratio);
        }


        public class Ratio
        {
            public int InWareHouse { get; set; }
            public int Done { get; set; }
            public int OnCourier { get; set; }
            public int Pending { get; set; }
            public int Rejected { get; set; }

            public int Sumgayit { get; set; }
            public int Khalglar { get; set; }
            public int Iceriseher { get; set; }
            public int Ganja { get; set; }
            public int Xirdalan { get; set; }
            public int Zaqatala { get; set; }
        }
    }
}
