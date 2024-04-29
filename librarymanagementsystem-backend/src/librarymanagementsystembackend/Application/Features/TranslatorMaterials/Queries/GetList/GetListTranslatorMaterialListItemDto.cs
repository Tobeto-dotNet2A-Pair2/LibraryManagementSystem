using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TranslatorMaterials.Queries.GetList;

public class GetListTranslatorMaterialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}