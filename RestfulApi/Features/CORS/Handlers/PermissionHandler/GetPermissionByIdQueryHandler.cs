using RestfulApi.Features.CORS.Queries.PermissionQueries;
using RestfulApi.Features.CORS.Results.PermissionResult;
using RestfulApi.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Features.CORS.Handlers.PermissionHandler
{
    public class GetPermissionByIdQueryHandler
    {
        private readonly IRepository <Permission> _repository;

        public GetPermissionByIdQueryHandler(IRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<GetPermissionByIdQueryResult> Handle(GetPermissionByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetPermissionByIdQueryResult
            {
                Id  = values.Id,
                RoleId = values.RoleId,
                Title = values.Title,
                Module = values.Module,
                Description = values.Description,
                Role = values.Role,
                
            };
        }
    }
}
