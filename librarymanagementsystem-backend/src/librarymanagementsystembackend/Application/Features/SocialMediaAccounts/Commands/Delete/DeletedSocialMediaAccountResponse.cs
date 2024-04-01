using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Delete;

public class DeletedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
}