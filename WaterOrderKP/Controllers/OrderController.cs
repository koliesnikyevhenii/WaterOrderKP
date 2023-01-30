using Microsoft.AspNetCore.Mvc;
using WaterOrderKP.Models;

namespace WaterOrderKP.Controllers
{
    public class OrderController : Controller
    {
        public static List<OrderItem> orders = new List<OrderItem>();

        private readonly int _countItemOnThePage = 15;

        public OrderController()
        {
            if (!orders.Any())
            {
                for (int i = 0; i < 150; i++)
                {
                    var orderItem = new OrderItem
                    {
                        Address = Faker.Address.StreetAddress(true),
                        Comment = Faker.Lorem.Sentence(),
                        CountBottle = Faker.RandomNumber.Next(1, 20),
                        Name = Faker.Name.FullName(),
                        OrderDate = new DateTime(2022, 12, Faker.RandomNumber.Next(1, 30)).ToShortDateString(),
                        PhoneNumber = "0994285796",
                        Id = i + 1
                    };

                    orders.Add(orderItem);
                }
            }
        }

        // GET: OrderController
        public ActionResult Index(bool isAjax = false, string orderBy = "countbottle", bool desc = false, int currentPage = 1)
        {
            var filteredOrders = orders;
            OrderIndexModel model = new OrderIndexModel();

            var totalPages = (int)Math.Ceiling(orders.Count() / (double)_countItemOnThePage);
            model.AmountOfPage = totalPages;

            int skipItems = 0;

            if (currentPage != 1)
            {
                skipItems = (currentPage - 1) * _countItemOnThePage;
            }


            if (orderBy == "countbottle")
            {

                filteredOrders = desc ? orders.OrderBy(order => order.CountBottle).ToList() 
                    : orders.OrderByDescending(order => order.CountBottle).ToList();

                model.IsBottleCountDesc = desc;
            }

            model.Orders = filteredOrders.Skip(skipItems).Take(_countItemOnThePage).ToList(); ;

            // TODO: it's just for simulation api request or long time calculation on server 
            // need to demonstrate how works spinner

            Thread.Sleep(2000);

            if (isAjax)
            {

                return View("~/Views/Partials/IndexTable.cshtml", model);
            }

           
            return View(model);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var oder = orders.FirstOrDefault(x => x.Id == id);
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
            if (!ModelState.IsValid)
            {
                return View(item);
            }

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
                order.OrderDate = model.OrderDate.ToShortDateString();
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



        // POST: OrderController/Edit/5
        [HttpPost]
        public ActionResult MakeOrder(string ordersIds, string comment)
        {
            return Ok();
        }
    }
}
