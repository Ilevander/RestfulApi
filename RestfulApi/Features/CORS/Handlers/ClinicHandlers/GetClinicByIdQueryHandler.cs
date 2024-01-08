using RestfulApi.Features.CORS.Queries.BookingQueries;
using RestfulApi.Features.CORS.Queries.ClinicQueries;
using RestfulApi.Features.CORS.Results.BookingResult;
using RestfulApi.Features.CORS.Results.ClinicResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.ClinicHandlers
{
    public class GetClinicByIdQueryHandler
    {
        private readonly IRepository<Clinic> _repository;

        public GetClinicByIdQueryHandler(IRepository<Clinic> repository)
        {
            _repository = repository;
        }

        public async Task<GetClinicByIdQueryResult> Handle(GetClinicByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetClinicByIdQueryResult
            {
                ClinicId = values.ClinicId,
                ClinicName = values.ClinicName,
                Location = values.Location,
                Doctors = values.Doctors,
            };
        }
    }
}
