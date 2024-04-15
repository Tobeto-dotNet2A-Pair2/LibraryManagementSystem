using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberNotificationRepository : IAsyncRepository<MemberNotification, Guid>, IRepository<MemberNotification, Guid>
{
}