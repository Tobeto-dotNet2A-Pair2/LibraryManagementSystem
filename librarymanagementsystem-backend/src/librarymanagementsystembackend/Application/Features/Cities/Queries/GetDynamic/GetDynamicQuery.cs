using Application.Features.Cities.Rules;
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

namespace Application.Features.Cities.Queries.GetDynamic;
public class GetDynamicQuery : IRequest<GetListResponse<GetDynamicCityResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

    public class GetDynamicQueryHandler : IRequestHandler<GetDynamicQuery, GetListResponse<GetDynamicCityResponse>>
    {

        private readonly IMapper _mapper;
        private readonly CityBusinessRules _cityBusinessRules;
        private readonly ICityRepository _cityRepository;
        public GetDynamicQueryHandler(IMapper mapper, CityBusinessRules cityBusinessRules, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
            _cityRepository = cityRepository;
        }


        public async Task<GetListResponse<GetDynamicCityResponse>> Handle(GetDynamicQuery request, CancellationToken cancellationToken)
        {
            var dynamicList = await _cityRepository.GetListByDynamicAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, dynamic: request.Dynamic);


            GetListResponse<GetDynamicCityResponse> response = _mapper.Map<GetListResponse<GetDynamicCityResponse>>(dynamicList);

            return response;
        }


    }

}
