using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialImages.Commands.Update;

public class UpdatedMaterialImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public Guid MaterialId { get; set; }
}