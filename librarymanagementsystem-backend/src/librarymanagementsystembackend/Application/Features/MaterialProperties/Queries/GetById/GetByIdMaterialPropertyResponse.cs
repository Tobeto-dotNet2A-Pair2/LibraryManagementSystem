using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialProperties.Queries.GetById;

public class GetByIdMaterialPropertyResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialPropertyName { get; set; }
}