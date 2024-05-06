using Application.Features.Streets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Streets.Queries.GetDynamic;
public class GetDynamicQuery : IRequest<GetListResponse<GetDynamicStreetResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

   public class GetDynamicQueryHandler : IRequestHandler<GetDynamicQuery, GetListResponse<GetDynamicStreetResponse>>
    {
        private readonly IMapper _mapper;

        private readonly StreetBusinessRules _streetBusinessRules;
        private readonly IStreetRepository _streetRepository;

        public GetDynamicQueryHandler(IMapper mapper, StreetBusinessRules streetBusinessRules, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetBusinessRules = streetBusinessRules;
            _streetRepository = streetRepository;
        }

        public async Task<GetListResponse<GetDynamicStreetResponse>> Handle(GetDynamicQuery request, CancellationToken cancellationToken)
        {
            var dynamicList = await _streetRepository.GetListByDynamicAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, dynamic: request.Dynamic);

            GetListResponse<GetDynamicStreetResponse> response = _mapper.Map<GetListResponse<GetDynamicStreetResponse>>(dynamicList);

            return response;
        }
    }
}
