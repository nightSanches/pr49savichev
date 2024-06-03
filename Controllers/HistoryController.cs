using Microsoft.AspNetCore.Mvc;
using pr49savichev.Context;
using pr49savichev.Models;
using System.Collections.Generic;
using System.Linq;

namespace pr49savichev.Controllers
{
    [Route("api/HistoryController")]
    [ApiExplorerSettings(GroupName = "v4")]
    public class HistoryController : Controller
    {
        /// <summary>
        /// Получение истории заказов
        /// </summary>
        /// <remarks>Данный метод получает историю заказов</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("History")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Orders>), 200)]
        [ProducesResponseType(500)]
        public ActionResult History()
        {
            try
            {
                IEnumerable<Orders> Order = new OrdersContext().Orders;
                return Json(Order);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
