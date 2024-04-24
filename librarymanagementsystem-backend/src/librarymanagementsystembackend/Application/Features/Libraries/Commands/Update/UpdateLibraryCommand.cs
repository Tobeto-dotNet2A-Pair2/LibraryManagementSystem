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

namespace Application.Features.Libraries.Commands.Update;

public class UpdateLibraryCommand : IRequest<UpdatedLibraryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, LibrariesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLibraries"];

    public class UpdateLibraryCommandHandler : IRequestHandler<UpdateLibraryCommand, UpdatedLibraryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _libraryRepository;
        private readonly LibraryBusinessRules _libraryBusinessRules;

        public UpdateLibraryCommandHandler(IMapper mapper, ILibraryRepository libraryRepository,
                                         LibraryBusinessRules libraryBusinessRules)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
            _libraryBusinessRules = libraryBusinessRules;
        }

        public async Task<UpdatedLibraryResponse> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
        {
            Library? library = await _libraryRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _libraryBusinessRules.LibraryShouldExistWhenSelected(library);
            library = _mapper.Map(request, library);

            await _libraryRepository.UpdateAsync(library!);

            UpdatedLibraryResponse response = _mapper.Map<UpdatedLibraryResponse>(library);
            return response;
        }
    }
}