using Microsoft.EntityFrameworkCore;
using MealPlanner.ObjectModels.Models;

namespace MealPlanner.DataContext
{
  /// <summary>
  /// Represents the _Lodging_ context
  /// </summary>
  public class MealPlannerContext : DbContext
  {
    public DbSet<FoodModel> Foods { get; set; }
    public DbSet<NutritionModel> Nutritions { get; set; }
    public DbSet<NutrientModel> Nutrients { get; set; }
    public DbSet<AmountModel> Amounts { get; set; }
    public DbSet<UnitModel> Units { get; set; }

    public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Setup Primary Keys
      modelBuilder.Entity<FoodModel>().HasKey(f => f.Id);
      modelBuilder.Entity<NutritionModel>().HasKey(n => n.Id);
      modelBuilder.Entity<NutrientModel>().HasKey(nu => nu.Id);
      
      modelBuilder.Entity<AmountModel>().HasKey(a => a.Id);
      modelBuilder.Entity<UnitModel>().HasKey(u => u.Id);

      // Set up Relationships
      modelBuilder.Entity<FoodModel>().HasOne(f => f.Nutrition).WithOne();
      modelBuilder.Entity<NutritionModel>().HasMany(n => n.Nutrients).WithOne().HasForeignKey(nu => nu.NutritionId);
      modelBuilder.Entity<NutritionModel>().HasOne(n => n.ServingSize).WithOne();
      modelBuilder.Entity<NutritionModel>().HasOne(n => n.AmountPerServing).WithOne();
      modelBuilder.Entity<NutritionModel>().HasOne(n => n.UnitPerServing).WithOne();
      modelBuilder.Entity<NutrientModel>().HasOne(nu => nu.Amount).WithOne();
      modelBuilder.Entity<NutrientModel>().HasOne(nu => nu.Unit).WithOne();
      /* Owned Entity Types?
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition);
      modelBuilder.Entity<NutritionModel>().OwnsMany(n => n.Nutrients).WithOwner().HasForeignKey(nu => nu.NutritionId);
      modelBuilder.Entity<NutritionModel>().OwnsOne(n => n.ServingSize);
      modelBuilder.Entity<NutritionModel>().OwnsOne(n => n.AmountPerServing);
      modelBuilder.Entity<NutritionModel>().OwnsOne(n => n.UnitPerServing);
      modelBuilder.Entity<NutrientModel>().OwnsOne(nu => nu.Amount);
      modelBuilder.Entity<NutrientModel>().OwnsOne(nu => nu.Unit);
      */
      
      // Seed Data
      modelBuilder.Entity<UnitModel>().HasData(new UnitModel[]
      {
        new UnitModel() { Id = 1, Name = "g" },
        new UnitModel() { Id = 2, Name = "mg" },
        new UnitModel() { Id = 3, Name = "mcg" },
        new UnitModel() { Id = 4, Name = "cup" },
        new UnitModel() { Id = 5, Name = "oz" },
        new UnitModel() { Id = 6, Name = "IU" },
        new UnitModel() { Id = 7, Name = "μg" }
      });
    }
  }
}