using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetDynamic;
public class GetDynamicCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
