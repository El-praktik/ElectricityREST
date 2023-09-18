namespace ElectricityREST.Helpers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using ElectricityLibrary.model;
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttributes : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (Users)context.HttpContext.Items["Users"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" });
            }
            throw new NotImplementedException();
        }
    }
}
