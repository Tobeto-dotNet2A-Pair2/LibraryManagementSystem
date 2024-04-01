using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Translators.Queries.GetList;

public class GetListTranslatorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string TranslatorName { get; set; }
    public string Description { get; set; }
}