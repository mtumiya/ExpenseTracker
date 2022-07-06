﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Utilities.Constants
{
    public static class RouteConstants
    {
        /// <summary>
        /// Category Routes.
        /// </summary>
        public const string CategoriesController = "/api/expense-tracker/";
        public const string Categories = "categories";
        public const string CategoryByKey = "categories/key/";
        public const string CreateCategory = "categories/create/";
    }
}
