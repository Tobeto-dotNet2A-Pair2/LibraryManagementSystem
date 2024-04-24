using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Commands.Update;

public class UpdatedMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
}