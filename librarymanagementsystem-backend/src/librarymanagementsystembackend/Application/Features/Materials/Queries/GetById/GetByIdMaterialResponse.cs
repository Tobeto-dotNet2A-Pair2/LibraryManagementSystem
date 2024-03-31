using NArchitecture.Core.Application.Responses;

namespace Application.Features.Materials.Queries.GetById;

public class GetByIdMaterialResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Punishment { get; set; }
    public bool IsBorrowable { get; set; }
    public byte BorrowDay { get; set; }
}