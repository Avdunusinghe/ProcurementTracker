using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Interfaces
{
    public interface IProcurementTrackerContext
    {
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Product> Products { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<ProductImage> ProductImages { get; }
        DbSet<PurchaseRequest> PurchaseRequests { get; }
        DbSet<PurchaseRequestProductItem> PurchaseRequestProductItems { get; }
        DbSet<SupplierProduct> SupplierProducts { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
        Task RetryOnExceptionAsync(Func<Task> func);
    }
}
