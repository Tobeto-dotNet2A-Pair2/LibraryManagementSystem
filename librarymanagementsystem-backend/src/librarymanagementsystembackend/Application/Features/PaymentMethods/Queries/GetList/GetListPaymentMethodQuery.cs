using Application.Features.PaymentMethods.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PaymentMethods.Constants.PaymentMethodsOperationClaims;

namespace Application.Features.PaymentMethods.Queries.GetList;

public class GetListPaymentMethodQuery : IRequest<GetListResponse<GetListPaymentMethodListItemDto>>, ICachableRequest, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPaymentMethods({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPaymentMethods";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPaymentMethodQueryHandler : IRequestHandler<GetListPaymentMethodQuery, GetListResponse<GetListPaymentMethodListItemDto>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public GetListPaymentMethodQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPaymentMethodListItemDto>> Handle(GetListPaymentMethodQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentMethod> paymentMethods = await _paymentMethodRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPaymentMethodListItemDto> response = _mapper.Map<GetListResponse<GetListPaymentMethodListItemDto>>(paymentMethods);
            return response;
        }
    }
}