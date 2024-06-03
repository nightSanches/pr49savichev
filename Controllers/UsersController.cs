using Microsoft.AspNetCore.Mvc;
using pr49savichev.Context;
using pr49savichev.Models;
using System.Linq;
using System;

namespace pr49savichev.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Email">Почта</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод предназначен для авторизации пользователя</returns>
        /// <response code="200">Успешная авторизация</response>
        /// <response code="405">Введены не все данные</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("SignIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(405)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm] string Email, [FromForm] string Password)
        {
            if (Email == null || Password == null) return StatusCode(405);
            try
            {
                Users User = new UsersContext().Users.Where(x => x.Email == Email && x.Password == Password).First();
                return Json(User.Token);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="Email">Почта</param>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Данный метод предназначен для регистрации пользователя</returns>
        /// <response code="200">Успешная регистрация</response>
        /// <response code="405">Введены не все данные</response>
        /// <response code="400">Ошибка регистрации. Такой пользователь уже существует</response>
        /// <response code="500">Ошибка запроса</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(405)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Email, [FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null) return StatusCode(405);
            try
            {
                var newUser = new UsersContext();
                if (newUser.Users.FirstOrDefault(x => x.Email == Email && x.Login == Login && x.Password == Password) != null) 
                    return StatusCode(400);
                else
                {
                    Users User = new Users()
                    {
                        Login = Login,
                        Password = Password,
                        Email = Email,
                        Token = GenerateToken()
                    };
                    newUser.Users.Add(User);
                    newUser.SaveChanges();
                    return Json(newUser);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public static string GenerateToken()
        {
            Random random = new Random();
            const string str = "qwertyuiopasdfg";
            return new string(Enumerable.Repeat(str, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
