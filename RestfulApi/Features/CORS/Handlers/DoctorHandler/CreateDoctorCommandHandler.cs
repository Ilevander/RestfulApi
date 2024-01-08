using RestfulApi.Features.CORS.Commands.DoctorCommands;
using RestfulApi.Features.CORS.Commands.FeeCommands;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.DoctorHandler
{
    public class CreateDoctorCommandHandler
    {
        private readonly IRepository<Doctor> _repository;

        public CreateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateDoctorCommand command)
        {
            await _repository.CreateAsync(new Doctor
            {
                DoctorName = command.DoctorName,
                Specialization = command.Specialization,
                ClinicId = command.ClinicId,
                Clinic = command.Clinic,
                Appointments = command.Appointments,
                Fees = command.Fees,
                Schedules = command.Schedules,  
            });

        }
    }
}
