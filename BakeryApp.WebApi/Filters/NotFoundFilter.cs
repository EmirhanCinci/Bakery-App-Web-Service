using Infrastructure.Business.Interfaces;
using Infrastructure.Model.Implementations;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BakeryApp.WebApi.Filters
{
    public class NotFoundFilter<TEntity, TEntityId> : IAsyncActionFilter where TEntity : Entity<TEntityId>
    {
        private readonly IBaseService<TEntity, TEntityId> _service;
        public NotFoundFilter(IBaseService<TEntity, TEntityId> service)
        { 
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (TEntityId)idValue;
            var anyEntity = await _service.AnyAsync(id);
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponse<NoData>.Fail(StatusCodes.Status404NotFound, $"Id'si {id} olan {typeof(TEntity).Name} kayıtlarda bulunamadı."));
        }
    }
}
