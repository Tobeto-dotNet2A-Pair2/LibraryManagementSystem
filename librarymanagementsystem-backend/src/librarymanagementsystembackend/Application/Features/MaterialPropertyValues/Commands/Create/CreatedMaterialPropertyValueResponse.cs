using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPropertyValues.Commands.Create;

public class CreatedMaterialPropertyValueResponse : IResponse
{
    public Guid Id { get; set; }
    public string MaterialPropertyValueName { get; set; }
    public Guid MaterialId { get; set; }
    public Guid MaterialTypeId { get; set; }
    public Guid MaterialPropertyId { get; set; }
}