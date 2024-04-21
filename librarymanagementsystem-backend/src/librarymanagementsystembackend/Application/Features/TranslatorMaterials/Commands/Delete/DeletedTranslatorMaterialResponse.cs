using NArchitecture.Core.Application.Responses;

namespace Application.Features.TranslatorMaterials.Commands.Delete;

public class DeletedTranslatorMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}