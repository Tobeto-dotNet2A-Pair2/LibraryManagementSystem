using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaterialImages.Queries.GetById;

public class GetByIdMaterialImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public Guid MaterialId { get; set; }
}