using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPropertyValues.Queries.GetById;

public class GetByIdMaterialPropertyValueResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
}