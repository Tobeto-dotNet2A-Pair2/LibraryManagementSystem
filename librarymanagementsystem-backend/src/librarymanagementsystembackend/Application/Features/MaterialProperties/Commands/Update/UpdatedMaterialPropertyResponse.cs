using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialProperties.Commands.Update;

public class UpdatedMaterialPropertyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}