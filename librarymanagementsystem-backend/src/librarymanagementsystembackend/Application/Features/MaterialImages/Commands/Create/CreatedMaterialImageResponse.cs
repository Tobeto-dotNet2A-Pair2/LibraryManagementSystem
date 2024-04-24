using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialImages.Commands.Create;

public class CreatedMaterialImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public Guid MaterialId { get; set; }
}