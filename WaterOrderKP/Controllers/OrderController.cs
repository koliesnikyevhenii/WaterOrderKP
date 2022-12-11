using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using WaterOrderKP.Models;

namespace WaterOrderKP.Controllers
{
    public class OrderController : Controller
    {
        public static List<OrderItem> orders = new List<OrderItem> {
            new OrderItem
            {
                Address = "Krasompavlivka 10/4",
                Comment = "Till 10 morning",
                CountBottle = 2,
                Name = "Yevhenii Koliesnik",
                OrderDate = DateTime.Now,
                PhoneNumber = "0994285796",
                Id= 1
            },

              new OrderItem
              {
                  Address = "Panutino 20",
                  Comment = "Till 9 morning",
                  CountBottle = 5,
                  Name = "Pupkin Mikhail",
                  OrderDate = DateTime.Now,
                  PhoneNumber = "0453567796",
                  Id = 2
              }};

        // GET: OrderController
        public ActionResult Index()
        {
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var oder = orders.FirstOrDefault(x=>x.Id == id);
            return View(oder);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItem item)
        {
            try
            {
                var id = orders.Any() ? orders.Max(item => item.Id) + 1 : 1;
                item.Id = id;
                orders.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var oder = orders.FirstOrDefault(x => x.Id == id);
        
            return View(oder);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditOrderItemModel model)
        {
            var order = orders?.FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                order.Address = model.Address;
                order.PhoneNumber = model.PhoneNumber;
                order.Comment = model.Comment;
                order.OrderDate = model.OrderDate;
                order.CountBottle = model.CountBottle;
                order.Name = model.Name;
            }
            else
            {
                return BadRequest();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedOrder = orders.FirstOrDefault(order => order.Id == id);
            return View(deletedOrder);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deletedOrder = orders.FirstOrDefault(order => order.Id == id);

            if (deletedOrder != null)
            {
                orders.Remove(deletedOrder);
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
