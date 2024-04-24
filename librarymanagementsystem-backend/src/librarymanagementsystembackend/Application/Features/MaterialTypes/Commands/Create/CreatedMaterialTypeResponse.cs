using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreatedMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
}