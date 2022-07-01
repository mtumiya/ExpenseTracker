﻿using ExpenseTracker.Utilities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense : BaseEntity
    {
        /// <summary>
        /// Primary key of the Expenses table.
        /// </summary>
        [Key]
        public int ExpenseID { get; set; }

        /// <summary>
        /// Date of expenditure.
        /// </summary>
        [Required(ErrorMessage = MessageConstants.RequiredError)]
        [Column(TypeName = "smalldatetime")]
        public DateTime? ExpenseDate { get; set; }

        /// <summary>
        ///Expense amount.
        /// </summary>
        [Required(ErrorMessage = MessageConstants.RequiredError)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Foreign key, reference of Categories table.
        /// </summary>
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
