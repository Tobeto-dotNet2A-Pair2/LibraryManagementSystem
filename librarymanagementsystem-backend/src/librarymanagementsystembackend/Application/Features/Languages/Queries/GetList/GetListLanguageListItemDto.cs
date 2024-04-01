using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Languages.Queries.GetList;

public class GetListLanguageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string LanguageName { get; set; }
}