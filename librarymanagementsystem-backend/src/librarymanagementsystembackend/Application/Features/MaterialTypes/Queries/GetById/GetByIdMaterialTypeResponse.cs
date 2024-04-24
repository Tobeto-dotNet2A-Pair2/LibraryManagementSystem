using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialTypes.Queries.GetById;

public class GetByIdMaterialTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MaterialFormat MaterialFormat { get; set; }
}