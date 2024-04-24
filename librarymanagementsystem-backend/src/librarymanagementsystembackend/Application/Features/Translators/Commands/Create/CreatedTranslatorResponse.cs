using NArchitecture.Core.Application.Responses;

namespace Application.Features.Translators.Commands.Create;

public class CreatedTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}