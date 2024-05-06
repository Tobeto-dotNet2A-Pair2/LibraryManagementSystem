using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Dtos;
public class AddressListItemDto : IDto
{
    public Guid NeighborhoodId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid CityId { get; set; }
}
