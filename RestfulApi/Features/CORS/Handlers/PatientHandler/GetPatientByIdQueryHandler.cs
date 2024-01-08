using RestfulApi.Features.CORS.Queries.PatientQueries;
using RestfulApi.Features.CORS.Results.PatientResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PatientHandler
{
    public class GetPatientByIdQueryHandler
    {
        private readonly IRepository<Patient> _repository;

        public GetPatientByIdQueryHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<GetPatientByIdQueryResult> Handle(GetPatientByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetPatientByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Mobile = values.Mobile,
                Address = values.Address,
                Email = values.Email,
                Password = values.Password,
                Username = values.Username,
                Appointments = values.Appointments,
                Bookings = values.Bookings,
            };
        }

    }
}
