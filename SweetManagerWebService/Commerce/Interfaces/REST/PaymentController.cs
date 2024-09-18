﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerWebService.Commerce.Domain.Model.Queries.Payments;
using SweetManagerWebService.Commerce.Domain.Services.Payments;
using SweetManagerWebService.Commerce.Interfaces.REST.Resources.Payments;
using SweetManagerWebService.Commerce.Interfaces.REST.Transform.Payments;

namespace SweetManagerWebService.Commerce.Interfaces.REST;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentController(IPaymentOwnerCommandService paymentOwnerCommandService,
    IPaymentCustomerCommandService paymentCustomerCommandService,
    IPaymentOwnerQueryService paymentOwnerQueryService,
    IPaymentCustomerQueryService paymentCustomerQueryService) : ControllerBase
{

    [HttpPost("create-payment-owner")]
    public async Task<IActionResult> CreatePaymentOwner([FromBody] CreatePaymentOwnerResource resource)
    {
        try
        {
            var createPaymentOwnerCommand =
                CreatePaymentOwnerCommandFromResourceAssembler.ToCommandFromResource(resource);

            await paymentOwnerCommandService.Handle(createPaymentOwnerCommand);

            return Ok("Payment registered correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("get-payments-owner-id")]
    public async Task<IActionResult> GetPaymentsByOwnerId([FromQuery] int ownerId)
    {
        try
        {
            var payments = await paymentOwnerQueryService.Handle(new GetAllPaymentOwnersByOwnerIdQuery(ownerId));

            var paymentResources = 
                payments.Select(PaymentOwnerResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(paymentResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("create-payment-customer")]
    public async Task<IActionResult> CreatePaymentCustomer([FromBody] CreatePaymentCustomerResource resource)
    {
        try
        {
            var paymentCustomerCommand =
                CreatePaymentCustomerCommandFromResourceAssembler.ToCommandFromResource(resource);

            await paymentCustomerCommandService.Handle(paymentCustomerCommand);

            return Ok("Payment registered correctly!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    [HttpGet("get-payments-customer-id")]
    public async Task<IActionResult> GetPaymentsByCustomerId([FromQuery] int customerId)
    {
        try
        {
            var payments =
                await paymentCustomerQueryService.Handle(new GetAllPaymentCustomersByCustomerIdQuery(customerId));

            var paymentResources 
                = payments.Select(PaymentCustomerResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(paymentResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-payments-customer-hotel-id")]
    public async Task<IActionResult> GetPaymentCustomersByHotelId([FromQuery] int hotelId)
    {
        try
        {
            var payments = 
                await paymentCustomerQueryService.Handle(new GetAllPaymentCustomersByHotelIdQuery(hotelId));

            var paymentResources = 
                payments.Select(PaymentCustomerResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(paymentResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}