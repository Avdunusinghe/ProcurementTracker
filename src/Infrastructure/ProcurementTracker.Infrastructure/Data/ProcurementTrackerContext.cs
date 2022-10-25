using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Infrastructure.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data
{
    public class ProcurementTrackerContext : DbContext, IProcurementTrackerContext
    {
        private readonly AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;
        private IDbContextTransaction dbContextTransaction;
        public ProcurementTrackerContext(DbContextOptions<ProcurementTrackerContext> options,
             AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        public DbSet<PurchaseRequest> PurchaseRequests => Set<PurchaseRequest>();

        public DbSet<PurchaseRequestProductItem> PurchaseRequestProductItems => Set<PurchaseRequestProductItem>();

        public DbSet<SupplierProduct> SupplierProducts => Set<SupplierProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message))
                .EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            dbContextTransaction ??= await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                dbContextTransaction?.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (dbContextTransaction != null)
                {
                    DisposeTransaction();
                }
            }
        }

        public async Task RetryOnExceptionAsync(Func<Task> func)
        {
            await Database.CreateExecutionStrategy().ExecuteAsync(func);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await dbContextTransaction?.RollbackAsync(cancellationToken);
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction()
        {
            try
            {
                if (dbContextTransaction != null)
                {
                    dbContextTransaction.Dispose();
                    dbContextTransaction = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
