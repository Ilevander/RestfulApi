using RestfulApi.Features.CORS.Results.ClinicResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ClinicHandlers
{
    public class GetClinicQueryHandler
    {
        private readonly IRepository<Clinic> _repository;

        public GetClinicQueryHandler(IRepository<Clinic> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetClinicQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetClinicQueryResult
            {
                ClinicId = x.ClinicId,
                ClinicName = x.ClinicName,
                Location = x.Location,
                Doctors = x.Doctors,
            }).ToList();
        }

    }
}
