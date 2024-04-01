using Application.Features.Libraries.Constants;
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

namespace Application.Features.Libraries.Commands.Delete;

public class DeleteLibraryCommand : IRequest<DeletedLibraryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, LibrariesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLibraries"];

    public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, DeletedLibraryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepository;
        private readonly LibraryBusinessRules _libraryBusinessRules;

        public DeleteLibraryCommandHandler(IMapper mapper, ILibraryRepository libraryRepository,
                                         LibraryBusinessRules libraryBusinessRules)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _libraryBusinessRules = libraryBusinessRules;
        }

        public async Task<DeletedLibraryResponse> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {
            Library? library = await _libraryRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _libraryBusinessRules.LibraryShouldExistWhenSelected(library);

            await _libraryRepository.DeleteAsync(library!);

            DeletedLibraryResponse response = _mapper.Map<DeletedLibraryResponse>(library);
            return response;
        }
    }
}