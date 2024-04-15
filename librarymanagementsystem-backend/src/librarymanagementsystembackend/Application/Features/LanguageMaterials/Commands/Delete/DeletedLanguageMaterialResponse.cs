using NArchitecture.Core.Application.Responses;

namespace Application.Features.LanguageMaterials.Commands.Delete;

public class DeletedLanguageMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}