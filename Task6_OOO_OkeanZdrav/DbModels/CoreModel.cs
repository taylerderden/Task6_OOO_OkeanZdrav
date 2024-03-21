using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class CoreModel : DbContext
{
    private static CoreModel instance;
    public static CoreModel init()
    {
        if (instance == null)
        {
            instance = new CoreModel();
        }
        return instance;
    }

    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr23-35_ZlobinDS;password=ISPr23-35_ZlobinDS;database=ISPr23-35_ZlobinDS_Task6;character set=utf-8", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClients).HasName("PRIMARY");

            entity.Property(e => e.IdClients).HasColumnName("idClients");
            entity.Property(e => e.ClientDiscountPercent).HasMaxLength(45);
            entity.Property(e => e.ClientEmail).HasMaxLength(45);
            entity.Property(e => e.ClientMiddlename).HasMaxLength(45);
            entity.Property(e => e.ClientName).HasMaxLength(45);
            entity.Property(e => e.ClientPhone).HasMaxLength(45);
            entity.Property(e => e.ClientSurname).HasMaxLength(45);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.PositionIdPosition, "fk_Employee_Position_idx");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.EmployeeEmail).HasMaxLength(45);
            entity.Property(e => e.EmployeeMiddleName).HasMaxLength(45);
            entity.Property(e => e.EmployeeName).HasMaxLength(45);
            entity.Property(e => e.EmployeePassword).HasMaxLength(45);
            entity.Property(e => e.EmployeePhone).HasMaxLength(45);
            entity.Property(e => e.EmployeeSurname).HasMaxLength(45);
            entity.Property(e => e.PositionIdPosition).HasColumnName("Position_idPosition");

            entity.HasOne(d => d.PositionIdPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionIdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Employee_Position");
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.IdMedicament).HasName("PRIMARY");

            entity.ToTable("Medicament");

            entity.HasIndex(e => e.SupplierIdSupplier, "fk_Medicament_Supplier1_idx");

            entity.HasIndex(e => e.TypeIdType, "fk_Medicament_Type1_idx");

            entity.Property(e => e.IdMedicament).HasColumnName("idMedicament");
            entity.Property(e => e.MedicamentAnalog).HasMaxLength(45);
            entity.Property(e => e.MedicamentDiscount).HasMaxLength(45);
            entity.Property(e => e.MedicamentName).HasMaxLength(45);
            entity.Property(e => e.MedicamentPart).HasMaxLength(45);
            entity.Property(e => e.SupplierIdSupplier).HasColumnName("Supplier_idSupplier");
            entity.Property(e => e.TypeIdType).HasColumnName("Type_idType");

            entity.HasOne(d => d.SupplierIdSupplierNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.SupplierIdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Medicament_Supplier1");

            entity.HasOne(d => d.TypeIdTypeNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.TypeIdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Medicament_Type1");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PRIMARY");

            entity.ToTable("Position");

            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.PositionName).HasMaxLength(45);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.IdPurchase).HasName("PRIMARY");

            entity.ToTable("Purchase");

            entity.HasIndex(e => e.ClientsIdClients, "fk_Purchase_Clients1_idx");

            entity.HasIndex(e => e.MedicamentIdMedicament, "fk_Purchase_Medicament1_idx");

            entity.HasIndex(e => e.RecipeIdRecipe, "fk_Purchase_Recipe1_idx");

            entity.Property(e => e.IdPurchase).HasColumnName("idPurchase");
            entity.Property(e => e.ClientsIdClients).HasColumnName("Clients_idClients");
            entity.Property(e => e.MedicamentIdMedicament).HasColumnName("Medicament_idMedicament");
            entity.Property(e => e.PurchaseCount).HasMaxLength(45);
            entity.Property(e => e.RecipeIdRecipe).HasColumnName("Recipe_idRecipe");

            entity.HasOne(d => d.ClientsIdClientsNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ClientsIdClients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Purchase_Clients1");

            entity.HasOne(d => d.MedicamentIdMedicamentNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.MedicamentIdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Purchase_Medicament1");

            entity.HasOne(d => d.RecipeIdRecipeNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.RecipeIdRecipe)
                .HasConstraintName("fk_Purchase_Recipe1");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.IdRecipe).HasName("PRIMARY");

            entity.ToTable("Recipe");

            entity.HasIndex(e => e.EmployeeIdEmployee, "fk_Recipe_Employee1_idx");

            entity.HasIndex(e => e.MedicamentIdMedicament, "fk_Recipe_Medicament1_idx");

            entity.Property(e => e.IdRecipe).HasColumnName("idRecipe");
            entity.Property(e => e.EmployeeIdEmployee).HasColumnName("Employee_idEmployee");
            entity.Property(e => e.MedicamentIdMedicament).HasColumnName("Medicament_idMedicament");
            entity.Property(e => e.RecipeDateTo).HasMaxLength(45);

            entity.HasOne(d => d.EmployeeIdEmployeeNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.EmployeeIdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Recipe_Employee1");

            entity.HasOne(d => d.MedicamentIdMedicamentNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.MedicamentIdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Recipe_Medicament1");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PRIMARY");

            entity.ToTable("Supplier");

            entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");
            entity.Property(e => e.SupplierName).HasMaxLength(45);
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PRIMARY");

            entity.ToTable("Type");

            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.TypeName).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
