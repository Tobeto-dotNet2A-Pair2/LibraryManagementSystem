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

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommand : IRequest<UpdatedSocialMediaAccountResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest //ISecuredRequest,
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }

    public string[] Roles => [Admin, Write, SocialMediaAccountsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialMediaAccounts"];

    public class UpdateSocialMediaAccountCommandHandler : IRequestHandler<UpdateSocialMediaAccountCommand, UpdatedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public UpdateSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<UpdatedSocialMediaAccountResponse> Handle(UpdateSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaAccountBusinessRules.SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);
            socialMediaAccount = _mapper.Map(request, socialMediaAccount);

            await _socialMediaAccountRepository.UpdateAsync(socialMediaAccount!);

            UpdatedSocialMediaAccountResponse response = _mapper.Map<UpdatedSocialMediaAccountResponse>(socialMediaAccount);
            return response;
        }
    }
}