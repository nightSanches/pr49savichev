namespace pr49savichev.Models
{
    /// <summary>
    /// Блюда
    /// </summary>
    public class Dishes
    {
        /// <summary>
        /// Код блюда
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Категория блюда
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Название блюда
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена блюда
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// Изображение блюда
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Версия блюда
        /// </summary>
        public int Version { get; set; }
    }
}
