using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    [Table("Tb_Category")]
    public class Category
    {
        [Column("ID")]
        [DisplayName("CategoryID")]
        public int Id { get; set; }

        [Column("CATEGORY_NAME")]
        [DisplayName("CategoryName")]
        public string? CategoryName { get; set; }

        [Column("CREATEDDATETIME")]
        [DisplayName("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [Column("UPDATEDDATETIME")]
        [DisplayName("UpdateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}
