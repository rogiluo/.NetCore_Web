using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rogiluo.Common.Models
{
    /// <summary>
    /// 會員主檔
    /// </summary>
    [Table("Data")]
    public class Data
    {
        /// <summary>
        /// 資料ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [StringLength(50), Required]
        public string Name { get; set; }

        /// <summary>
        /// 性別   
        /// </summary>
        public string Gender { get; set; }
    }
}
