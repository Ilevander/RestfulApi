using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RestfulApi.Features.CORS.Handlers.AppointmentHandler;
using RestfulApi.Features.CORS.Handlers.BookingHandlers;
using RestfulApi.Features.CORS.Handlers.FeeHandlers;
using RestfulApi.Interfaces;
using RestfulApi.Models;
using RestfulApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ClinicSysDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Replace Repository<> with your actual repository implementation
/*Appointment Scop*/
builder.Services.AddScoped<GetAppointmentQueryHandler>();
builder.Services.AddScoped<GetAppointmentByIdQueryHandler>();
builder.Services.AddScoped<CreateAppointmentCommandHandler>();
builder.Services.AddScoped<RemoveAppointmentCommandHandler>();
builder.Services.AddScoped<UpdateAppoitmentCommandHandler>();
/*Fee Scop*/
builder.Services.AddScoped<GetFeeQueryHandler>();
builder.Services.AddScoped<GetFeeByIdQueryHandler>();
builder.Services.AddScoped<CreateFeeCommandHandler>();
builder.Services.AddScoped<RemoveFeeCommandHandler>();
builder.Services.AddScoped<UpdateFeeCommandHandler>();
/*Booking Scop*/
builder.Services.AddScoped<GetBookingQueryHandler>();
builder.Services.AddScoped<GetBookingByIdQueryHandler>();
builder.Services.AddScoped<CreateBookingCommandHandler>();
builder.Services.AddScoped<RemoveBookingCommandHandler>();
builder.Services.AddScoped<UpdateBookingCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ilyass API");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
