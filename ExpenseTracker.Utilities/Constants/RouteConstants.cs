namespace ExpenseTracker.Utilities.Constants
{
    public static class RouteConstants
    {
        /// <summary>
        /// CategoryController Routes.
        /// </summary>
        public const string CategoriesController = "/api/expense-tracker/";
        public const string Categories = "categories";
        public const string CategoryByKey = "categories/";
        public const string CreateCategory = "categories/create/";
        public const string UpdateCategory = "categories/update/";
        public const string DeleteCategory = "categories/delete/";

        /// <summary>
        /// ExpenseController Routes.
        /// </summary>
        public const string ExpensesController = "/api/expense-tracker/";
        public const string Expenses = "expenses";
        public const string ReadCategoryByKey = "expenses/";
        public const string CreateExpense = "expenses/create/";
        public const string UpdateExpense = "expenses/update/";
        public const string DeleteExpense = "expenses/delete/";
    }
}
