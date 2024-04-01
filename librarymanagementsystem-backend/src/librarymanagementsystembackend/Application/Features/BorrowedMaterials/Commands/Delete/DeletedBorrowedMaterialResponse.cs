using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowedMaterials.Commands.Delete;

public class DeletedBorrowedMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}