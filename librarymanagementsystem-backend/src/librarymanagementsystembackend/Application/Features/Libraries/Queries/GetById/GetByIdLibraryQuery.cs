using Application.Features.Libraries.Constants;
using Application.Features.Libraries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Libraries.Constants.LibrariesOperationClaims;

namespace Application.Features.Libraries.Queries.GetById;

public class GetByIdLibraryQuery : IRequest<GetByIdLibraryResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLibraryQueryHandler : IRequestHandler<GetByIdLibraryQuery, GetByIdLibraryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepository;
        private readonly LibraryBusinessRules _libraryBusinessRules;

        public GetByIdLibraryQueryHandler(IMapper mapper, ILibraryRepository libraryRepository, LibraryBusinessRules libraryBusinessRules)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _libraryBusinessRules = libraryBusinessRules;
        }

        public async Task<GetByIdLibraryResponse> Handle(GetByIdLibraryQuery request, CancellationToken cancellationToken)
        {
            Library? library = await _libraryRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _libraryBusinessRules.LibraryShouldExistWhenSelected(library);

            GetByIdLibraryResponse response = _mapper.Map<GetByIdLibraryResponse>(library);
            return response;
        }
    }
}