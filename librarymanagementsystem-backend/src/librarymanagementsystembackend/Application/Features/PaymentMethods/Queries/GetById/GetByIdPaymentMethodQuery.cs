using Application.Features.PaymentMethods.Constants;
using Application.Features.PaymentMethods.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PaymentMethods.Constants.PaymentMethodsOperationClaims;

namespace Application.Features.PaymentMethods.Queries.GetById;

public class GetByIdPaymentMethodQuery : IRequest<GetByIdPaymentMethodResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPaymentMethodQueryHandler : IRequestHandler<GetByIdPaymentMethodQuery, GetByIdPaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly PaymentMethodBusinessRules _paymentMethodBusinessRules;

        public GetByIdPaymentMethodQueryHandler(IMapper mapper, IPaymentMethodRepository paymentMethodRepository, PaymentMethodBusinessRules paymentMethodBusinessRules)
        {
            _mapper = mapper;
            _paymentMethodRepository = paymentMethodRepository;
            _paymentMethodBusinessRules = paymentMethodBusinessRules;
        }

        public async Task<GetByIdPaymentMethodResponse> Handle(GetByIdPaymentMethodQuery request, CancellationToken cancellationToken)
        {
            PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(predicate: pm => pm.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentMethodBusinessRules.PaymentMethodShouldExistWhenSelected(paymentMethod);

            GetByIdPaymentMethodResponse response = _mapper.Map<GetByIdPaymentMethodResponse>(paymentMethod);
            return response;
        }
    }
}