using Application.Features.Authors.Constants;
using Application.Features.Authors.Constants;
using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Authors.Constants.AuthorsOperationClaims;

namespace Application.Features.Authors.Commands.Delete;

public class DeleteAuthorCommand : IRequest<DeletedAuthorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAuthors"];

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeletedAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;

        public DeleteAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository,
                                         AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorBusinessRules = authorBusinessRules;
        }

        public async Task<DeletedAuthorResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Author? author = await _authorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _authorBusinessRules.AuthorShouldExistWhenSelected(author);

            await _authorRepository.DeleteAsync(author!);

            DeletedAuthorResponse response = _mapper.Map<DeletedAuthorResponse>(author);
            return response;
        }
    }
}