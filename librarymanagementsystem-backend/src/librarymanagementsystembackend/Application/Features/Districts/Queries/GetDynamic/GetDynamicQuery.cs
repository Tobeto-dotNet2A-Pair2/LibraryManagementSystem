using Application.Features.Districts.Rules;
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

namespace Application.Features.Districts.Queries.GetDynamic;
public class GetDynamicQuery : IRequest<GetListResponse<GetDynamicDistrictResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }
    public class GetDynamicQueryHandler : IRequestHandler<GetDynamicQuery, GetListResponse<GetDynamicDistrictResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DistrictBusinessRules _districtBusinessRules;
        private readonly IDistrictRepository _districtRepository;
        public GetDynamicQueryHandler(IMapper mapper, DistrictBusinessRules districtBusinessRules, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtBusinessRules = districtBusinessRules;
            _districtRepository = districtRepository;
        }

        public async Task<GetListResponse<GetDynamicDistrictResponse>> Handle(GetDynamicQuery request, CancellationToken cancellationToken)
        {
            var dynamicList = await _districtRepository.GetListByDynamicAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, dynamic: request.Dynamic);

            GetListResponse<GetDynamicDistrictResponse> response = _mapper.Map<GetListResponse<GetDynamicDistrictResponse>>(dynamicList);
            return response;
        }
    }

}
