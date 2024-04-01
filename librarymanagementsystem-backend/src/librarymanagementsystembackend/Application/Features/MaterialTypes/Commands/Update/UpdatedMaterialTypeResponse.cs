using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdatedMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialTypeName { get; set; }
    public string MaterialTypeCategory { get; set; }
}