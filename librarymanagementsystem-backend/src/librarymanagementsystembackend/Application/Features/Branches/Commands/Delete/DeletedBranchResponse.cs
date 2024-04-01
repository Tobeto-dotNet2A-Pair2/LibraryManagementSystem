using NArchitecture.Core.Application.Responses;

namespace Application.Features.Branches.Commands.Delete;

public class DeletedBranchResponse : IResponse
{
    public Guid Id { get; set; }
}