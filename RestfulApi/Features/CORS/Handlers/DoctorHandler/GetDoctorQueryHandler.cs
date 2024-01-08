using RestfulApi.Features.CORS.Results.DoctorResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.DoctorHandler
{
    public class GetDoctorQueryHandler
    {
        private readonly IRepository<Doctor> _repository;

        public GetDoctorQueryHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetDoctorQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDoctorQueryResult
            {
                DoctorId = x.DoctorId,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                ClinicId = x.ClinicId,
                Clinic = x.Clinic,
                Appointments = x.Appointments,
                Fees = x.Fees,
                Schedules = x.Schedules,
            }).ToList();
        }
    }
}
