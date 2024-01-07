using RestfulApi.Features.CORS.Queries.FeeQueries;
using RestfulApi.Features.CORS.Results.FeeResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.FeeHandlers
{
    public class GetFeeByIdQueryHandler
    {
        private readonly IRepository<Fee> _repository;

        public GetFeeByIdQueryHandler(IRepository<Fee> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeeByIdQueryResult> Handle(GetFeeByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetFeeByIdQueryResult
            {
                FeeId = values.FeeId,
                Amount = values.Amount,
                DoctorId = values.DoctorId,
                Doctor = values.Doctor,
            };
        }
    }
}
