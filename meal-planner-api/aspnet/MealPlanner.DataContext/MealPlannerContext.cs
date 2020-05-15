using Microsoft.EntityFrameworkCore;
using MealPlanner.ObjectModels.Models;

namespace MealPlanner.DataContext
{
  /// <summary>
  /// Represents the _MealPlanner_ context
  /// </summary>
  public class MealPlannerContext : DbContext
  {
    public DbSet<AccountModel> Accounts { get; set; }
    public DbSet<FoodModel> Foods { get; set; }
    // public DbSet<NutritionModel> Nutritions { get; set; }
    // public DbSet<NutrientModel> Nutrients { get; set; }
    // public DbSet<AmountModel> Amounts { get; set; }
    public DbSet<UnitModel> Units { get; set; }
    public DbSet<DayModel> Days { get; set; }
    // public DbSet<EatModel> Eats { get; set; }
    public DbSet<NutrientTypeModel> NutrientTypes { get; set; }

    public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Setup Primary Keys
      modelBuilder.Entity<FoodModel>().HasKey(f => f.Id);
      modelBuilder.Entity<UnitModel>().HasKey(u => u.Id);
      modelBuilder.Entity<DayModel>().HasKey(d => d.Id);
      modelBuilder.Entity<AccountModel>().HasKey(a => a.Id);
      modelBuilder.Entity<NutrientTypeModel>().HasKey(nt => nt.Id);

      // Set up Relationships
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients).OwnsOne(nu => nu.Amount);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.ServingSizes).OwnsOne(n => n.ServingSize);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.ServingSizes).HasOne<UnitModel>().WithMany().HasForeignKey(s => s.UnitPerServingId);
      modelBuilder.Entity<FoodModel>().OwnsOne(f => f.Nutrition).OwnsMany(n => n.Nutrients).HasOne<NutrientTypeModel>().WithMany().HasForeignKey(nu => nu.NutrientTypeId);

      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats);
      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats).HasOne<FoodModel>().WithMany().HasForeignKey(e => e.FoodId);
      modelBuilder.Entity<DayModel>().OwnsMany(d => d.Eats).OwnsOne(e => e.Servings);


      modelBuilder.Entity<AccountModel>().HasMany<DayModel>().WithOne().HasForeignKey(d => d.AccountId);
      modelBuilder.Entity<AccountModel>().HasMany<FoodModel>().WithOne().HasForeignKey(f => f.AccountId);
      
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
      modelBuilder.Entity<NutrientTypeModel>().HasData(new NutrientTypeModel[]
      {
        // Basic Nutrients on Nutrition Facts Label
        new NutrientTypeModel() { Id = 1001, Name = "Total Fat",          UnitId = 1001 },
        new NutrientTypeModel() { Id = 1002, Name = "Saturated Fat",      UnitId = 1001 },
        new NutrientTypeModel() { Id = 1003, Name = "Trans Fat",          UnitId = 1001 },
        new NutrientTypeModel() { Id = 1004, Name = "Cholesterol",        UnitId = 1002 },
        new NutrientTypeModel() { Id = 1005, Name = "Sodium",             UnitId = 1002 },
        new NutrientTypeModel() { Id = 1006, Name = "Total Carbohydrate", UnitId = 1001 },
        new NutrientTypeModel() { Id = 1007, Name = "Dietary Fiber",      UnitId = 1001 },
        new NutrientTypeModel() { Id = 1008, Name = "Total Sugars",       UnitId = 1001 },
        new NutrientTypeModel() { Id = 1009, Name = "Added Sugars",       UnitId = 1001 },
        new NutrientTypeModel() { Id = 1010, Name = "Protein",            UnitId = 1001 },
        // Extra Nutrients on Nutrition Facts Label (Vitamins and Minerals)
        new NutrientTypeModel() { Id = 1011, Name = "Vitamin A",        UnitId = 1006 },
        new NutrientTypeModel() { Id = 1012, Name = "Vitamin C",        UnitId = 1002 },
        new NutrientTypeModel() { Id = 1013, Name = "Thiamin",          UnitId = 1002 },
        new NutrientTypeModel() { Id = 1014, Name = "Riboflavin",       UnitId = 1002 },
        new NutrientTypeModel() { Id = 1015, Name = "Niacin",           UnitId = 1002 },
        new NutrientTypeModel() { Id = 1016, Name = "Pantothenic acid", UnitId = 1002 },
        new NutrientTypeModel() { Id = 1017, Name = "Vitamin B6",       UnitId = 1002 },
        new NutrientTypeModel() { Id = 1018, Name = "Folate",           UnitId = 1007 },
        new NutrientTypeModel() { Id = 1019, Name = "Biotin",           UnitId = 1007 },
        new NutrientTypeModel() { Id = 1020, Name = "Vitamin B12",      UnitId = 1007 },
        new NutrientTypeModel() { Id = 1021, Name = "Vitamin D",        UnitId = 1006 },
        new NutrientTypeModel() { Id = 1022, Name = "Vitamin E",        UnitId = 1002 },
        new NutrientTypeModel() { Id = 1023, Name = "Vitamin K",        UnitId = 1007 },
        new NutrientTypeModel() { Id = 1024, Name = "Calcium",          UnitId = 1002 },
        new NutrientTypeModel() { Id = 1025, Name = "Iron",             UnitId = 1002 },
        new NutrientTypeModel() { Id = 1026, Name = "Phosphorus",       UnitId = 1002 },
        new NutrientTypeModel() { Id = 1027, Name = "Iodine",           UnitId = 1007 },
        new NutrientTypeModel() { Id = 1028, Name = "Magnesium",        UnitId = 1002 },
        new NutrientTypeModel() { Id = 1029, Name = "Zinc",             UnitId = 1002 },
        new NutrientTypeModel() { Id = 1030, Name = "Selenium",         UnitId = 1007 },
        new NutrientTypeModel() { Id = 1031, Name = "Copper",           UnitId = 1002 },
        new NutrientTypeModel() { Id = 1032, Name = "Manganese",        UnitId = 1002 },
        new NutrientTypeModel() { Id = 1033, Name = "Chromium",         UnitId = 1007 },
        new NutrientTypeModel() { Id = 1034, Name = "Molybdenum",       UnitId = 1007 },
        new NutrientTypeModel() { Id = 1035, Name = "Chloride",         UnitId = 1002 }
      });
    }
  }
}