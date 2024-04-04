using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPropertyValues.Commands.Update;

public class UpdatedMaterialPropertyValueResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialPropertyValueName { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
}