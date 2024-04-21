using NArchitecture.Core.Application.Responses;

namespace Application.Features.TranslatorMaterials.Commands.Update;

public class UpdatedTranslatorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TranslatorId { get; set; }
    public Guid MaterialId { get; set; }
}