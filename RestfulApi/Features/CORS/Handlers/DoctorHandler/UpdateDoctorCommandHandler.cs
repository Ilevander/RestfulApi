using RestfulApi.Features.CORS.Commands.DoctorCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.DoctorHandler
{
    public class UpdateDoctorCommandHandler
    {
        private readonly IRepository<Doctor> _repository;

        public UpdateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDoctorCommand command)
        {
            var values = await _repository.GetByIdAsync(command.DoctorId);

            values.DoctorName = command.DoctorName;
            values.Specialization = command.Specialization;
            values.ClinicId = command.ClinicId;
            values.Clinic = command.Clinic;
            values.Appointments = command.Appointments;
            values.Fees = command.Fees;
            values.Schedules = command.Schedules;

            await _repository.UpdateAsync(values);
        }
    }
}
