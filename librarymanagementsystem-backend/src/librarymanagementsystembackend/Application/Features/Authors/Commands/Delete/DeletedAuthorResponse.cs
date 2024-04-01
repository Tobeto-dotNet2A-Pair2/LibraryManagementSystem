using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Commands.Delete;

public class DeletedAuthorResponse : IResponse
{
    public Guid Id { get; set; }
}