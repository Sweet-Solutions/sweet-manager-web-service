﻿using sweetmanager.API.Shared.Domain.Repositories;
using SweetManagerWebService.Commerce.Domain.Model.Commands.Payments;
using SweetManagerWebService.Commerce.Domain.Model.Entities.Payments;
using SweetManagerWebService.Commerce.Domain.Repositories.Payments;
using SweetManagerWebService.Commerce.Domain.Services.Payments;

namespace SweetManagerWebService.Commerce.Application.Internal.CommandServices.Payments;

public class PaymentCustomerCommandService(IPaymentCustomerRepository paymentCustomerRepository,
    IUnitOfWork unitOfWork) : IPaymentCustomerCommandService
{
    public async Task<bool> Handle(CreatePaymentCustomerCommand command)
    {
        try
        {

            var paymentValidation = await paymentCustomerRepository.FindByCustomerId(command.CustomerId);

            if (!paymentValidation.Any())
                throw new Exception($"There's no payments with the given customer id: {command.CustomerId}");
            
            await paymentCustomerRepository.AddAsync(new PaymentCustomer(command.CustomerId, command.FinalAmount));

            await unitOfWork.CompleteAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}