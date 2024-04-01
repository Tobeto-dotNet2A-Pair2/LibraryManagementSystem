using Application.Features.Translators.Commands.Create;
using Application.Features.Translators.Commands.Delete;
using Application.Features.Translators.Commands.Update;
using Application.Features.Translators.Queries.GetById;
using Application.Features.Translators.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Translators.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Translator, CreateTranslatorCommand>().ReverseMap();
        CreateMap<Translator, CreatedTranslatorResponse>().ReverseMap();
        CreateMap<Translator, UpdateTranslatorCommand>().ReverseMap();
        CreateMap<Translator, UpdatedTranslatorResponse>().ReverseMap();
        CreateMap<Translator, DeleteTranslatorCommand>().ReverseMap();
        CreateMap<Translator, DeletedTranslatorResponse>().ReverseMap();
        CreateMap<Translator, GetByIdTranslatorResponse>().ReverseMap();
        CreateMap<Translator, GetListTranslatorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Translator>, GetListResponse<GetListTranslatorListItemDto>>().ReverseMap();
    }
}