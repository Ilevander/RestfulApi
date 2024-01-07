using RestfulApi.Features.CORS.Queries.AppointmentQueries;
using RestfulApi.Features.CORS.Results.AppointmentsResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.AppointmentHandler
{
    public class GetAppointmentByIdQueryHandler
    {
        private readonly IRepository<Appointment> _repository;
        public GetAppointmentByIdQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task<GetAppointmentByIdQueryResult> Handle (GetAppointmentByIdQuery query) 
        {
          var values = await _repository.GetByIdAsync (query.Id);
            return new GetAppointmentByIdQueryResult
            {
                Id = values.Id,
                AppointmentDate = values.AppointmentDate,
                Description = values.Description,
                DoctorId = values.DoctorId,
                PatientId = values.PatientId,
                Patient = values.Patient,
                Doctor = values.Doctor,
            };
        }
          
    }
}
