using Application.Features.SocialMediaAccounts.Constants;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SocialMediaAccounts.Constants.SocialMediaAccountsOperationClaims;

namespace Application.Features.SocialMediaAccounts.Commands.Delete;

public class DeleteSocialMediaAccountCommand : IRequest<DeletedSocialMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, SocialMediaAccountsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialMediaAccounts"];

    public class DeleteSocialMediaAccountCommandHandler : IRequestHandler<DeleteSocialMediaAccountCommand, DeletedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public DeleteSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<DeletedSocialMediaAccountResponse> Handle(DeleteSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaAccountBusinessRules.SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);

            await _socialMediaAccountRepository.DeleteAsync(socialMediaAccount!);

            DeletedSocialMediaAccountResponse response = _mapper.Map<DeletedSocialMediaAccountResponse>(socialMediaAccount);
            return response;
        }
    }
}