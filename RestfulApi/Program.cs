using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RestfulApi.Features.CORS.Handlers.AppointmentHandler;
using RestfulApi.Features.CORS.Handlers.BookingHandlers;
using RestfulApi.Features.CORS.Handlers.ClinicHandlers;
using RestfulApi.Features.CORS.Handlers.DoctorHandler;
using RestfulApi.Features.CORS.Handlers.FeeHandlers;
using RestfulApi.Features.CORS.Handlers.PatientHandler;
using RestfulApi.Features.CORS.Handlers.PermissionHandler;
using RestfulApi.Features.CORS.Handlers.RoleHandler;
using RestfulApi.Features.CORS.Handlers.ScheduleHandler;
using RestfulApi.Features.CORS.Handlers.UserHandlers;
using RestfulApi.Interfaces;
using RestfulApi.Models;
using RestfulApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                 builder =>
                 {
                     builder
                     .WithOrigins("http://localhost:3000")
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials();
                 }));

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
/*Doctor Scop*/
builder.Services.AddScoped<GetDoctorQueryHandler>();
builder.Services.AddScoped<GetDoctorByIdQueryHandler>();
builder.Services.AddScoped<CreateDoctorCommandHandler>();
builder.Services.AddScoped<RemoveDoctorCommandHandler>();
builder.Services.AddScoped<UpdateDoctorCommandHandler>();
/*Patient Scop*/
builder.Services.AddScoped<GetPatientQueryHandler>();
builder.Services.AddScoped<GetPatientByIdQueryHandler>();
builder.Services.AddScoped<CreatePatientCommandHandler>();
builder.Services.AddScoped<RemovePatientCommandHandler>();
builder.Services.AddScoped<UpdatePatientCommandHandler>();
/*Schedule Scop*/
builder.Services.AddScoped<GetScheduleQueryHandler>();
builder.Services.AddScoped<GetScheduleByIdQueryHandler>();
builder.Services.AddScoped<CreateScheduleCommandHandler>();
builder.Services.AddScoped<RemoveScheduleCommandHandler>();
builder.Services.AddScoped<UpdateScheduleCommandHandler>();
/*Clinic Scop*/
builder.Services.AddScoped<GetClinicQueryHandler>();
builder.Services.AddScoped<GetClinicByIdQueryHandler>();
builder.Services.AddScoped<CreateClinicCommandHandler>();
builder.Services.AddScoped<RemoveClinicCommandHandler>();
builder.Services.AddScoped<UpdateClinicCommandHandler>();
/*User Scop*/
builder.Services.AddScoped<GetUserQueryHandler>();
builder.Services.AddScoped<GetUserByIdQueryHandler>();
builder.Services.AddScoped<CreateUserCommandHandler>();
builder.Services.AddScoped<RemoveUserCommandHandler>();
builder.Services.AddScoped<UpdateUserCommandHandler>();
/*Role Scop*/
builder.Services.AddScoped<GetRoleQueryHandler>();
builder.Services.AddScoped<GetRoleByIdQueryHandler>();
builder.Services.AddScoped<CreateRoleCommandHandler>();
builder.Services.AddScoped<RemoveRoleCommandHandler>();
builder.Services.AddScoped<UpdateRoleCommandHandler>();
/*Permission Scop*/
builder.Services.AddScoped<GetPermissionQueryHandler>();
builder.Services.AddScoped<GetPermissionByIdQueryHandler>();
builder.Services.AddScoped<CreatePermissionCommandHandler>();
builder.Services.AddScoped<RemovePermissionCommandHandler>();
builder.Services.AddScoped<UpdatePermissionCommandHandler>();



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
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
