using NArchitecture.Core.Application.Dtos;

namespace Application.Features.LanguageMaterials.Queries.GetList;

public class GetListLanguageMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }
}