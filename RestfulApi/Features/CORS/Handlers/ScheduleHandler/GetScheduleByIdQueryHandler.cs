using RestfulApi.Features.CORS.Queries.PatientQueries;
using RestfulApi.Features.CORS.Queries.ScheduleQueries;
using RestfulApi.Features.CORS.Results.PatientResult;
using RestfulApi.Features.CORS.Results.ScheduleResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ScheduleHandler
{
    public class GetScheduleByIdQueryHandler
    {
        private readonly IRepository <Schedule> _repository;

        public GetScheduleByIdQueryHandler(IRepository<Schedule> repository)
        {
            _repository = repository;
        }
        public async Task<GetScheduleByIdQueryResult> Handle(GetScheduleByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetScheduleByIdQueryResult
            {
                Id = values.Id,
                StartTime = values.StartTime,
                EndTime = values.EndTime,
                DoctorId = values.DoctorId,
                Doctor = values.Doctor,
            };
        }
    }
}
