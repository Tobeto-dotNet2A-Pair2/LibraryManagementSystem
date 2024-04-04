using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Commands.Create;

public class CreatedMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialTypeName { get; set; }
    public string MaterialTypeCategory { get; set; }
}