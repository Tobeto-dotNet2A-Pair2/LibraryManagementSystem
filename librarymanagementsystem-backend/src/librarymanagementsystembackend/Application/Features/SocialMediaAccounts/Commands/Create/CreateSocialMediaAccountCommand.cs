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

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommand : IRequest<CreatedSocialMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid BranchId { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }

    public string[] Roles => [Admin, Write, SocialMediaAccountsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialMediaAccounts"];

    public class CreateSocialMediaAccountCommandHandler : IRequestHandler<CreateSocialMediaAccountCommand, CreatedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public CreateSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<CreatedSocialMediaAccountResponse> Handle(CreateSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaAccountBusinessRules.BranchIdIsExist(request.BranchId);
            SocialMediaAccount socialMediaAccount = _mapper.Map<SocialMediaAccount>(request);

            await _socialMediaAccountRepository.AddAsync(socialMediaAccount);

            CreatedSocialMediaAccountResponse response = _mapper.Map<CreatedSocialMediaAccountResponse>(socialMediaAccount);
            return response;
        }
    }
}