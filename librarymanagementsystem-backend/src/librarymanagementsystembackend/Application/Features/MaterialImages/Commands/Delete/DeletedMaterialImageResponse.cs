using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialImages.Commands.Delete;

public class DeletedMaterialImageResponse : IResponse
{
    public Guid Id { get; set; }
}