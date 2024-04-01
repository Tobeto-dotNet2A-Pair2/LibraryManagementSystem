using NArchitecture.Core.Application.Responses;

namespace Application.Features.Translators.Queries.GetById;

public class GetByIdTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public string TranslatorName { get; set; }
    public string Description { get; set; }
}