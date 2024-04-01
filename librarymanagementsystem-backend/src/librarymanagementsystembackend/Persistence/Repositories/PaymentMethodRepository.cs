using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PaymentMethodRepository : EfRepositoryBase<PaymentMethod, Guid, BaseDbContext>, IPaymentMethodRepository
{
    public PaymentMethodRepository(BaseDbContext context) : base(context)
    {
    }
}