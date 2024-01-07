using RestfulApi.Features.CORS.Commands.AppointmentCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.AppointmentHandler
{
    public class CreateAppointmentCommandHandler
    {
        private readonly IRepository<Appointment> _repository;

        public CreateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAppointmentCommand command)
        {
            await _repository.CreateAsync(new Appointment
            {
                AppointmentDate = command.AppointmentDate,
                Description = command.Description,
                Doctor = command.Doctor,
                DoctorId = command.DoctorId,
                PatientId = command.PatientId,
                Patient = command.Patient,
            });

        }
    }
}
