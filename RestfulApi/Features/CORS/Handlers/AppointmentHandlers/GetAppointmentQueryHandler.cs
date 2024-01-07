using RestfulApi.Features.CORS.Results.AppointmentsResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.AppointmentHandler
{
    public class GetAppointmentQueryHandler
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task <List<GetAppointmentQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppointmentQueryResult
            {
                Id = x.Id,
                AppointmentDate = x.AppointmentDate,
                Description = x.Description,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Doctor = x.Doctor,
                Patient = x.Patient,
            }).ToList();
        }
    }
}
