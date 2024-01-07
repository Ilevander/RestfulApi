using RestfulApi.Features.CORS.Commands.AppointmentCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.AppointmentHandler
{
    public class UpdateAppoitmentCommandHandler
    {
        private readonly IRepository<Appointment> _repository;

        public UpdateAppoitmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppointmentCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.AppointmentDate = command.AppointmentDate;
            values.Description = command.Description;
            values.Doctor = command.Doctor;
            values.DoctorId = command.DoctorId;
            values.PatientId = command.PatientId;
            values.Patient = command.Patient;

            await _repository.UpdateAsync(values);
        }
    }
}
