using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Domain.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Creation date of the row.
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modification date of the row.
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime? DateModified { get; set; }
    }
}
