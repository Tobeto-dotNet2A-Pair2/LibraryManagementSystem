using NArchitecture.Core.Application.Responses;

namespace Application.Features.LanguageMaterials.Commands.Update;

public class UpdatedLanguageMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }
}