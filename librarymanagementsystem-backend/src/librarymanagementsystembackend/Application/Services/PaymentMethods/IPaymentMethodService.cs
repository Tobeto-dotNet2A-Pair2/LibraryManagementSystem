using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PaymentMethods;

public interface IPaymentMethodService
{
    Task<PaymentMethod?> GetAsync(
        Expression<Func<PaymentMethod, bool>> predicate,
        Func<IQueryable<PaymentMethod>, IIncludableQueryable<PaymentMethod, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PaymentMethod>?> GetListAsync(
        Expression<Func<PaymentMethod, bool>>? predicate = null,
        Func<IQueryable<PaymentMethod>, IOrderedQueryable<PaymentMethod>>? orderBy = null,
        Func<IQueryable<PaymentMethod>, IIncludableQueryable<PaymentMethod, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PaymentMethod> AddAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> DeleteAsync(PaymentMethod paymentMethod, bool permanent = false);
}
