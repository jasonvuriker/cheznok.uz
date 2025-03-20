using Microsoft.EntityFrameworkCore;

namespace cheznok.uz.Entities;

public class ChesnokContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }

    public DbSet<MealLog> MealLogs { get; set; }

    public DbSet<User> Users { get; set; }

    public ChesnokContext(DbContextOptions options) : base(options)
    {

    }
}
