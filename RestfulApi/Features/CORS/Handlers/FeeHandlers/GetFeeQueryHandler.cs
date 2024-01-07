using RestfulApi.Features.CORS.Results.FeeResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.FeeHandlers
{
    public class GetFeeQueryHandler
    {
        private readonly IRepository<Fee> _repository;

        public GetFeeQueryHandler(IRepository<Fee> repository)
        {
            _repository = repository;
        }

        public async Task <List<GetFeeQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeeQueryResult
            {
                FeeId = x.FeeId,
                Amount = x.Amount,
                DoctorId = x.DoctorId,
                Doctor = x.Doctor,
                }).ToList();
        }
    }
}
