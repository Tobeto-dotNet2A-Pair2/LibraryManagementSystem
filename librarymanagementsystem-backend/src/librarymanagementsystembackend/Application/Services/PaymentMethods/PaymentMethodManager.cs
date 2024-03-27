using Application.Features.PaymentMethods.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PaymentMethods;

public class PaymentMethodManager : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly PaymentMethodBusinessRules _paymentMethodBusinessRules;

    public PaymentMethodManager(IPaymentMethodRepository paymentMethodRepository, PaymentMethodBusinessRules paymentMethodBusinessRules)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _paymentMethodBusinessRules = paymentMethodBusinessRules;
    }

    public async Task<PaymentMethod?> GetAsync(
        Expression<Func<PaymentMethod, bool>> predicate,
        Func<IQueryable<PaymentMethod>, IIncludableQueryable<PaymentMethod, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return paymentMethod;
    }

    public async Task<IPaginate<PaymentMethod>?> GetListAsync(
        Expression<Func<PaymentMethod, bool>>? predicate = null,
        Func<IQueryable<PaymentMethod>, IOrderedQueryable<PaymentMethod>>? orderBy = null,
        Func<IQueryable<PaymentMethod>, IIncludableQueryable<PaymentMethod, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PaymentMethod> paymentMethodList = await _paymentMethodRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return paymentMethodList;
    }

    public async Task<PaymentMethod> AddAsync(PaymentMethod paymentMethod)
    {
        PaymentMethod addedPaymentMethod = await _paymentMethodRepository.AddAsync(paymentMethod);

        return addedPaymentMethod;
    }

    public async Task<PaymentMethod> UpdateAsync(PaymentMethod paymentMethod)
    {
        PaymentMethod updatedPaymentMethod = await _paymentMethodRepository.UpdateAsync(paymentMethod);

        return updatedPaymentMethod;
    }

    public async Task<PaymentMethod> DeleteAsync(PaymentMethod paymentMethod, bool permanent = false)
    {
        PaymentMethod deletedPaymentMethod = await _paymentMethodRepository.DeleteAsync(paymentMethod);

        return deletedPaymentMethod;
    }
}
