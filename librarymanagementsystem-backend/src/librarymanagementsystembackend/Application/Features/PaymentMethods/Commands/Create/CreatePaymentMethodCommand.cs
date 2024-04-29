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

namespace Application.Features.PaymentMethods.Commands.Create;

public class CreatePaymentMethodCommand : IRequest<CreatedPaymentMethodResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //  ISecuredRequest,
{
    public string Name { get; set; }
    public Guid BranchId { get; set; }

    public string[] Roles => [Admin, Write, PaymentMethodsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPaymentMethods"];

    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, CreatedPaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly PaymentMethodBusinessRules _paymentMethodBusinessRules;

        public CreatePaymentMethodCommandHandler(IMapper mapper, IPaymentMethodRepository paymentMethodRepository,
                                         PaymentMethodBusinessRules paymentMethodBusinessRules)
        {
            _mapper = mapper;
            _paymentMethodRepository = paymentMethodRepository;
            _paymentMethodBusinessRules = paymentMethodBusinessRules;
        }

        public async Task<CreatedPaymentMethodResponse> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            PaymentMethod paymentMethod = _mapper.Map<PaymentMethod>(request);

            await _paymentMethodRepository.AddAsync(paymentMethod);

            CreatedPaymentMethodResponse response = _mapper.Map<CreatedPaymentMethodResponse>(paymentMethod);
            return response;
        }
    }
}