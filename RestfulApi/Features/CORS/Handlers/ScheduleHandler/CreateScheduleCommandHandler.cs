using RestfulApi.Features.CORS.Commands.ScheduleCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ScheduleHandler
{
    public class CreateScheduleCommandHandler
    {
        private readonly IRepository<Schedule> _repository;

        public CreateScheduleCommandHandler(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateScheduleCommand command)
        {
            await _repository.CreateAsync(new Schedule
            {
                StartTime = command.StartTime,
                EndTime = command.EndTime,
                DoctorId = command.DoctorId,
                Doctor = command.Doctor,
            });

        }
    }
}
