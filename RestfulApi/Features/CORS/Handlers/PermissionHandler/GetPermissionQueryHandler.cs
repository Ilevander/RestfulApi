using RestfulApi.Features.CORS.Results.PermissionResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PermissionHandler
{
    public class GetPermissionQueryHandler
    {
        private readonly IRepository<Permission> _repository;

        public GetPermissionQueryHandler(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPermissionQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPermissionQueryResult
            {
                Id = x.Id,
                RoleId = x.RoleId,
                Title = x.Title,
                Module = x.Module,
                Description = x.Description,
                Role = x.Role,
                
            }).ToList();
        }
    }
}
