using Microsoft.AspNetCore.Mvc;
using pr49savichev.Context;
using pr49savichev.Models;
using System.Collections.Generic;
using System.Linq;

namespace pr49savichev.Controllers
{
    [Route("api/DishesController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class DishesController : Controller
    {
        /// <summary>
        /// Получение списка блюд
        /// </summary>
        /// <param name="version">Версия блюда</param>
        /// <remarks>Данный метод получает список блюд</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("GetDishes")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Dishes>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List(int version)
        {
            try
            {
                IEnumerable<Dishes> Dishes = new DishesContext().Dishes.Where(x => x.Version == version);
                return Json(Dishes);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
