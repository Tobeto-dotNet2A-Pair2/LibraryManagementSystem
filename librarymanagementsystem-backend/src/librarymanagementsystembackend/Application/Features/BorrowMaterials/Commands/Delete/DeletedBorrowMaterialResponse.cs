using NArchitecture.Core.Application.Responses;

namespace Application.Features.BorrowMaterials.Commands.Delete;

public class DeletedBorrowMaterialResponse : IResponse
{
    public Guid Id { get; set; }
}