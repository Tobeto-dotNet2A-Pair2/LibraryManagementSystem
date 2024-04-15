using NArchitecture.Core.Application.Responses;

namespace Application.Features.TranslatorMaterials.Queries.GetById;

public class GetByIdTranslatorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}