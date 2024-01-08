using RestfulApi.Features.CORS.Results.PatientResult;
using RestfulApi.Features.CORS.Results.ScheduleResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ScheduleHandler
{
    public class GetScheduleQueryHandler
    {
        private readonly IRepository<Schedule> _repository;

        public GetScheduleQueryHandler(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetScheduleQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetScheduleQueryResult
            {
                Id = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                DoctorId = x.DoctorId,
                Doctor = x.Doctor,
            }).ToList();
        }
    }
}
