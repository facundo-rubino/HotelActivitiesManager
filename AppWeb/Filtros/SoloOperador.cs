using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filtros
{
    public class SoloOperador : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("rol") != "operador")
            {
                context.Result = new RedirectResult("/actividad/actividadesPorFecha");
                return;
            }
        }
    }
}
