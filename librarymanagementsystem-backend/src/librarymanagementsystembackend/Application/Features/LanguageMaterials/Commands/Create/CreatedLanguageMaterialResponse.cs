using NArchitecture.Core.Application.Responses;

namespace Application.Features.LanguageMaterials.Commands.Create;

public class CreatedLanguageMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }
}