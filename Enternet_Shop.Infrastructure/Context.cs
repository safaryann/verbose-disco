using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Enternet_Shop.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=context")
        {
        }

        public virtual DbSet<ClientEntity> Clients { get; set; }
        public virtual DbSet<DeliveryEntity> Deliverys { get; set; }
        public virtual DbSet<DiscountEntity> Discounts { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }
        public virtual DbSet<InternetShopEntity> InternetShops { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public virtual DbSet<StatusEntity> Status { get; set; }
        public virtual DbSet<WarehouseEntity> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>()
                .HasMany(e => e.order)
                .WithRequired(e => e.client)
                .HasForeignKey(e => e.ID_client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderEntity>()
                .HasMany(e => e.delivery)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.ID_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusEntity>()
                .HasMany(e => e.order)
                .WithRequired(e => e.status_)
                .HasForeignKey(e => e.ID_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WarehouseEntity>()
                .HasMany(e => e.delivery)
                .WithRequired(e => e.warehouse)
                .HasForeignKey(e => e.ID_warehouse)
                .WillCascadeOnDelete(false);
        }
    }
}
