using LimakAz.Areas.Manage.ViewModels;
using LimakAz.Models;
using LimakAz.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.OrderByDescending(x=>x.CreatedAt).Include(x=>x.AppUser).ToList();

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
            existOrder.Status = Models.Enums.OrderStatus.Kuryerdə;
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

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/order.html"))
            {
                body = reader.ReadToEnd();
            }

            string str = @$"<td align=""center"" bgcolor=""#F36928"" style=""background-color:#f36928;color:#ffffff;text-align:center;vertical-align:middle;font-family:Arial,sans-serif,helvetica;font-size:17px;line-height:24px"">
                                                Salam <strong>{order.FullName}, {order.ShopName}dan sifariş etdiyiniz</ strong >,<br>
  
                                                  <span style =""color:#000000 !important""> LMK001523{order.Id} </span> nömrəli <br>
                                                   bağlamanız artıq anbardadır
                                               </td> ";
            string orderHtml = string.Empty;
            orderHtml += str;

            body = body.Replace("{{id}}",str);


            _emailService.Send(order.AppUser.Email, "Sifarişiniz təstiq olundu.",body);

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

        public IActionResult Done(int id)
        {
            Order order = _context.Orders.Include(x => x.Courier).Include(x => x.AppUser).ThenInclude(x => x.WareHouse).FirstOrDefault(x => x.Id == id);
            if (order == null) return RedirectToAction("index", "error");

            order.Status = Models.Enums.OrderStatus.Tamamlanmış;

            _context.SaveChanges();

            return RedirectToAction("index", "order");
        }
    }
}
