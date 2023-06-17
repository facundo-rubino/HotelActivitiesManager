using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Logueado : Attribute, IAuthorizationFilter
    {
        private string _rol;

        public Logueado(string rol = "")
        {
            _rol = rol;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("email") == null)
            {
                context.Result = new RedirectResult("/actividad/index");
                return;
            }
        }
    }
}
