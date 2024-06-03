using Microsoft.AspNetCore.Mvc;
using pr49savichev.Context;
using pr49savichev.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;

namespace pr49savichev.Controllers
{
    [Route("api/OrderController")]
    [ApiExplorerSettings(GroupName = "v3")]
    public class OrderController : Controller
    {
        /// <summary>
        /// Отправка заказа
        /// </summary>
        /// <param name="Address">Адрес пользователя</param>
        /// <param name="Date">Дата заказа</param>
        /// <param name="DishId">Код блюда</param>
        /// <param name="Count">Количество</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Данный метод предназначен для отправки заказа</returns>
        /// <response code="200">Заказ принят</response>
        /// <response code="400">Введены не все данные</response>
        /// <response code="401">Такого пользователя не существует</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("AddOrder")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult AddOrder([FromForm]string Address, [FromForm] DateTime Date, [FromForm] int DishId, [FromForm] int Count, [FromForm] string Token)
        {
            if (Address == null || Date == null || DishId == 0 || Count == 0 || Token == null) return StatusCode(400);
            try
            {
                var newOrder = new OrdersContext();
                var userToken = new UsersContext();
                if (newOrder.Orders.FirstOrDefault(x => x.Address == Address && x.Date == Date && x.DishId == DishId && x.Count == Count) != null) 
                    return StatusCode(400);
                if (userToken.Users.FirstOrDefault(x => x.Token == Token) == null)
                    return StatusCode(401, "Такой пользователь не существует");
                else
                {
                    Orders Order = new Orders()
                    {
                        Address = Address,
                        Date = Date,
                        DishId = DishId,
                        Count = Count
                    };
                    newOrder.Orders.Add(Order);
                    newOrder.SaveChanges();
                    return Json(newOrder);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
