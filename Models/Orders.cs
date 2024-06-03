using System;

namespace pr49savichev.Models
{
    /// <summary>
    /// Отправить заказ
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// Код заказа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Адрес заказа
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Блюдо
        /// </summary>
        public int DishId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
    }
}
