using Application.Services.BorrowedMaterials;
using Hangfire;

namespace Infrastructure.BackgroundJobs.Hangfire;


/// <summary>
/// RecurringJobs
/// </summary>
public static class RecurringJobs
{
    [Obsolete]
    public static void CalculateMemberDebt()
    {
        RecurringJob.RemoveIfExists(nameof(BorrowedMaterialManager));
        RecurringJob.AddOrUpdate<BorrowedMaterialManager>(nameof(BorrowedMaterialManager),
            job => job.CalculateDept(),
            Cron.Daily
        );
    }
}