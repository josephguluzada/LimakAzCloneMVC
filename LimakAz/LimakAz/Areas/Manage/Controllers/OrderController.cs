using LimakAz.Areas.Manage.ViewModels;
using LimakAz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.Include(x=>x.AppUser).ToList();

            return View(orders);
        }

        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.Courier).Include(x=>x.AppUser).ThenInclude(x=>x.WareHouse).FirstOrDefault(x=>x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            return View(order);
        }

        public IActionResult AddCourier(int id)
        {
            Order order = _context.Orders.Include(x => x.Courier).Include(x => x.AppUser).ThenInclude(x => x.WareHouse).FirstOrDefault(x => x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            CourierViewModel courierVM = new CourierViewModel();
            courierVM.Order = order;
            courierVM.CourierId = order.CourierId != null ? (int)order.CourierId : 0;

            ViewBag.Couriers = _context.Couriers.Where(x => x.WareHouseId == order.AppUser.WareHouseId).ToList();

            return View(courierVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourier(CourierViewModel courierVM)
        {

            Order existOrder = _context.Orders.Include(x => x.Courier).Include(x => x.AppUser).ThenInclude(x => x.WareHouse).FirstOrDefault(x => x.Id == courierVM.Order.Id);
            if (existOrder == null) return RedirectToAction("index", "error");

            existOrder.InPackageStatus = true;
            existOrder.CourierId = courierVM.CourierId;

            _context.SaveChanges();

            return RedirectToAction("index", "Order");
        }


        public IActionResult Accept(int id)
        {
            Order order = _context.Orders.Include(x => x.Courier).Include(x => x.AppUser).ThenInclude(x => x.WareHouse).FirstOrDefault(x => x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            order.Status = Models.Enums.OrderStatus.Anbarda;

            _context.SaveChanges();

            return RedirectToAction("index", "order");
        }

        public IActionResult Reject(int id)
        {
            Order order = _context.Orders.Include(x => x.Courier).Include(x => x.AppUser).ThenInclude(x => x.WareHouse).FirstOrDefault(x => x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            order.Status = Models.Enums.OrderStatus.İmtina;

            _context.SaveChanges();

            return RedirectToAction("index", "order");
        }
    }
}
