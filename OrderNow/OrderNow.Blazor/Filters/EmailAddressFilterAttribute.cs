using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderNow.API.Filters
{
    public class EmailAddressFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _email;

        public EmailAddressFilterAttribute(string email)
        {
            _email = email;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}