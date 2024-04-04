using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialProperties.Commands.Create;

public class CreatedMaterialPropertyResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialPropertyName { get; set; }
}