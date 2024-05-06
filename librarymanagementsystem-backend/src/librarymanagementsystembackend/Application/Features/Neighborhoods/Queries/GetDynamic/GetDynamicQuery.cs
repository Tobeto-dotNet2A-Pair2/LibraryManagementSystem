using Application.Features.Neighborhoods.Rules;
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

namespace Application.Features.Neighborhoods.Queries.GetDynamic;
public class GetDynamicQuery : IRequest<GetListResponse<GetDynamicNeighborhoodResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }


    public class GetDynamicQueryHandler : IRequestHandler<GetDynamicQuery, GetListResponse<GetDynamicNeighborhoodResponse>>
    {
        private readonly IMapper _mapper;
        private readonly NeighborhoodBusinessRules _neighborhoodBusinessRules;
        private readonly INeighborhoodRepository _neighborhoodRepository;
        public GetDynamicQueryHandler(IMapper mapper, NeighborhoodBusinessRules neighborhoodBusinessRules, INeighborhoodRepository neighborhoodRepository)
        {
            _mapper = mapper;
            _neighborhoodBusinessRules = neighborhoodBusinessRules;
            _neighborhoodRepository = neighborhoodRepository;
        }

        public async Task<GetListResponse<GetDynamicNeighborhoodResponse>> Handle(GetDynamicQuery request, CancellationToken cancellationToken)
        {
            var dynamicList = await _neighborhoodRepository.GetListByDynamicAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, dynamic: request.Dynamic);

            GetListResponse<GetDynamicNeighborhoodResponse> response = _mapper.Map<GetListResponse<GetDynamicNeighborhoodResponse>>(dynamicList);   

            return response;
        }

    }
}
