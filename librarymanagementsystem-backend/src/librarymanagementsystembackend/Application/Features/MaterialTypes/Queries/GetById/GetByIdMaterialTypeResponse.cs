using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Queries.GetById;

public class GetByIdMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialTypeName { get; set; }
    public string MaterialTypeCategory { get; set; }
}