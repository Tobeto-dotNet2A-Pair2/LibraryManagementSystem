using Application.Features.PaymentMethods.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PaymentMethods.Rules;

public class PaymentMethodBusinessRules : BaseBusinessRules
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly ILocalizationService _localizationService;

    public PaymentMethodBusinessRules(IPaymentMethodRepository paymentMethodRepository, ILocalizationService localizationService)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PaymentMethodsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PaymentMethodShouldExistWhenSelected(PaymentMethod? paymentMethod)
    {
        if (paymentMethod == null)
            await throwBusinessException(PaymentMethodsBusinessMessages.PaymentMethodNotExists);
    }

    public async Task PaymentMethodIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PaymentMethod? paymentMethod = await _paymentMethodRepository.GetAsync(
            predicate: pm => pm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PaymentMethodShouldExistWhenSelected(paymentMethod);
    }
}