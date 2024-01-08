using RestfulApi.Features.CORS.Commands.PatientCommands;
using RestfulApi.Features.CORS.Commands.ScheduleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ScheduleHandler
{
    public class UpdateScheduleCommandHandler
    {
        private readonly IRepository<Schedule> _repository;

        public UpdateScheduleCommandHandler(IRepository<Schedule> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateScheduleCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);

            values.StartTime = command.StartTime;
            values.EndTime = command.EndTime;
            values.Doctor = command.Doctor;
            values.DoctorId = command.DoctorId;

            await _repository.UpdateAsync(values);
        }
    }
}
