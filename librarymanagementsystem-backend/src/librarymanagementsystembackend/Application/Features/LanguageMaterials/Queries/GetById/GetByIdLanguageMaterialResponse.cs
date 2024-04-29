using NArchitecture.Core.Application.Responses;

namespace Application.Features.LanguageMaterials.Queries.GetById;

public class GetByIdLanguageMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid MaterialId { get; set; }
}