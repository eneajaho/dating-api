using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingAPI.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DatingAPI.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var repo = resultContext.HttpContext.RequestServices.GetService<IRepositoryWrapper>();

            var user = await repo.User.GetUserById(userId);

            user.LastActive = DateTime.Now;

            await repo.SaveAsync();
        }
    }
}