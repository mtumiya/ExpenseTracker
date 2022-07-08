using ExpenseTracker.Domain.Entities;
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
        public async Task<IActionResult> ReadExpenses()
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
        [Route(RouteConstants.ReadCategoryByKey + "{key}")]
        public async Task<IActionResult> ReadExpenseByKey(int key)
        {
            try
            {
                if (key <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var expense = await context.Expenses.FindAsync(key);

                if (expense == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                return Ok(expense);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// URL: http://localhost:6600/api/expense-tracker/categories/create
        /// </summary>
        /// <param name="expense">Expense object.</param>
        [HttpPost]
        [Route(RouteConstants.CreateExpense)]
        public async Task<IActionResult> CreateExpense(Expense expense)
        {
            try
            {
                if (expense.ExpenseDate >= DateTime.Now)
                    return StatusCode(StatusCodes.Status400BadRequest);

                if (expense.Amount <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                context.Expenses.Add(expense);
                await context.SaveChangesAsync();

                return CreatedAtAction("ReadExpenseByKey", new { id = expense.ExpenseID }, expense);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// URL: https://localhost:6600/api/expense-tracker/expenses/update
        /// </summary>
        /// <param name="expense">Expense object.</param>
        [HttpPut]
        [Route(RouteConstants.UpdateExpense)]
        public async Task<IActionResult> UpdateExpense(int id, Expense expense)
        {
            try
            {
                if (expense.ExpenseDate >= DateTime.Now)
                    return StatusCode(StatusCodes.Status400BadRequest);

                if (expense.Amount <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                if (id != expense.ExpenseID)
                    return StatusCode(StatusCodes.Status404NotFound);

                context.Entry(expense).State = EntityState.Modified;
                context.Expenses.Update(expense);
                await context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// URL: http://localhost:6600/api/expense-tracker/expenses/delete/{key}
        /// </summary>
        /// <param name="key">Expense object.</param>
        [HttpDelete]
        [Route(RouteConstants.DeleteExpense + "{key}")]
        public async Task<IActionResult> DeleteExpense(int key)
        {
            try
            {
                var expense = await context.Expenses.FindAsync(key);

                if (key <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest);

                if (expense == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                context.Expenses.Remove(expense);
                await context.SaveChangesAsync();

                return Ok(expense);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
