using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Commands.Delete;

public class DeletedMemberResponse : IResponse
{
    public Guid Id { get; set; }
}