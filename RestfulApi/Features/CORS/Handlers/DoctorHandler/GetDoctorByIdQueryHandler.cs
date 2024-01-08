using RestfulApi.Features.CORS.Queries.DoctorQueries;
using RestfulApi.Features.CORS.Results.DoctorResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.DoctorHandler
{
    public class GetDoctorByIdQueryHandler
    { 
        private readonly IRepository <Doctor> _repository;
        public GetDoctorByIdQueryHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<GetDoctorByIdQueryResult> Handle(GetDoctorByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetDoctorByIdQueryResult
            {
                DoctorId = values.DoctorId,
                DoctorName = values.DoctorName,
                Specialization = values.Specialization,
                ClinicId = values.ClinicId,
                Clinic = values.Clinic,
                Appointments = values.Appointments,
                Fees = values.Fees,
                Schedules = values.Schedules,
            };
        }
    }
}
