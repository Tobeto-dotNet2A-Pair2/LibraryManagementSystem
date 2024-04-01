using NArchitecture.Core.Application.Responses;

namespace Application.Features.Translators.Commands.Update;

public class UpdatedTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public string TranslatorName { get; set; }
    public string Description { get; set; }
}