using Application.Features.PaymentMethods.Constants;
using Application.Features.PaymentMethods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PaymentMethods.Constants.PaymentMethodsOperationClaims;

namespace Application.Features.PaymentMethods.Commands.Update;

public class UpdatePaymentMethodCommand : IRequest<UpdatedPaymentMethodResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BranchId { get; set; }

    public string[] Roles => [Admin, Write, PaymentMethodsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPaymentMethods"];

    public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, UpdatedPaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly PaymentMethodBusinessRules _paymentMethodBusinessRules;

        public UpdatePaymentMethodCommandHandler(IMapper mapper, IPaymentMethodRepository paymentMethodRepository,
                                         PaymentMethodBusinessRules paymentMethodBusinessRules)
        {
            _mapper = mapper;
            _paymentMethodRepository = paymentMethodRepository;
            _paymentMethodBusinessRules = paymentMethodBusinessRules;
        }

        public async Task<UpdatedPaymentMethodResponse> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(predicate: pm => pm.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentMethodBusinessRules.PaymentMethodShouldExistWhenSelected(paymentMethod);
            paymentMethod = _mapper.Map(request, paymentMethod);

            await _paymentMethodRepository.UpdateAsync(paymentMethod!);

            UpdatedPaymentMethodResponse response = _mapper.Map<UpdatedPaymentMethodResponse>(paymentMethod);
            return response;
        }
    }
}