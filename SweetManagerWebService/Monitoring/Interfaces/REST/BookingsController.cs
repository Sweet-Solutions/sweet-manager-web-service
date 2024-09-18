﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using SweetManagerWebService.Monitoring.Domain.Services.Booking;
using SweetManagerWebService.Monitoring.Interfaces.REST.Resources.Booking;
using SweetManagerWebService.Monitoring.Interfaces.REST.Transform.Booking;
using SweetManagerWebService.Monitoring.Domain.Model.Queries.Booking;

namespace SweetManagerWebService.Monitoring.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingsController
        (IBookingCommandService bookingCommandService,
        IBookingQueryService bookingQueryService) :
        ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBooking
            ([FromBody] CreateBookingResource resource)
        {
            var result = await bookingCommandService
                .Handle(CreateBookingCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingState
            ([FromBody] UpdateBookingStateResource resource)
        {
            var result = await bookingCommandService
                .Handle(UpdateBookingCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> AllBookings()
        {
            var bookings = await bookingQueryService
                .Handle(new GetAllBookingsQuery());

            var bookingsResource = bookings.Select
                (BookingResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(bookingsResource);
        }

        [HttpGet]
        public async Task<IActionResult> BookingById
            ([FromQuery] int id)
        {
            var booking = await bookingQueryService
                .Handle(new GetBookingByIdQuery(id));

            if (booking is null)
                return BadRequest();

            var bookingResource = BookingResourceFromEntityAssembler
                .ToResourceFromEntity(booking);

            return Ok(bookingResource);
        }
    }
}