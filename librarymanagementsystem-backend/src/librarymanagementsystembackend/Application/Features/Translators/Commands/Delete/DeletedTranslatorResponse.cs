using NArchitecture.Core.Application.Responses;

namespace Application.Features.Translators.Commands.Delete;

public class DeletedTranslatorResponse : IResponse
{
    public Guid Id { get; set; }
}