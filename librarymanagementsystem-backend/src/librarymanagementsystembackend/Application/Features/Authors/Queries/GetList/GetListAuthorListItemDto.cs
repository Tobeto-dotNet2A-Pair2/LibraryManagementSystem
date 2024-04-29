using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Authors.Queries.GetList;

public class GetListAuthorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
}