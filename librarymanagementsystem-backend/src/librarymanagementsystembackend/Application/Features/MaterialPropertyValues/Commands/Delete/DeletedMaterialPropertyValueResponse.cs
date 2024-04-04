using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialPropertyValues.Commands.Delete;

public class DeletedMaterialPropertyValueResponse : IResponse
{
    public Guid Id { get; set; }
}