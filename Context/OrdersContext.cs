using Microsoft.EntityFrameworkCore;
using pr49savichev.Models;

namespace pr49savichev.Context
{
    public class OrdersContext : DbContext
    {
        public DbSet<Orders> Orders { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public OrdersContext()
        {
            Database.EnsureCreated();
            Orders.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=;database=Base49", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
