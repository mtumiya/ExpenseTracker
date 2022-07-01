using ExpenseTracker.Infrastructure;
using ExpenseTracker.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    /// <summary>
    /// URL: http://localhost:6600/api/expense-tracker/
    /// </summary>
    [Route(RoutConstants.CategoriesController)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ExpenseTrackerContext context;

        public CategoryController(ExpenseTrackerContext context)
        {
            this.context = context;
        }
    }
}
