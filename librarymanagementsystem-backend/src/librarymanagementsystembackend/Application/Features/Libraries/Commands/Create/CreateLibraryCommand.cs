using Application.Features.Libraries.Constants;
using Application.Features.Libraries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Libraries.Constants.LibrariesOperationClaims;

namespace Application.Features.Libraries.Commands.Create;

public class CreateLibraryCommand : IRequest<CreatedLibraryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, LibrariesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLibraries"];

    public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, CreatedLibraryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepository;
        private readonly LibraryBusinessRules _libraryBusinessRules;

        public CreateLibraryCommandHandler(IMapper mapper, ILibraryRepository libraryRepository,
                                         LibraryBusinessRules libraryBusinessRules)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _libraryBusinessRules = libraryBusinessRules;
        }

        public async Task<CreatedLibraryResponse> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
        {
            Library library = _mapper.Map<Library>(request);

            await _libraryRepository.AddAsync(library);

            CreatedLibraryResponse response = _mapper.Map<CreatedLibraryResponse>(library);
            return response;
        }
    }
}