using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Streets.Queries.GetDynamic;
public class GetDynamicStreetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid NeigborhoodId { get; set; }
}
