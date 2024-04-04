using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using Application.Services.Members;
using Application.Services.Addresses;
using Application.Services.Streets;
using Application.Services.Neighborhoods;
using Application.Services.Districts;
using Application.Services.Cities;
using Application.Services.Branches;
using Application.Services.Libraries;
using Application.Services.PaymentMethods;
using Application.Services.SocialMediaAccounts;
using Application.Services.MaterialCopies;
using Application.Services.Locations;
using Application.Services.Materials;
using Application.Services.Publishers;
using Application.Services.Languages;
using Application.Services.Authors;
using Application.Services.Translators;
using Application.Services.FavoriteLists;
using Application.Services.Notifications;
using Application.Services.BorrowedMaterials;
using Application.Services.Penalties;
using Application.Services.MaterialProperties;
using Application.Services.MaterialPropertyValues;
using Application.Services.MaterialTypes;
using Application.Services.MemberContacts;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int>();

        services.AddScoped<IMemberService, MemberManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IStreetService, StreetManager>();
        services.AddScoped<INeighborhoodService, NeighborhoodManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<ILibraryService, LibraryManager>();
        services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
        services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
        services.AddScoped<IMaterialCopyService, MaterialCopyManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IMaterialService, MaterialManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IMaterialCopyService, MaterialCopyManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IPublisherService, PublisherManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
        services.AddScoped<ITranslatorService, TranslatorManager>();
        services.AddScoped<IFavoriteListService, FavoriteListManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IBorrowedMaterialService, BorrowedMaterialManager>();
        services.AddScoped<IMaterialService, MaterialManager>();
        services.AddScoped<IMaterialCopyService, MaterialCopyManager>();
        services.AddScoped<IMemberService, MemberManager>();
        services.AddScoped<IPenaltyService, PenaltyManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
        services.AddScoped<IBorrowedMaterialService, BorrowedMaterialManager>();
        services.AddScoped<IBranchService, BranchManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IFavoriteListService, FavoriteListManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ILibraryService, LibraryManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IMaterialService, MaterialManager>();
        services.AddScoped<IMaterialCopyService, MaterialCopyManager>();
        services.AddScoped<IMaterialPropertyService, MaterialPropertyManager>();
        services.AddScoped<IMaterialPropertyValueService, MaterialPropertyValueManager>();
        services.AddScoped<IMaterialTypeService, MaterialTypeManager>();
        services.AddScoped<IMemberService, MemberManager>();
        services.AddScoped<INeighborhoodService, NeighborhoodManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
        services.AddScoped<IPenaltyService, PenaltyManager>();
        services.AddScoped<IPublisherService, PublisherManager>();
        services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
        services.AddScoped<IStreetService, StreetManager>();
        services.AddScoped<ITranslatorService, TranslatorManager>();
        services.AddScoped<IBorrowedMaterialService, BorrowedMaterialManager>();
        services.AddScoped<IBorrowedMaterialService, BorrowedMaterialManager>();
        services.AddScoped<IMaterialCopyService, MaterialCopyManager>();
        services.AddScoped<IMemberService, MemberManager>();
        services.AddScoped<IMemberContactService, MemberContactManager>();
        services.AddScoped<ILibraryService, LibraryManager>();
        services.AddScoped<IMaterialService, MaterialManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IPenaltyService, PenaltyManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
