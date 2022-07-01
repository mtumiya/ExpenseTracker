using ExpenseTracker.Utilities.Constants;
using System.ComponentModel.DataAnnotations;


namespace ExpenseTracker.Domain.Entities
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Primary key of the Categories table.
        /// </summary>
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// Name of the expense category.
        /// </summary>
        [Required(ErrorMessage = MessageConstants.RequiredError)]
        [StringLength(60)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Navigation property.
        /// </summary>
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
