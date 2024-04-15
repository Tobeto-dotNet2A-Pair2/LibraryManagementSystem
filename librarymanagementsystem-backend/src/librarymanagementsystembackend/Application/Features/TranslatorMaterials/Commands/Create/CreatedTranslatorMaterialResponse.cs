using NArchitecture.Core.Application.Responses;

namespace Application.Features.TranslatorMaterials.Commands.Create;

public class CreatedTranslatorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}