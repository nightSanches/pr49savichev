using Microsoft.EntityFrameworkCore;
using pr49savichev.Models;

namespace pr49savichev.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=;database=Base49", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
