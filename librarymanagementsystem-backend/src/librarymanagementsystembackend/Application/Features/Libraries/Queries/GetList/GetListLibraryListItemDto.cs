using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Libraries.Queries.GetList;

public class GetListLibraryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}