using RestfulApi.Features.CORS.Results.PatientResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PatientHandler
{
    public class GetPatientQueryHandler
    {
        private readonly IRepository<Patient> _repository;

        public GetPatientQueryHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPatientQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPatientQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Mobile = x.Mobile,
                Address = x.Address,
                Email = x.Email,
                Password = x.Password,
                Username = x.Username,
                Appointments = x.Appointments,
                Bookings = x.Bookings,
            }).ToList();
        }
    }
}
