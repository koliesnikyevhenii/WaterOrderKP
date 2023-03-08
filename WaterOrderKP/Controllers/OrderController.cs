using Microsoft.AspNetCore.Mvc;
using WaterKpBisnessLayer.ModelsBL;
using WaterKpBisnessLayer.Services;
using WaterOrderKP.Models;
using WaterOrderKP.Services;

namespace WaterOrderKP.Controllers
{

	public class OrderController : Controller
    {
        private readonly int _countItemOnThePage = 15;
        private readonly List<OrderItemModel> orders;

        public OrderController()
        {
            OrderService orderService = new OrderService();
            orders = new List<OrderItemModel>();


            List<OrderItemBL> ordersBL = orderService.GetAllOrders();


			foreach (var or in ordersBL)
            {
                OrderItemModel order = new OrderItemModel();
                order.Address = or.Address;
                order.PhoneNumber = or.Telephone;
                order.Comment = or.Comment;
                // todo: finish with it

                orders.Add(order);
            }
           
		}

        // GET: OrderController
        public ActionResult Index(bool isAjax = false, string orderBy = "countbottle", bool desc = false, int currentPage = 1, string phoneNumber = "")
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

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                filteredOrders = orders.Where(order => order.PhoneNumber.Equals(phoneNumber)).ToList();
            }

            model.Orders = filteredOrders.Skip(skipItems).Take(_countItemOnThePage).ToList(); 

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
        public ActionResult Create(OrderItemModel item)
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
        public ActionResult MakeOrder([FromBody] MakeOrderModel model)
        {
            // TODO: find error
            var deliveredOrderIds = model.ordersIds.Replace("makeOrder_", "").Split(';');
            orders.Where(order => deliveredOrderIds.Contains(order.Id.ToString())).ToList().ForEach(order => order.IsDelivered = true);

            var fakeOrder = orders.FirstOrDefault();

            if (fakeOrder != null)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var smsText = configuration.GetValue<string>("SmsSendingData:TextSms");
                var sms = string.Format(smsText, fakeOrder.Name);
                var phone = fakeOrder.PhoneNumber;

                // TODO: get from setting
                var isEnableSmsSetting = true;

                try
                {
                    if (isEnableSmsSetting)
                    {
                        KpSmsService smsService = new KpSmsService();
                        smsService.SendSms(phone, sms);
                    }
                }
                catch (Exception ex)
                {
                    return Index(true);
                }
            }

            return Index(true);
        }
        public ActionResult RejectOrder(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);
            order.IsDelivered = false;
            return Details(id);
        }

        public List<string> OrdersPhone(string term)
        {
             List<string> phoneNumbers = new List<string>();
             phoneNumbers = orders.Where(order => order.PhoneNumber.Contains(term))
                                   .Select(x => x.PhoneNumber).ToList();

            return phoneNumbers;
        }
    }
}
