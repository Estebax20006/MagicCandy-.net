using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MagicCandy.Models;

public partial class MagicandyContext : DbContext
{
    public MagicandyContext()
    {
    }

    public MagicandyContext(DbContextOptions<MagicandyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityManager> ActivityManagers { get; set; }

    public virtual DbSet<ActivityStatus> ActivityStatuses { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<InventoriesSupply> InventoriesSupplies { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Novelty> Novelties { get; set; }

    public virtual DbSet<NoveltyStatus> NoveltyStatuses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<ProductionStatus> ProductionStatuses { get; set; }

    public virtual DbSet<ProductsInventory> ProductsInventories { get; set; }

    public virtual DbSet<Referral> Referrals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Sender> Senders { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=magicandy;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("activities");

            entity.HasIndex(e => e.FkProductionId, "FK31quv0ckcxycaqw8rrdb1ht1b");

            entity.HasIndex(e => e.FkActivityStatusesId, "FK38drdotkjak6y45wiqkvdm83g");

            entity.HasIndex(e => e.FkActivityManagersId, "FKgo5r3ipcy8xlrqyy022irry1d");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FkActivityManagersId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_activity_managers_id");
            entity.Property(e => e.FkActivityStatusesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_activity_statuses_id");
            entity.Property(e => e.FkProductionId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_production_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            entity.HasOne(d => d.FkActivityManagers).WithMany(p => p.Activities)
                .HasForeignKey(d => d.FkActivityManagersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgo5r3ipcy8xlrqyy022irry1d");

            entity.HasOne(d => d.FkActivityStatuses).WithMany(p => p.Activities)
                .HasForeignKey(d => d.FkActivityStatusesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK38drdotkjak6y45wiqkvdm83g");

            entity.HasOne(d => d.FkProduction).WithMany(p => p.Activities)
                .HasForeignKey(d => d.FkProductionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK31quv0ckcxycaqw8rrdb1ht1b");
        });

        modelBuilder.Entity<ActivityManager>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("activity_managers");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .HasColumnName("role");
        });

        modelBuilder.Entity<ActivityStatus>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("activity_statuses");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("ingredients");

            entity.HasIndex(e => e.FkSuppliesId, "FK9nmrwkgipsa87dknjjqlpwfm9");

            entity.HasIndex(e => e.FkProductionsId, "FKd1efmuxo3agffmjmft2mbh0nc");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.FkProductionsId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_productions_id");
            entity.Property(e => e.FkSuppliesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_supplies_id");
            entity.Property(e => e.SetAmount)
                .HasColumnType("int(11)")
                .HasColumnName("set_amount");

            entity.HasOne(d => d.FkProductions).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.FkProductionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKd1efmuxo3agffmjmft2mbh0nc");

            entity.HasOne(d => d.FkSupplies).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.FkSuppliesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK9nmrwkgipsa87dknjjqlpwfm9");
        });

        modelBuilder.Entity<InventoriesSupply>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("inventories_supplies");

            entity.HasIndex(e => e.FkSuppliesId, "FKgerj6r47b6c5s5ifcetpxbwx0");

            entity.HasIndex(e => e.FkInventoriesId, "FKlp2dluvhfb62odqljxnowyp0p");

            entity.Property(e => e.FkInventoriesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_inventories_id");
            entity.Property(e => e.FkSuppliesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_supplies_id");

            entity.HasOne(d => d.FkInventories).WithMany()
                .HasForeignKey(d => d.FkInventoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKlp2dluvhfb62odqljxnowyp0p");

            entity.HasOne(d => d.FkSupplies).WithMany()
                .HasForeignKey(d => d.FkSuppliesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgerj6r47b6c5s5ifcetpxbwx0");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("inventories");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.EntryDate).HasColumnName("entry_date");
            entity.Property(e => e.EntryQuantity)
                .HasColumnType("int(11)")
                .HasColumnName("entry_quantity");
            entity.Property(e => e.ExitDate).HasColumnName("exit_date");
            entity.Property(e => e.ExitDescription)
                .HasColumnType("text")
                .HasColumnName("exit_description");
            entity.Property(e => e.ExitQuantity)
                .HasColumnType("int(11)")
                .HasColumnName("exit_quantity");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.TotalQuantity)
                .HasColumnType("int(11)")
                .HasColumnName("total_quantity");
        });

        modelBuilder.Entity<Novelty>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("novelties");

            entity.HasIndex(e => e.FkSendersId, "FK46sstpbdoicsjol42pdpyfc3r");

            entity.HasIndex(e => e.FkNoveltyStatesId, "FK493557rb4hvndamyr3poau1fh");

            entity.HasIndex(e => e.FkProductionsId, "FK92j6vuv16dev212uc9eop4jb9");

            entity.HasIndex(e => e.FkReferredId, "FKab0ikji99bw09661xct5b56so");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.FkNoveltyStatesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_novelty_states_id");
            entity.Property(e => e.FkProductionsId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_productions_id");
            entity.Property(e => e.FkReferredId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_referred_id");
            entity.Property(e => e.FkSendersId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_senders_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(30)
                .HasColumnName("subject");
            entity.Property(e => e.Time)
                .HasColumnType("time")
                .HasColumnName("time");

            entity.HasOne(d => d.FkNoveltyStates).WithMany(p => p.Novelties)
                .HasForeignKey(d => d.FkNoveltyStatesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK493557rb4hvndamyr3poau1fh");

            entity.HasOne(d => d.FkProductions).WithMany(p => p.Novelties)
                .HasForeignKey(d => d.FkProductionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK92j6vuv16dev212uc9eop4jb9");

            entity.HasOne(d => d.FkReferred).WithMany(p => p.Novelties)
                .HasForeignKey(d => d.FkReferredId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKab0ikji99bw09661xct5b56so");

            entity.HasOne(d => d.FkSenders).WithMany(p => p.Novelties)
                .HasForeignKey(d => d.FkSendersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK46sstpbdoicsjol42pdpyfc3r");
        });

        modelBuilder.Entity<NoveltyStatus>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("novelty_statuses");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.FkOrderStatusesId, "FK2a0b27w6505bekh7yo2oxqc3j");

            entity.HasIndex(e => e.FkUsersId, "FK97h78p6p00q4h6wok47i0kejg");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.DateRequest).HasColumnName("date_request");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.FkOrderStatusesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_order_statuses_id");
            entity.Property(e => e.FkUsersId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_users_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.FkOrderStatuses).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkOrderStatusesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2a0b27w6505bekh7yo2oxqc3j");

            entity.HasOne(d => d.FkUsers).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK97h78p6p00q4h6wok47i0kejg");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("order_statuses");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<OrdersProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orders_products");

            entity.HasIndex(e => e.FkProductsId, "FK5lhp195kgrgwa6vc0jg8dal0c");

            entity.HasIndex(e => e.FkOrdersId, "FKklb875ssv224he1cghm7wfq3a");

            entity.Property(e => e.FkOrdersId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_orders_id");
            entity.Property(e => e.FkProductsId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_products_id");

            entity.HasOne(d => d.FkOrders).WithMany()
                .HasForeignKey(d => d.FkOrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKklb875ssv224he1cghm7wfq3a");

            entity.HasOne(d => d.FkProducts).WithMany()
                .HasForeignKey(d => d.FkProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK5lhp195kgrgwa6vc0jg8dal0c");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.ProductImage)
                .HasColumnType("blob")
                .HasColumnName("product_image");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("int(11)")
                .HasColumnName("unit_price");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("productions");

            entity.HasIndex(e => e.FkProductionStatementsId, "FKb25530jr0axmc03tahx6m92tg");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FkProductionStatementsId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_production_statements_id");
            entity.Property(e => e.Lot)
                .HasMaxLength(20)
                .HasColumnName("lot");
            entity.Property(e => e.Observations)
                .HasColumnType("text")
                .HasColumnName("observations");
            entity.Property(e => e.ProductProduce)
                .HasMaxLength(30)
                .HasColumnName("product_produce");
            entity.Property(e => e.ProductQuality)
                .HasMaxLength(15)
                .HasColumnName("product_quality");
            entity.Property(e => e.QuantityProduce)
                .HasColumnType("int(11)")
                .HasColumnName("quantity_produce");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.FkProductionStatements).WithMany(p => p.Productions)
                .HasForeignKey(d => d.FkProductionStatementsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKb25530jr0axmc03tahx6m92tg");
        });

        modelBuilder.Entity<ProductionStatus>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("production_statuses");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductsInventory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("products_inventories");

            entity.HasIndex(e => e.FkInventoriesId, "FK14m5ibv42yl3s86v0md4mi7dk");

            entity.HasIndex(e => e.FkProductsId, "FKh1bllpjn782rus7vb87j9vrim");

            entity.Property(e => e.FkInventoriesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_inventories_id");
            entity.Property(e => e.FkProductsId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_products_id");

            entity.HasOne(d => d.FkInventories).WithMany()
                .HasForeignKey(d => d.FkInventoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK14m5ibv42yl3s86v0md4mi7dk");

            entity.HasOne(d => d.FkProducts).WithMany()
                .HasForeignKey(d => d.FkProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKh1bllpjn782rus7vb87j9vrim");
        });

        modelBuilder.Entity<Referral>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("referrals");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("sales");

            entity.HasIndex(e => e.FkOrdersId, "FKdkofildremkhocm12tbx6h6d8");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.DeliveryQuantity)
                .HasColumnType("int(11)")
                .HasColumnName("delivery_quantity");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.FkOrdersId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_orders_id");
            entity.Property(e => e.Receipt)
                .HasColumnType("blob")
                .HasColumnName("receipt");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.SaleTime)
                .HasColumnType("time")
                .HasColumnName("sale_time");
            entity.Property(e => e.Value)
                .HasColumnType("int(11)")
                .HasColumnName("value");

            entity.HasOne(d => d.FkOrders).WithMany(p => p.Sales)
                .HasForeignKey(d => d.FkOrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKdkofildremkhocm12tbx6h6d8");
        });

        modelBuilder.Entity<Sender>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("senders");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("supplies");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.FkRolesId, "FKr3t83h8hwh8521ox9rkb9bw86");

            entity.Property(e => e.Pkid)
                .HasColumnType("int(11)")
                .HasColumnName("pkid");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FkRolesId)
                .HasColumnType("int(11)")
                .HasColumnName("fk_roles_id");
            entity.Property(e => e.Identification)
                .HasMaxLength(15)
                .HasColumnName("identification");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.FkRoles).WithMany(p => p.Users)
                .HasForeignKey(d => d.FkRolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKr3t83h8hwh8521ox9rkb9bw86");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
