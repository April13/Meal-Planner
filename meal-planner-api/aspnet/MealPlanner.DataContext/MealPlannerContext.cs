using Microsoft.EntityFrameworkCore;
using MealPlanner.ObjectModels.Models;

namespace MealPlanner.DataContext
{
  /// <summary>
  /// Represents the _MealPlanner_ context
  /// </summary>
  public class MealPlannerContext : DbContext
  {
    public DbSet<FoodModel> Foods { get; set; }
    // public DbSet<NutritionModel> Nutritions { get; set; }
    // public DbSet<NutrientModel> Nutrients { get; set; }
    // public DbSet<AmountModel> Amounts { get; set; }
    public DbSet<UnitModel> Units { get; set; }
    public DbSet<DayModel> Days { get; set; }
    // public DbSet<EatModel> Eats { get; set; }

    public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Setup Primary Keys
      modelBuilder.Entity<FoodModel>().HasKey(f => f.Id);
      // modelBuilder.Entity<NutritionModel>().HasKey(n => n.Id);
      //modelBuilder.Entity<NutrientModel>().HasKey(nu => nu.Id);
      
      //modelBuilder.Entity<AmountModel>().HasKey(a => a.Id);
      modelBuilder.Entity<UnitModel>().HasKey(u => u.Id);

      modelBuilder.Entity<DayModel>().HasKey(d => d.Id);
      //modelBuilder.Entity<EatModel>().HasKey(e => e.Id);

      // Set up Relationships
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients).OwnsOne(nu => nu.Amount);
      // modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients).HasOne(nu => nu.Unit);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.ServingSizes).OwnsOne(n => n.ServingSize);
      // modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.ServingSizes).HasOne(n => n.UnitOfServingSize);
      /*
      modelBuilder.Entity<NutritionModel>().OwnsMany(n => n.Nutrients).WithOwner().HasForeignKey(nu => nu.NutritionId);
      modelBuilder.Entity<NutritionModel>().OwnsMany(n => n.Nutrients).OwnsOne(nu => nu.Amount);
      modelBuilder.Entity<NutritionModel>().OwnsMany(n => n.Nutrients).HasOne(nu => nu.Unit);
      modelBuilder.Entity<NutritionModel>().OwnsOne(n => n.ServingSize);
      modelBuilder.Entity<NutritionModel>().OwnsOne(n => n.AmountPerServing);
      modelBuilder.Entity<NutritionModel>().HasOne(n => n.UnitPerServing);
      */
      // modelBuilder.Entity<NutrientModel>().OwnsOne(nu => nu.Amount).WithOwner();
      // modelBuilder.Entity<NutrientModel>().HasOne(nu => nu.Unit).WithOne();

      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats);
      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats).HasOne(e => e.Food);
      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats).OwnsOne(e => e.Servings);
      /*
      modelBuilder.Entity<DayModel>().HasMany(d => d.Eats).WithOne().HasForeignKey(e => e.DayId);
      modelBuilder.Entity<EatModel>().HasOne(e => e.Food).WithOne();
      modelBuilder.Entity<EatModel>().OwnsOne(e => e.Servings);
      */
      
      // Seed Data
      modelBuilder.Entity<UnitModel>().HasData(new UnitModel[]
      {
        new UnitModel() { Id = 1001, Name = "g" },
        new UnitModel() { Id = 1002, Name = "mg" },
        new UnitModel() { Id = 1003, Name = "mcg" },
        new UnitModel() { Id = 1004, Name = "cup" },
        new UnitModel() { Id = 1005, Name = "oz" },
        new UnitModel() { Id = 1006, Name = "IU" },
        new UnitModel() { Id = 1007, Name = "μg" }
      });
    }
  }
}