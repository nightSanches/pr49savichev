using Microsoft.AspNetCore.Mvc;
using pr49savichev.Context;
using pr49savichev.Models;
using System.Collections.Generic;
using System.Linq;

namespace pr49savichev.Controllers
{
    [Route("api/VersionsController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class VersionsController : Controller
    {
        /// <summary>
        /// Получение списка версий
        /// </summary>
        /// <remarks>Данный метод получает список версий</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("GetVersions")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Versions>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Versions> Versions = new VersionsContext().Versions;
                return Json(Versions);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
