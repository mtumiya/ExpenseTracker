using ExpenseTracker.Infrastructure;
using ExpenseTracker.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Controllers
{
    /// <summary>
    /// URL: http://localhost:6600/api/asset-expense/
    /// </summary>
    [Route(RouteConstants.ExpensesController)]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseTrackerContext context;
        public ExpenseController(ExpenseTrackerContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// http://localhost:6600/api/expense-tracker/expenses/
        /// </summary> 
        [HttpGet]
        [Route(RouteConstants.Expenses)]
        public async Task<IActionResult> GetAllExpenses()
        {
            try
            {

                var expenses = await context.Expenses
                    .AsNoTracking()
                    .OrderBy(d => d.ExpenseDate)
                    .ToListAsync();

                return Ok(expenses);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// URL: http://localhost:6600/api/expense-tracker/expenses/{key}
        /// </summary>
        /// <param name="key">Primary key of the entity.</param> 
        [HttpGet]
        [Route(RouteConstants.ExpenseByKey + "{key}")]
        public async Task<IActionResult> ReadExpenseByKey(int key)
        {
            try
            {
                if (key <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var expense = await context.Categories.FindAsync(key);

                if (expense == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                return Ok(expense);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
