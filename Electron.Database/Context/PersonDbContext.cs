using Electron.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Electron.Database.Context
{
    //выбранная реализация - одна таблица, нет связок.
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> context) : base(context)
        {

        }

        public DbSet<PersonDbModel> Persons { get; set; }
    }
}
